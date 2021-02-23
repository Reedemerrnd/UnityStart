using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIWander : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _obstacleRange;
    [SerializeField] private float _attackDistance = 3.0f;
    [SerializeField] private float _rotationSpeed;
    private bool _alive = true;
    private bool _playerSpotted = false;
    private GameObject _player;
    private Vector3 _movement = Vector3.forward;

    [SerializeField] private bool _isOnPatrol;
    [SerializeField] private List<Transform> _waypoints;
    private int _currentWp=0;

    private NavMeshAgent _navAgent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _navAgent = GetComponent<NavMeshAgent>();
        //_navAgent.autoBraking = false;
        _navAgent.angularSpeed = _rotationSpeed;
        _navAgent.stoppingDistance = _attackDistance;
        if (_isOnPatrol && _waypoints!=null) _navAgent.SetDestination(_waypoints[_currentWp].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            if (_playerSpotted)
            {
                _isOnPatrol = false;
                Vector3 playerPos = _player.transform.position;
                animator.SetBool("PlayerSpot", true);
                _navAgent.speed = _runSpeed;
                _navAgent.destination = _player.transform.position;
                if (_navAgent.remainingDistance <= _attackDistance)
                {
                    animator.SetBool("PlayerNear", true);
                    _navAgent.isStopped = true;
                    gameObject.transform.LookAt(new Vector3(playerPos.x, 0, playerPos.z));
                }

                else
                    animator.SetBool("PlayerNear", false);
                _navAgent.isStopped = false;
            }
            else if (_isOnPatrol && _waypoints != null) 
            {
                if (_navAgent.remainingDistance < _navAgent.stoppingDistance)
                {
                    _currentWp += 1;
                    if (_currentWp >= _waypoints.Count) _currentWp = 0;
                    _navAgent.SetDestination(_waypoints[_currentWp].position);
                }
            }
            else Wander();


        }
    }
    private void Wander()
    {
        _movement.z = _speed * Time.deltaTime;
        transform.Translate(_movement);
        {
            UnityEngine.Ray ray = new UnityEngine.Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
                if (hit.distance < _obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
        }
    }
    public void TargetSpotted(GameObject target)
    {
        _player = target;
        _playerSpotted = true;
    }
    public void Die()
    {
        _alive = false;
        _navAgent.isStopped = true;
        animator.SetBool("Death", true);
        Destroy(gameObject, 2);
    }
}
