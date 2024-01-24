using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPlacer
{
    void PlaceObject(GameObject prefab, Vector3 pos);
    int GetObjectCount();
}
