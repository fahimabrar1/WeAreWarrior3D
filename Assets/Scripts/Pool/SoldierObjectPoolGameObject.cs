using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class SoldierObjectPoolGameObject
{
    public GameObject prefab;
    public Transform parentTransform;
    public SoldierType soldierType;
    [SerializeField]
    public Queue<GameObject> objectQueue;
    private int v;
    private Transform transform;


    /// <summary>
    /// Initializes a new instance of the ObjectPool.
    /// </summary>
    /// <param name="prefab">The prefab of the object to be pooled.</param>
    /// <param name="initialSize">The initial size of the object pool.</param>
    /// <param name="parentTransform">Optional parent transform for pooled objects.</param>
    public SoldierObjectPoolGameObject(GameObject prefab, int initialSize = 100, Transform parentTransform = null, SoldierType soldierType = SoldierType.Foot)
    {
        this.prefab = prefab;
        this.parentTransform = parentTransform;
        this.soldierType = soldierType;
        objectQueue = new Queue<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            CreateAndEnqueueObject();
        }
    }



    /// <summary>
    /// Retrieves an object from the pool.
    /// </summary>
    /// <returns>The retrieved object.</returns>
    public GameObject DequeueObjectFromPool()
    {
        if (objectQueue.Count == 0)
        {
            CreateAndEnqueueObject();
        }

        GameObject obj = objectQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }
    /// <summary>
    /// Returns an object to the pool.
    /// </summary>
    /// <param name="obj">The object to be returned to the pool.</param>
    public void EnqueueObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectQueue.Enqueue(obj);
    }

    /// <summary>
    /// Creates a new object and adds it to the pool.
    /// </summary>
    private void CreateAndEnqueueObject()
    {
        GameObject obj = UnityEngine.Object.Instantiate(prefab, parentTransform);
        if (obj.TryGetComponent(out Soldier soldier))
        {
            soldier.pool = this;
        }
        EnqueueObjectToPool(obj);
    }
}
