using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] Weapon Weapon;
    Animator _animator;
    GameObject _weaponObject;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _weaponObject = Weapon.gameObject;
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        _animator.SetTrigger(Weapon.Animation);
    }
}
