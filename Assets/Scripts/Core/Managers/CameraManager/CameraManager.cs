using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    public CameraController CameraController { get; private set; }

    private void Awake()
    {
        CameraController = FindObjectOfType<CameraController>();
    }
}
