using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tiles tiles;
    public EnemySpawner enemySpawner;
    public Tower tower;
    public Button button;

    private Button normalButton;
    private Button vertButton;
    private Button lobButton;

    public float minX = -7.5f;

    void Start()
    {
        normalButton = Instantiate(
            button,
            Constants.NORMAL_BUTTON_POSITION,
            Quaternion.identity
        ).GetComponent<Button>();
        normalButton.GetComponent<Renderer>().material.SetColor("_Color", Constants.NORMAL_COLOR);

        vertButton = Instantiate(
            button,
            Constants.VERT_BUTTON_POSITION,
            Quaternion.identity
        ).GetComponent<Button>();
        vertButton.GetComponent<Renderer>().material.SetColor("_Color", Constants.VERT_COLOR);

        lobButton = Instantiate(
            button,
            Constants.LOB_BUTTON_POSITION,
            Quaternion.identity
        ).GetComponent<Button>();
        lobButton.GetComponent<Renderer>().material.SetColor("_Color", Constants.LOB_COLOR);
    }

    void Update()
    {
        // End game
        for (int i = 0; i < enemySpawner.transform.childCount; i++)
        {
            Enemy currentEnemy = enemySpawner.transform.GetChild(i).gameObject.GetComponent<Enemy>();
            if (currentEnemy.transform.position.x < minX)
            {
                // TODO: remove health/end game
                Destroy(currentEnemy.gameObject);
            }
        }

        // Remove towers
        for (int i = 0; i < tiles.rows; i++)
        {
            for (int j = 0; j < tiles.cols; j++)
            {
                Tile currentTile = tiles.GetTiles()[i, j];
                Tower currentTower = currentTile.GetTower();
                if (currentTower != null)
                {
                    for (int k = 0; k < enemySpawner.transform.childCount; k++)
                    {
                        Enemy currentEnemy = enemySpawner.transform.GetChild(k).gameObject.GetComponent<Enemy>();
                        Collider2D enemyCollider = currentEnemy.GetComponent<Collider2D>();
                        Collider2D towerCollider = currentTower.GetComponent<Collider2D>();

                        // If tower collides with enemy, destroy tower and enemy
                        if (towerCollider.bounds.Intersects(enemyCollider.bounds))
                        {
                            Destroy(currentTower.gameObject);
                            Destroy(currentEnemy.gameObject);
                        }

                        // Loop through bullets
                        for (int l = 0; l < currentTower.transform.childCount; l++)
                        {
                            Bullet currentBullet = currentTower.transform.GetChild(l).gameObject.GetComponent<Bullet>();
                            Collider2D bulletCollider = currentBullet.GetComponent<Collider2D>();

                            // If bullet collides with enemy, destroy bullet and enemy
                            if (bulletCollider.bounds.Intersects(enemyCollider.bounds))
                            {
                                Destroy(currentBullet.gameObject);
                                Destroy(currentEnemy.gameObject);
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (normalButton.isMouseOver())
            {
                Debug.Log("NormalButton");
                tower.SetFireRate(Constants.NORMAL_FIRE_RATE);
                tower.SetSpeed(Constants.NORMAL_SPEED);
                tower.SetDamage(Constants.NORMAL_DAMAGE);
                tower.SetDistance(Constants.NORMAL_DISTANCE);
                tower.SetDirections(Constants.NORMAL_DIRECTIONS);
                tower.SetBulletBehavhior(Constants.NORMAL_BULLET_BEHAVHIOR);
                return;
            }
            else if (vertButton.isMouseOver())
            {
                Debug.Log("VertButton");
                tower.SetFireRate(Constants.VERT_FIRE_RATE);
                tower.SetSpeed(Constants.VERT_SPEED);
                tower.SetDamage(Constants.VERT_DAMAGE);
                tower.SetDistance(Constants.VERT_DISTANCE);
                tower.SetDirections(Constants.VERT_DIRECTIONS);
                tower.SetBulletBehavhior(Constants.VERT_BULLET_BEHAVHIOR);
                return;
            }
            else if (lobButton.isMouseOver())
            {
                Debug.Log("LobButton");
                tower.SetFireRate(Constants.LOB_FIRE_RATE);
                tower.SetSpeed(Constants.LOB_SPEED);
                tower.SetDamage(Constants.LOB_DAMAGE);
                tower.SetDistance(Constants.LOB_DISTANCE);
                tower.SetDirections(Constants.LOB_DIRECTIONS);
                tower.SetBulletBehavhior(Constants.LOB_BULLET_BEHAVHIOR);
                return;
            }

            // Place towers
            for (int i = 0; i < tiles.rows; i++)
            {
                for (int j = 0; j < tiles.cols; j++)
                {
                    Tile currentTile = tiles.GetTiles()[i, j];
                    if (currentTile.isMouseOver() && currentTile.GetTower() == null)
                    {
                        Tower currentTower = Instantiate(
                            tower,
                            new Vector3(
                                currentTile.transform.position.x,
                                currentTile.transform.position.y,
                                -1
                            ),
                            Quaternion.identity
                        ).GetComponent<Tower>();
                        currentTower.transform.SetParent(currentTile.transform);
                        currentTile.SetTower(currentTower);
                        return;
                    }
                }
            }

        }



        
    }
}
