using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    private Dictionary<Vector3Int, PlacementData> _placedObjects = new();

    public void AddObjectAt(Vector3Int gridPos, Vector2Int objectSize, int ID, int placedObjectIndex)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPos, objectSize);
        PlacementData placementData = new PlacementData(positionToOccupy, ID, placedObjectIndex);
        foreach (var pos in positionToOccupy)
        {
            if (_placedObjects.ContainsKey(pos))
            {
                throw new Exception($"Dictionary already contains this cell position {pos}");
            }

            _placedObjects[pos] = placementData;
        }
    }

    private List<Vector3Int> CalculatePositions(Vector3Int gridPos, Vector2Int objectSize)
    {
        List<Vector3Int> returnVal = new();
        for (int i = 0; i < objectSize.x; i++)
        {
            for (int j = 0; j < objectSize.y; j++)
            {
                returnVal.Add(gridPos + new Vector3Int(i, 0, j));
            }
        }

        return returnVal;
    }

    public bool CanPlaceObjectAt(Vector3Int gridPos, Vector2Int objectSize)
    {
        List<Vector3Int> positionOccupy = CalculatePositions(gridPos, objectSize);
        foreach (var pos in positionOccupy)
        {
            if (_placedObjects.ContainsKey(pos))
            {
                return false;
            }
        }

        return true;
    }

    public int GetRepresentationIndex(Vector3Int gridPos)
    {
        if (_placedObjects.ContainsKey(gridPos) == false)
        {
            return -1;
        }

        return _placedObjects[gridPos].PlacedObjectIndex;
    }

    public void RemoveObjectAt(Vector3Int gridPos)
    {
        foreach (var position in _placedObjects[gridPos].occupiedPositions)
        {
            _placedObjects.Remove(position);
        }
    }
}

public class PlacementData
{
    public PlacementData(List<Vector3Int> occupiedPositions, int ıd, int placedObjectIndex)
    {
        this.occupiedPositions = occupiedPositions;
        ID = ıd;
        PlacedObjectIndex = placedObjectIndex;
    }

    public List<Vector3Int> occupiedPositions;
    public int ID { get; private set; }
    public int PlacedObjectIndex { get; private set; }
}