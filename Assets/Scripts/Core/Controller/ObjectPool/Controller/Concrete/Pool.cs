using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public PoolType PoolType;
    public PoolObject PoolObjectPrefab;
    public Transform PoolParent;
    public int PoolSize;
    public Queue<GameObject> PoolQueue;

    public void Initialize()
    {
        PoolQueue = new Queue<GameObject>();
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject newPoolObject = GameObject.Instantiate(PoolObjectPrefab.gameObject, PoolParent);
            newPoolObject.SetActive(false);
            PoolQueue.Enqueue(newPoolObject);
        }
    }
        
    public GameObject GetPoolObject()
    {
        GameObject obj = PoolQueue.Dequeue();
        PoolObject poolObject = obj.GetComponent<PoolObject>();
        poolObject.OnGetPool();
        PoolQueue.Enqueue(obj);
        return obj;
    }
}
