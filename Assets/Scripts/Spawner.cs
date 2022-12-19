using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        
        public float spawnTime;
    }

    public SpawnableObject[] objects;

    public float minSpawn = 1f;
    public float maxSpawn = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawn, maxSpawn));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnTime = Random.value;

        foreach (var obj in objects)
        {
            if (spawnTime < obj.spawnTime)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnTime -= obj.spawnTime;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawn, maxSpawn));
    }

}
