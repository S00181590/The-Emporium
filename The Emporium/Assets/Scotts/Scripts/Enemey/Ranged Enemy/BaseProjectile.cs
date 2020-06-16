using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
   public float speed = 4.0f;
    public abstract void FireProjectileNow(GameObject Shoterobjecht, GameObject target, int damage, float attackrate);
}
