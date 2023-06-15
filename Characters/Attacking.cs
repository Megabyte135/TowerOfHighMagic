using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] Weapon Weapon;
    Animator _animator;
    int _attackSequence = 1;
    bool _isReadyToAttack = true;
    const string AnimatorAttackTrigger = "Attack";
    const string AnimatorAttackSequence = "AttackSequence";
    const int MaxAttacksInSequence = 3;
    const float DelayBetweenAttacks = 0.5f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (_isReadyToAttack)
        {
            _isReadyToAttack = false;
            Weapon.Attack();
            NextAttack();
            _animator.SetTrigger(AnimatorAttackTrigger);
            _animator.SetInteger(AnimatorAttackSequence, _attackSequence);
            StartCoroutine(WaitForAttackToReady());
        }
    }

    void NextAttack()
    {
        _attackSequence++;
        if (_attackSequence > MaxAttacksInSequence)
        {
            _attackSequence = 1;
        }
    }

    IEnumerator WaitForAttackToReady()
    {
        yield return new WaitForSeconds(DelayBetweenAttacks - Weapon.Speed);
        _isReadyToAttack = true;
    }
}
