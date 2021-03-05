using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IWeapon 
{
    public Transform Shooter { get; }
    public void Fire();
    public void BuffDamage(bool buffed);


}
