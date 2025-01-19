using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnInfo{
    public GameObject prefab;
    public int maxCount;
    public float chance;
}


[CreateAssetMenu(fileName = "SpawnModule", menuName = "SpawnModule", order = 0)]
public class SpawnModule : ScriptableObject {
    public List<SpawnInfo> spawnList;
    
    //按概率比例生成一个
    public GameObject GetSpawnPrefabByChance()
    {
        var r = UnityEngine.Random.value;
        for(int i = 0; i < spawnList.Count; i++)
        {
            if(r < spawnList[i].chance)
            {
                return spawnList[i].prefab;
            }
            r -= spawnList[i].chance;
        }
        return null;
    }

    //每个都独立按自己的概率生成,可一次生成多个
    public List<GameObject> GetSpawnPrefabsByIndividualChance()
    {
        var res = new List<GameObject>();
        for(int i = 0; i < spawnList.Count; i++)
        {
            var r = UnityEngine.Random.value;
            if(r < spawnList[i].chance)
            {
                res.Add(spawnList[i].prefab);
            }
        }
        return res;
    }

}