using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementState : IPlacementState
{

    private int _selectedObjectIndex = -1;
    private int ID;
    [SerializeField] private Grid _grid;
    [SerializeField] private ObjectDatabaseSO _objectDatabaseSo;
    private GridData floorData, furnitureData;
    private PreviewSystem _previewSystem;
    private ObjectPlacer _objectPlacer;


    public PlacementState(int ıd, Grid grid, ObjectDatabaseSO objectDatabaseSo, GridData floorData,
        GridData furnitureData, PreviewSystem previewSystem, ObjectPlacer objectPlacer)
    {
        ID = ıd;
        _grid = grid;
        _objectDatabaseSo = objectDatabaseSo;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        _previewSystem = previewSystem;
        _objectPlacer = objectPlacer;
        
        _selectedObjectIndex = _objectDatabaseSo.ObjectDatas.FindIndex(data => data.Id == ID);
        if (_selectedObjectIndex > -1)
        {
            _previewSystem.StartShowingPlacementPreview(_objectDatabaseSo.ObjectDatas[_selectedObjectIndex].Prefab,
                _objectDatabaseSo.ObjectDatas[_selectedObjectIndex].Size);
        }
        else
            throw new SystemException($"No object with id {ID}");

    }

    public void EndState()
    {
        _previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPos)
    {
        bool placementValidity = CheckPlacementValidity(gridPos, _selectedObjectIndex);
        
        if (placementValidity == false) return;
        
        _objectPlacer.PlaceObject(_objectDatabaseSo.ObjectDatas[_selectedObjectIndex].Prefab, _grid.CellToWorld(gridPos));
        
        GetGridData(_selectedObjectIndex).AddObjectAt(gridPos,
            _objectDatabaseSo.ObjectDatas[_selectedObjectIndex].Size,
            _objectDatabaseSo.ObjectDatas[_selectedObjectIndex].Id,
            _objectPlacer.GetObjectCount());
        
        _previewSystem.UpdatePosition(_grid.CellToWorld(gridPos), false);
    }

    public bool CheckPlacementValidity(Vector3Int gridPos, int selectedObjectIndex)
    {
        return GetGridData(selectedObjectIndex).CanPlaceObjectAt(gridPos, _objectDatabaseSo.ObjectDatas[selectedObjectIndex].Size);
    }

    public GridData GetGridData(int selectedObjectIndex)
    {
        return _objectDatabaseSo.ObjectDatas[selectedObjectIndex].Id == 0 ? floorData : furnitureData;
    }

    public void UpdateState(Vector3Int gridPos)
    {
        bool placementValidity = CheckPlacementValidity(gridPos, _selectedObjectIndex);
        _previewSystem.UpdatePosition(_grid.CellToWorld(gridPos), placementValidity);
    }
}
