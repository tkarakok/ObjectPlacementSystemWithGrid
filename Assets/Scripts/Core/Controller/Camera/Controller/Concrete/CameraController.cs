using System;
using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using UnityEngine;

public class CameraController : MonoBehaviour, ICameraController
{
    #region References
    private Animator _cameraAnimator;
    
    #endregion

    private void Awake()
    {
        _cameraAnimator = GetComponentInChildren<Animator>();
    }

    public Result SetActiveCamera(string cameraParam)
    {
        _cameraAnimator.SetTrigger(cameraParam);
        return new SuccessResult();
    }
}
