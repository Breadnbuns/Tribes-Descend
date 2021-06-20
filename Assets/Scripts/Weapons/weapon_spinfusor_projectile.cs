using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_spinfusor_projectile : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
