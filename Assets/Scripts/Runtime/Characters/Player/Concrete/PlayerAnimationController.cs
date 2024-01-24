using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void SetMovementAnim(float animFloat)
    {
        _animator.SetFloat("Movement", animFloat);
    }
    public void SeLootAnim()
    {
        _animator.SetTrigger("Loot");
    }
    public void SeBuffAnim()
    {
        _animator.SetTrigger("Buff");
    }
    public void SeHitAnim()
    {
        _animator.SetTrigger("Hit");
    }
    
}
