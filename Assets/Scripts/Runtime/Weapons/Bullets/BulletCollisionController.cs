using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
    private Bullet _bullet;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }


}
