using UnityEngine;
using VinoUtility;

namespace VinoUtility.Gameplay{
public class SpawnMachine : MonoBehaviour
{

    public SpawnModule spawnModule;
    public bool isSpawning;
    public float interval;
    public bool allowMultipleSpawn;
    float _lastGenerateTime;
    public Vector2 spawnRange;

    public bool spawnOnStart;
    public int singleSpawnCount = 1;

    private void Start() {
        if(spawnOnStart)
            Spawn();
        _lastGenerateTime = Time.time;
    }
    public void Spawn()
    {
        for(int i = 0; i < singleSpawnCount; i++)
        {
            SpawnOnce();
        }
    }

    #if UNITY_EDITOR
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(spawnRange.x/2, spawnRange.y/2, 0), new Vector3(spawnRange.x, spawnRange.y, 1));
    }
    #endif

    public void SpawnOnce()
    {
        if(allowMultipleSpawn)
        {    
            var prefabs = spawnModule.GetSpawnPrefabsByIndividualChance();
            foreach(var p in prefabs)
            {
                //TrashMan.spawn(p, GetRandomPositionInRange(), transform.rotation);
                Instantiate(p, GetRandomPositionInRange(), transform.rotation);
            }
        }
        else{
            var prefab = spawnModule.GetSpawnPrefabByChance();
            if(prefab != null)
                Instantiate(prefab, GetRandomPositionInRange(), transform.rotation);
                //TrashMan.spawn(prefab, transform.position, transform.rotation);
        }
    }
    public Vector2 GetRandomPositionInRange()
    {
        var x = Random.Range(transform.position.x, transform.position.x + spawnRange.x);
        var y = Random.Range(transform.position.y, transform.position.y + spawnRange.y);
        return new Vector2(x, y);
    }
    void Update()
    {
        if(!isSpawning)
            return;
        if(Time.time - _lastGenerateTime >= interval)
        {
            Spawn();
            _lastGenerateTime = Time.time;
        }
    }
}
}