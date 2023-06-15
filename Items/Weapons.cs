using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateWeaponsList", order = 1)]
public class Weapons : ScriptableObject
{
    public List<Weapon> WeaponsList;
}
