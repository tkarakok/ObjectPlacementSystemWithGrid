using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSystem : MonoBehaviour, IPreviewController
{
    [SerializeField] private float _previewOffset = .06f;

    [SerializeField] private GameObject _cellIndicator;
    private GameObject _previewObject;

    [SerializeField] private Material _previewMaterialPrefab;
    private Material _previewMaterialInstance;

    private SpriteRenderer _cellIndicatorSpriteRenderer;
    
    private void Start()
    {
        _previewMaterialInstance = new Material(_previewMaterialPrefab);
        _cellIndicator.SetActive(false);
        _cellIndicatorSpriteRenderer = _cellIndicator.GetComponentInChildren<SpriteRenderer>();
    }

    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        _previewObject = Instantiate(prefab);
        PreparePreviewObject(_previewObject);
        PrepareCursor(size);
        _cellIndicator.SetActive(true);
    }

    public void PrepareCursor(Vector2Int size)
    {
        if (size.x > 0 || size.y > 0)
        {
            _cellIndicator.transform.localScale = new Vector3(size.x, 1, size.y);
            // _cellIndicator.GetComponentInChildren<SpriteRenderer>().color
        }
    }

    public void PreparePreviewObject(GameObject gameObject)
    {
        Renderer[] renderers = _previewObject.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = _previewMaterialInstance;
            }

            renderer.materials = materials;
        }
    }

    public void StopShowingPreview()
    {
        _cellIndicator.SetActive(false);
        if (_previewObject != null)
            Destroy(_previewObject);
    }

    public void UpdatePosition(Vector3 pos, bool validity)
    {
        if (_previewObject != null)
        {
            MovePreview(pos);
            ApplyFeedbackToPreview(validity);
        }
        MoveCursor(pos);
        ApplyFeedbackToRemove(validity);
    }

    public void MoveCursor(Vector3 pos)
    {
        _cellIndicator.transform.position = pos;
    }

    public void ApplyFeedbackToPreview(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        c.a = .5f;
        _previewMaterialInstance.color = c;
    }
    
    public void ApplyFeedbackToRemove(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        c.a = .5f;
        _cellIndicatorSpriteRenderer.color = c;
    }

    public void MovePreview(Vector3 pos)
    {
        _previewObject.transform.position = new Vector3(pos.x, pos.y + _previewOffset, pos.z);
    }

    public void StartShowingRemovePreview()
    {
        _cellIndicator.SetActive(true);
        PrepareCursor(Vector2Int.one);
        ApplyFeedbackToRemove(false);
    }
}
