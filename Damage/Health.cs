
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _currentHealth;
    [SerializeField] int _maxHealth;
    Animator _animator;
    const string DieAnimationState = "Die";
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void ApplyDamage(int amount)
    {
        if (amount < 0)
        {
            return;
        }
        _currentHealth -= amount;
        if ( _currentHealth <= 0)
        {
            Die();
        }
    }
    public void ApplyHealing(int amount)
    {
        if (amount < 0)
        {
            return;
        }
        _currentHealth += amount;
        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
    public void Die()
    {
        _animator.SetBool(DieAnimationState, true);
    }
}