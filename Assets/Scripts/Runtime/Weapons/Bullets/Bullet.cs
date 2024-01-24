using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletCollisionController))]
public class Bullet : PoolObject, IBullet
{
    private Rigidbody _rigidbody;
    public int Damage { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetDamage(int damage)
    {
        Damage = damage;
    }

    public void ResetVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
        
    }
}
