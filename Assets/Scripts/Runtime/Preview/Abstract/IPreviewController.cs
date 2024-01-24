using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPreviewController
{
    void StartShowingPlacementPreview(GameObject prefab, Vector2Int size);
    void PreparePreviewObject(GameObject gameObject);
    void PrepareCursor(Vector2Int size);
    void StopShowingPreview();
    void MovePreview(Vector3 pos);
    void ApplyFeedbackToPreview(bool validity);
    void MoveCursor(Vector3 pos);
    void StartShowingRemovePreview();
    void ApplyFeedbackToRemove(bool validity);
}
