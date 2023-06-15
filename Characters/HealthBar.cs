using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    public Image Bar;
    Health _health;

    void Start()
    {
        _health = GetComponent<Health>();
    }

    void Update()
    {
        Bar.fillAmount = ((float)_health.CurrentHealth/_health.MaxHealth);
    }
}
