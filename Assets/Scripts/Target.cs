﻿using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Defeated();
        }
    }

    void Defeated ()
    {
        Destroy(gameObject);
    }
}
