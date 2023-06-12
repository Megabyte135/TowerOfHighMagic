using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged
{
    public int Amount;
    public DamageType Type { get; set; }
}

public enum DamageType
{
    Physical,
    Fire,
    Force
}