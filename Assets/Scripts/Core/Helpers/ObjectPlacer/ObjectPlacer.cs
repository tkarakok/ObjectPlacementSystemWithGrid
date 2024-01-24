using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour, IObjectPlacer
{
    private List<GameObject> _placedObjects = new List<GameObject>();
    
    
    
    public void PlaceObject(GameObject prefab, Vector3 pos)
    {
        GameObject createdObject = Instantiate(prefab);
        createdObject.transform.position = pos;
        _placedObjects.Add(createdObject);
    }

    public int GetObjectCount()
    {
        return _placedObjects.Count - 1;
    }

    public void RemoveObjectAt(int gameObjectIndex)
    {
        if (_placedObjects.Count <= gameObjectIndex) return;
        Destroy(_placedObjects[gameObjectIndex]);
        _placedObjects[gameObjectIndex] = null;

    }
}
