using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IHittable
{
    public float Damage;
    public float Speed;
    public WeaponType Type;
    public string Animation;

    public void Hit()
    {
        throw new System.NotImplementedException();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>())
        {
        }
    }
}
