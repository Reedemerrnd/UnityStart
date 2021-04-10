using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IKAnimator : MonoBehaviour
{
    private Animator _anim;
    [SerializeField]
    private bool _IKActive = true;
    [SerializeField]
    private bool _IKArms = false;
    private Transform _lookObj;
    [SerializeField]
    private float _lookCheckRadius;

    [SerializeField]
    private float _armCheckRadius = .7f;
    [SerializeField]
    private Transform _rightShoulder;
    [SerializeField]
    private Transform _leftShoulder;
    private Transform _rightHandTarget;
    private Transform _leftHandTarget;
    [Header("Для отладки поворота ладони")]
    [SerializeField]
    private float _offsetRotX;
    [SerializeField]
    private float _offsetRotY;
    [SerializeField]
    private float _offsetRotZ;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        //ищем коллайдеры в радиусе для направления взгляда на подбираемый объект
        var colliders = Physics.OverlapSphere(transform.position, _lookCheckRadius);
        SearchNearestTransformByTag(colliders, "PickableObject", out _lookObj);
        //ищем ближающую стену справа
        colliders = Physics.OverlapCapsule(_rightShoulder.position,Vector3.forward, _armCheckRadius);
        SearchNearestTransformByTag(colliders, "Level", out _rightHandTarget);
        //ищем ближающую стену слева
        colliders = Physics.OverlapCapsule(_leftShoulder.position, Vector3.forward, _armCheckRadius);
        SearchNearestTransformByTag(colliders, "Level", out _leftHandTarget);


    }
    // ищем ближайший интересующий нас объект
    private bool SearchNearestTransformByTag(Collider[] colliders,string tag,out Transform target)
    {
        target = null;
        if (colliders != null && colliders.Any(c => c.CompareTag(tag)))
        {
            // ищем ближайший интересующий нас объект
            var nearest = colliders.Where(c => c.CompareTag(tag)).OrderBy(c => Vector3.Distance(transform.position, c.transform.position)).First();
            target = nearest.transform;
            Debug.Log(target);
            return true;
        }
        return false;
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (_IKActive)
        {
            if(_lookObj != null)
            {

                //изменяем вес относительно расстояния до объекта
                float smoothLooakAtWeight = 1 - ((Vector3.Distance(transform.position, _lookObj.position)) / _lookCheckRadius);
                _anim.SetLookAtPosition(_lookObj.position);
                _anim.SetLookAtWeight(smoothLooakAtWeight);
                

            }
            if (_IKArms)
            {
                if (_leftHandTarget != null)
                {
                    //ищем ближайшую точку на поверхности объекта
                    Vector3 offsetPos = _leftHandTarget.GetComponent<Collider>().ClosestPointOnBounds(_leftShoulder.position);
                    //изменяем вес относительно расстояния до объекта
                    float smoothLeftHandWeight = 1 - ((Vector3.Distance(_leftShoulder.position, offsetPos)) / _armCheckRadius);
                    //float smoothLeftHandWeight = 1;

                    _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, smoothLeftHandWeight);
                    _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, smoothLeftHandWeight);
                    _anim.SetIKPosition(AvatarIKGoal.LeftHand, offsetPos);
                    _anim.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandTarget.rotation);
                }
               
                if (_rightHandTarget != null)
                {
                    //ищем ближайшую точку на поверхности объекта
                    Vector3 offsetPos = _rightHandTarget.GetComponent<Collider>().ClosestPointOnBounds(_rightShoulder.position);
                    //изменяем вес относительно расстояния до объекта
                    float smoothRightHandWeight = 1-((Vector3.Distance(_rightShoulder.position, offsetPos)) / _armCheckRadius );
                    //float smoothRightHandWeight = 1;
                    _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, smoothRightHandWeight);
                    _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, smoothRightHandWeight);
                    _anim.SetIKPosition(AvatarIKGoal.RightHand, offsetPos);

                    //попытка расчета смещения для правильной ротации ладони
                    Quaternion offsetRot = _rightHandTarget.rotation;
                    //offsetRot = Quaternion.AngleAxis(_offsetRotX, Vector3.right);
                    //offsetRot = Quaternion.AngleAxis(_offsetRotY, Vector3.forward);
                    //offsetRot = Quaternion.AngleAxis(_offsetRotZ, Vector3.up);
                    //offsetRot = Quaternion.Euler(new Vector3(_offsetRotX, _offsetRotY, _offsetRotZ));


                    _anim.SetIKRotation(AvatarIKGoal.RightHand, offsetRot);
                }
                
            }

        }
    }
}
