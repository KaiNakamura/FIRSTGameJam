using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Tiles tiles;
    public EnemySpawner enemySpawner;
    public Tower defaultTower;
    public HealthDisplay healthBar;
    public int health = 30;
    public MoneyDisplay moneyDisplay;
    public int money = 50;
    private Button normalButton;
    private Button vertButton;
    private Button delButton;
    private protected enum Mode { PLACE_TOWER, REMOVE_TOWER };
    private Mode selectedMode;
    private Tower selectedTower; // Selected tower that the Game Manager places 

    public float minX = -7.5f;
    
    void Start()
    {
        selectedTower = defaultTower;
        selectedMode = Mode.PLACE_TOWER;
    }

    void Update()
    {

        // End game
        for (int i = 0; i < enemySpawner.transform.childCount; i++)
        {
            Enemy currentEnemy = enemySpawner.transform.GetChild(i).gameObject.GetComponent<Enemy>();
            if (currentEnemy.transform.position.x < minX)
            {
                health--;
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
                                money++;
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if ((selectedMode == Mode.PLACE_TOWER && selectedTower.cost <= money) || selectedMode == Mode.REMOVE_TOWER)
            {
                // Place towers
                for (int i = 0; i < tiles.rows; i++)
                {
                    for (int j = 0; j < tiles.cols; j++)
                    {
                        Tile currentTile = tiles.GetTiles()[i, j];
                        Tower currentTower = currentTile.GetTower();
                        if (currentTile.isMouseOver())
                        {
                            if (selectedMode == Mode.PLACE_TOWER && currentTower == null)
                            {
                                Debug.Log("Placing Tower");
                                currentTower = Instantiate(
                                selectedTower,
                                    new Vector3(
                                        currentTile.transform.position.x,
                                        currentTile.transform.position.y,
                                        -1
                                    ),
                                    Quaternion.identity
                                ).GetComponent<Tower>();
                                currentTower.transform.SetParent(currentTile.transform);
                                currentTile.SetTower(currentTower);
                                money -= selectedTower.cost;

                                return;
                            }
                            else if (currentTower == null)
                            {
                                return;
                            }
                            else if (selectedMode == Mode.REMOVE_TOWER && currentTile.isMouseOver())
                            {
                                Destroy(currentTower.gameObject);
                                money += (int)((float) currentTower.cost * 0.8f);
                                return;
                            }
                        }
                    }
                }
            }
        }
        moneyDisplay.SetMoney(money);
        healthBar.SetHealth(health);
    }
    public void DeleteMode()
    {
        Debug.Log("Delete Mode");
        selectedMode = Mode.REMOVE_TOWER; 
    }

    public void SetSelectedTower(Tower tower)
    {
        Debug.Log("Selecting " + tower);
        selectedMode = Mode.PLACE_TOWER;
        selectedTower = tower;
    }
}
