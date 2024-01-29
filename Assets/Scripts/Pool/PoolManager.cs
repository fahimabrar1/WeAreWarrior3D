using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int initialCopies = 10;
    public List<SoldierObjectPoolGameObject> poolList = new();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var data in GameManager.instance.LevelData.levelSoldiersData)
        {
            var obj = new GameObject("Pool");
            obj.transform.parent = transform;
            SoldierObjectPoolGameObject pool = new(data.soldierData.Prefab, initialCopies, obj.transform, data.soldierType);

            poolList.Add(pool);
        }
    }
}
