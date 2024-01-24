using UnityEngine;

public interface IPlacementState
{
    void EndState();
    void OnAction(Vector3Int gridPos);
    bool CheckPlacementValidity(Vector3Int gridPos, int selectedObjectIndex);
    GridData GetGridData(int selectedObjectIndex);
    void UpdateState(Vector3Int gridPos);
}