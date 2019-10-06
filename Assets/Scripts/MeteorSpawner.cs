using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GildarGaming.LD45
{
    public class MeteorSpawner : MonoBehaviour
    {
        public static int spawnCount = 0;
        [SerializeField] GameObject meteorPrefab;
        float spawnTimer = 0f;
        [SerializeField] float spawnDelay = 3f;
        [SerializeField] Vector3 spawnLocation;
        [SerializeField] float minSpawnX;
        [SerializeField] float maxSpawnX;
        [SerializeField] float spawnY;
        [SerializeField] Vector3 spawnVelocity;
        void Start()
        {
            
        }


        void Spawn()
        {
            if (spawnCount > 300) return;
            spawnCount++;
            SetVelocityAndLocation();
            Instantiate(meteorPrefab, spawnLocation, Quaternion.identity);
            spawnTimer = 0;
        }

        void SetVelocityAndLocation()
        {
            spawnVelocity = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, -1f), 0f);
            spawnLocation = new Vector3(Random.Range(minSpawnX, maxSpawnX), spawnY, -5f);

        }
        // Update is called once per frame
        void Update()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnDelay)
            {
                Spawn();
            }
        }
    }

}
