using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string Name;
    public float Speed;
    public int Damage;
    Collider _collider;
    Rigidbody _rb;
    public Collider? _characterCollider;
    const float AnimationSpeed = 1.0f;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _characterCollider = GetCharacterCollider();
        _collider.enabled = false;
        _rb.isKinematic = true;
    }

    public void Attack()
    {
        _collider.enabled = true;
        _rb.isKinematic = false;
        StartCoroutine(EnableColliderForAttack());
    }

    IEnumerator EnableColliderForAttack()
    {
        yield return new WaitForSeconds(AnimationSpeed - Speed);
        _collider.enabled = false;
        _rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        Health health;
        if (collision.collider != _characterCollider
            && collision.gameObject.TryGetComponent<Health>(out health))
        {
            health.ApplyDamage(Damage);
        }
    }

    Collider? GetCharacterCollider()
    {
        Collider? parentCollider = null;
        Transform parent = transform.parent;

        while (parent != null)
        {
            parentCollider = parent.GetComponent<Collider>();

            if (parentCollider != null)
                break;
            parent = parent.parent;
        }

        return parentCollider;
    }
}
