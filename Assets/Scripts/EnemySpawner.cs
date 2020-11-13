using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 0.25f;
    public float increaseSpawnRate = 0.1f;
    private float counter = 0f;

    public Tiles tiles;
    public GameObject enemy;
    
    void Start()
    {
        tiles = (Tiles) GameObject.Find("Tiles").GetComponent(typeof(Tiles));
    }

    void Update()
    {
        if (counter >= 1 / spawnRate)
        {
            Vector3 position = this.transform.position;
            float[] spawnLocations = tiles.GetSpawnLocations();
            Enemy currentEnemy = Instantiate(
                enemy,
                new Vector3(
                    position.x,
                    spawnLocations[Random.Range(0, spawnLocations.Length)],
                    position.z
                ),
                Quaternion.identity
            ).GetComponent<Enemy>();
            currentEnemy.transform.SetParent(this.transform);

            counter = 0f;
        }

        counter += Time.deltaTime;
        spawnRate += Time.deltaTime * increaseSpawnRate;

    }
}
