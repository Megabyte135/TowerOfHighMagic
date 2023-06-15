
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int CurrentHealth
    {
        get { return _currentHealth; }
    }
    public int MaxHealth
    {
        get { return _maxHealth; }
    }
    [SerializeField] AudioSource DamageEffect;
    [SerializeField] AudioSource DieEffect;
    [SerializeField] int _currentHealth;
    [SerializeField] int _maxHealth;
    Animator _animator;
    AudioManager _audioManager;
    const string DieAnimationState = "Die";

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioManager = AudioManager.instance;
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
        else
        {
            _audioManager.PlayEffect(DamageEffect);
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
        //_audioManager.PlayEffect(DieEffect);
        _animator.SetTrigger(DieAnimationState);
        GetComponent<Creature>().Disable();
    }
}