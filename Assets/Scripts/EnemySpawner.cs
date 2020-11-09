using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 1f;
    private float counter = 0f;
    public Tiles tiles;
    public GameObject enemy;
    
    void Start()
    {
        tiles = (Tiles) GameObject.Find("Tiles").GetComponent(typeof(Tiles));
    }

    void Update()
    {
        if (counter >= spawnRate)
        {
            Vector3 position = this.transform.position;
            float[] spawnLocations = tiles.getSpawnLocations();
            Instantiate(
                enemy,
                new Vector3(
                    position.x,
                    spawnLocations[Random.Range(0, spawnLocations.Length)],
                    position.z
                ),
                Quaternion.identity
            ).transform.SetParent(this.transform);

            counter = 0f;
        }

        counter += Time.deltaTime;
    }
}
