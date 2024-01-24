
using System;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class InputManager : Singleton<InputManager>
{
    private InputController _inputController;
    public InputController InputController => _inputController;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
    }
}