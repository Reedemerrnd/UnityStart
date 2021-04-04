using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIWander : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] 
    private float _speed;
    [SerializeField] 
    private float _runSpeed;
    [SerializeField] 
    private float _obstacleRange;
    [SerializeField] 
    private float _attackDistance = 3.0f;
    [SerializeField]
    private float _attackSpeed;
    private float _attackTimer;
    [SerializeField]
    private float _damage;
    [SerializeField] 
    private float _rotationSpeed;
    private AIHealth _aiHealth;
    private bool _playerSpotted = false;
    private Transform _playerPos;
    private Vector3 _lastPosition;
    private Vector3 _movement = Vector3.forward;

    [SerializeField] private bool _isOnPatrol;
    [SerializeField] private List<Transform> _waypoints;
    private int _currentWp=0;

    private NavMeshAgent _navAgent;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _navAgent = GetComponent<NavMeshAgent>();
        _aiHealth = GetComponent<AIHealth>();
        _navAgent.angularSpeed = _rotationSpeed;
        _navAgent.stoppingDistance = _attackDistance;
        _attackTimer = 0;
        if (_isOnPatrol && _waypoints!=null) 
            _navAgent.SetDestination(_waypoints[_currentWp].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_aiHealth.IsAlive)
        {
            if (_playerSpotted)
            {
                Vector3 playerPos = _playerPos.position;
                RunAnim();
                _navAgent.destination = _playerPos.position;
                if (_navAgent.remainingDistance <= _attackDistance)
                {
                    _animator.SetBool("PlayerNear", true);
                    _navAgent.isStopped = true;
                    gameObject.transform.LookAt(
                        new Vector3(playerPos.x, 0, playerPos.z)
                        );
                    if (_attackTimer <= Time.time)
                    {
                        _playerPos.gameObject.GetComponent<Health>().Hit(_damage);
                        _attackTimer = Time.time + _attackSpeed;
                    }
                }

                else
                {
                    RunAnim();
                    _navAgent.isStopped = false;
                }
            }
            else if (_isOnPatrol && _waypoints != null)
            {
                WalkAnim();
                if (_navAgent.remainingDistance < _navAgent.stoppingDistance)
                {
                    _currentWp += 1;
                    if (_currentWp >= _waypoints.Count) _currentWp = 0;
                    _navAgent.SetDestination(_waypoints[_currentWp].position);
                }
            }
            else if (_navAgent.remainingDistance<=_navAgent.stoppingDistance)
            { 
                Wander();
            }


        }
        else if (!_aiHealth.IsAlive)
        {
            _navAgent.isStopped = true;
            _animator.SetBool("Death", true);
            Destroy(gameObject, 2);
        }
    }
    private void Wander()
    {
        WalkAnim();
        _movement.z = _speed * Time.deltaTime;
        transform.Translate(_movement);
        {
            Ray ray = new Ray(
                transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
                if (hit.distance < _obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
        }
    }
    public void TargetSpotted(Transform target)
    {
        RunAnim();
        _playerPos = target;
        _playerSpotted = true;
    }
    public void TargetLastPos(Transform target)
    {
        RunAnim();
        _lastPosition = target.position;
        _navAgent.destination = _lastPosition;
        _playerSpotted = false;
    }
    private void WalkAnim()
    {
        _animator.SetBool("PlayerNear", false);
        _animator.SetBool("PlayerSpot", false);
        _navAgent.speed = _speed;
    }
    private void RunAnim()
    {
        _animator.SetBool("PlayerNear", false);
        _animator.SetBool("PlayerSpot", true);
        _navAgent.speed = _runSpeed;
    }
}
