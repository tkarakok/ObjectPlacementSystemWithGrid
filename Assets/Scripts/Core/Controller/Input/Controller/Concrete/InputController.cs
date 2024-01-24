using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IInputController
{
    public InputType InputType;
    public JoystickType JoystickType;

    public static Joystick Joystick;

    /// <summary>
    /// Current Vector2 of finger/mouse movement 
    /// </summary>
    public static Vector2 DeltaInputVector { get; private set; } = Vector2.zero;

    public bool PreventInput { get; private set; }

    [SerializeField] private LayerMask _placementLayermask;
    private Vector3 _lastPosition;

    public event Action OnClicked, OnExit;

    private void OnEnable()
    {
        if (InputType == InputType.Touch)
        {
            LeanTouch.OnFingerDown += OnFingerDown;
            LeanTouch.OnFingerUpdate += OnFingerUpdate;
            LeanTouch.OnFingerUpdate += UpdateLastPos;
            LeanTouch.OnFingerUp += OnFingerUp;
        }
    }

    protected void OnDisable()
    {
        if (InputType == InputType.Touch)
        {
            LeanTouch.OnFingerDown -= OnFingerDown;
            LeanTouch.OnFingerUpdate -= OnFingerUpdate;
            LeanTouch.OnFingerUpdate -= UpdateLastPos;
            LeanTouch.OnFingerUp -= OnFingerUp;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnExit?.Invoke();
        }
    }

    public bool IsPointerOverUI() => UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

    private void UpdateLastPos(LeanFinger finger)
    {
        Vector3 fingerPos = finger.ScreenPosition;
        fingerPos.z = Camera.main.nearClipPlane;
        Ray ray = Camera.main.ScreenPointToRay(fingerPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, _placementLayermask))
        {
            _lastPosition = hit.point;
        }
    }

    public Vector3 GetSelectedGroundPosition()
    {
        return _lastPosition;
    }

    
    #region Touch_Input

    private void OnFingerDown(LeanFinger finger)
    {
        
        if (PreventInput)
        {
            SetDeltaInputVector(Vector2.zero);
        }
        else
        {
            SetDeltaInputVector(finger.ScaledDelta);
        }
    }

    private void OnFingerUpdate(LeanFinger finger)
    {
        if (PreventInput)
        {
            SetDeltaInputVector(Vector2.zero);
        }
        else
        {
            SetDeltaInputVector(finger.ScaledDelta);
        }
    }

    private void OnFingerUp(LeanFinger finger)
    {
        SetDeltaInputVector(Vector2.zero);
    }

    #endregion

    public void SetDeltaInputVector(Vector2 targetVector)
    {
        DeltaInputVector = targetVector;
    }

    public void SetPreventInput(bool value)
    {
        PreventInput = value;
    }

    public bool IsInputExist()
    {
        return Input.GetMouseButton(0) || Input.touchCount > 0;
    }
}