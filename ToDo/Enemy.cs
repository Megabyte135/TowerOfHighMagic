using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Creature
{
    public float SightRadius = 10f;
    public float AttackRadius = 2f;
    public float RotationSpeed = 1f;
    public float MovementSpeed = 3f;
    public Transform Target;
    Attacking _attacking;
    NavMeshAgent _agent;
    Animator _animator;
    float _distanceToTarget = 0f;
    const string AnimatorSpeed = "Speed";

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _attacking = GetComponent<Attacking>();
        _animator = GetComponent<Animator>();
        _agent.speed = MovementSpeed;
    }

    void Update()
    {
        _animator.SetFloat(AnimatorSpeed, 0f);
        if (CanSeeTarget())
        {
            FaceTarget();
            if (_distanceToTarget <= AttackRadius)
            {
                _attacking.Attack();
            }
            else
            {
            Move();
            }
        }
        
    }

    bool CanSeeTarget()
    {
        _distanceToTarget = Vector3.Distance(transform.position, Target.position);
        if (_distanceToTarget <= SightRadius)
        {
            NavMeshHit hit;

            if (!_agent.Raycast(Target.position, out hit))
            {
                return true;
            }
        }
        return false;
    }

    void Move()
    {
        Vector3 movementDistance = (Target.position - transform.position) * Time.deltaTime;
        _agent.Move(movementDistance);
        _animator.SetFloat(AnimatorSpeed, MovementSpeed);
    }

    void FaceTarget()
    {
        Vector3 lookPos = Target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed);
    }

    public override void Disable()
    {
        this.enabled = false;
    }
}
