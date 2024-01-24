using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PreviewSystem))]
[RequireComponent(typeof(ObjectPlacer))]
public class PlacementController : MonoBehaviour, IPlacementController
{
    [SerializeField] private Grid _grid;

    [SerializeField] private ObjectDatabaseSO _objectDatabaseSo;
   

    [SerializeField] private GameObject _gridVisualizationObject;

    private GridData floorData, furnitureData;

    private PreviewSystem _previewSystem;
    private ObjectPlacer _objectPlacer;
    
    private Vector3Int _lastDetectedPosition = Vector3Int.zero;

    private IPlacementState _placementState;
    
    private void Start()
    {
        _previewSystem = GetComponent<PreviewSystem>();
        _objectPlacer = GetComponent<ObjectPlacer>();
        StopPlacement();
        floorData = new GridData();
        furnitureData = new GridData();
    }
    
    public void StartPlacement(int objectID)
    {
        StopPlacement();
        _gridVisualizationObject.SetActive(true);

        _placementState = new PlacementState(objectID, _grid, _objectDatabaseSo, floorData, furnitureData,
            _previewSystem, _objectPlacer);
        
        InputManager.Instance.InputController.OnClicked += PlaceObject;
        InputManager.Instance.InputController.OnExit += StopPlacement;
    }

    public void StartRemoving()
    {
        StopPlacement();
        _gridVisualizationObject.SetActive(true);
        _placementState = new RemovingState(_grid, floorData, furnitureData, _previewSystem, _objectPlacer);
        InputManager.Instance.InputController.OnClicked += PlaceObject;
        InputManager.Instance.InputController.OnExit += StopPlacement;
    }
    private void PlaceObject()
    {
        if (InputManager.Instance.InputController.IsPointerOverUI()) return;
        Vector3 touchPosition = InputManager.Instance.InputController.GetSelectedGroundPosition();
        Vector3Int gridPos = _grid.WorldToCell(touchPosition);

        _placementState.OnAction(gridPos);
    }


    public void StopPlacement()
    {
        if (_placementState == null) return;
        _gridVisualizationObject.SetActive(false);
        _placementState.EndState();
        InputManager.Instance.InputController.OnClicked -= PlaceObject;
        InputManager.Instance.InputController.OnExit -= StopPlacement;
        _lastDetectedPosition = Vector3Int.zero;
        _placementState = null;
    }

    private void Update()
    {
        if (_placementState == null) return;
        Vector3 touchPosition = InputManager.Instance.InputController.GetSelectedGroundPosition();
        Vector3Int gridPos = _grid.WorldToCell(touchPosition);

        if (_lastDetectedPosition == gridPos) return;
        
        _placementState.UpdateState(gridPos);
        _lastDetectedPosition = gridPos;
    }
}