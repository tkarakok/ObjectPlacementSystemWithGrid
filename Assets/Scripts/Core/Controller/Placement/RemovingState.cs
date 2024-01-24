using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingState : IPlacementState
{
    private int _gameObjectIndex = -1;
    private Grid _grid;
    private ObjectDatabaseSO _objectDatabaseSo;
    private GridData floorData;
    private GridData furnitureData;
    private PreviewSystem _previewSystem;
    private ObjectPlacer _objectPlacer;
    
    
    public RemovingState(Grid grid, GridData floorData, GridData furnitureData, PreviewSystem previewSystem,
        ObjectPlacer objectPlacer)
    {
        _grid = grid;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        _previewSystem = previewSystem;
        _objectPlacer = objectPlacer;
        
        previewSystem.StartShowingRemovePreview();
    }

    public void EndState()
    {
        _previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPos)
    {
        GridData selectedData = null;
        if (furnitureData.CanPlaceObjectAt(gridPos, Vector2Int.one) == false)
        {
            selectedData = furnitureData;
        }
        else if (floorData.CanPlaceObjectAt(gridPos, Vector2Int.one) == false)
        {
            selectedData = floorData;
        }

        if (selectedData == null)
        {
            
        }
        else
        {
            _gameObjectIndex = selectedData.GetRepresentationIndex(gridPos);

            if (_gameObjectIndex == -1) return;
            selectedData.RemoveObjectAt(gridPos);
            _objectPlacer.RemoveObjectAt(_gameObjectIndex);
        }

        Vector3 cellPos = _grid.CellToWorld(gridPos);
        _previewSystem.UpdatePosition(cellPos, CheckIfSelectionIsValid(gridPos));
    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPos)
    {
        return !(furnitureData.CanPlaceObjectAt(gridPos, Vector2Int.one) &&
               floorData.CanPlaceObjectAt(gridPos, Vector2Int.one));
    }

    public bool CheckPlacementValidity(Vector3Int gridPos, int selectedObjectIndex)
    {
        throw new System.NotImplementedException();
    }

    public GridData GetGridData(int selectedObjectIndex)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState(Vector3Int gridPos)
    {
        bool validity = CheckIfSelectionIsValid(gridPos);
        _previewSystem.UpdatePosition(_grid.CellToWorld(gridPos), validity);
    }
}
