using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 50f;

    public void TakeDamage(float Damage)
    {
        Health -= Damage;

        if (Health <= 0)
        {
            Die();
        }
    }

   void Die()
    {
        Destroy(gameObject);
    }
}
