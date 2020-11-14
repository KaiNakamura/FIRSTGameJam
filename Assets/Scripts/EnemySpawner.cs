using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using Mirror;

public class EnemySpawner : NetworkBehaviour
{
    public float spawnRate = 1f;
    private float counter = 0f;

    public GameObject enemyGameObject;
    
    public override void OnStartServer()
    {
        counter = 0f;
    }

    void Update()
    {
        if (counter >= spawnRate)
        {
            Vector3 position = this.transform.position;
            TileSpawner tileSpawner = FindObjectOfType<TileSpawner>();
            Enemy enemy = Instantiate(
                enemyGameObject,
                new Vector3(
                    position.x,
                    tileSpawner.spawnLocations[Random.Range(0, tileSpawner.spawnLocations.Length)],
                    position.z
                ),
                Quaternion.identity
            ).GetComponent<Enemy>();

            NetworkServer.Spawn(enemy.gameObject);

            counter = 0f;
        }

        counter += Time.deltaTime;
    }
}
