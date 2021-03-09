using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnSysteme : MonoBehaviour
{

    bool locked;

    public GameObject MissleCrossHair;
    public GameObject CrossHair;
    
    Transform target;

    List<GameObject> enemiesInGame = new List<GameObject>();
    List<GameObject> enemiesOnScreen = new List<GameObject>();
    void Start()
    {
        MissleCrossHair.SetActive(false);
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in allEnemies)
        {
            enemiesInGame.Add(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInGame.Count > 0)
        {
            for (int i = 0; i < enemiesInGame.Count; i++)
            {
                Vector3 enemyPos = Camera.main.WorldToViewportPoint(enemiesInGame[i].transform.position);

                if (enemyPos.z > 0 && enemyPos.x > 0 && enemyPos.x < 1 && enemyPos.y > 0 && enemyPos.y < 1)
                {
                    enemiesOnScreen.Add(enemiesInGame[i]);
                }
                else if (enemiesOnScreen.Contains(enemiesInGame[i]))
                {
                    enemiesOnScreen.RemoveAt(i);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab) && !locked && enemiesOnScreen.Count > 0)
        {
            locked = true;
            MissleCrossHair.SetActive(true);
            CrossHair.SetActive(false);
            //disable gunMuzzles as well and enable Rocket Launcher 
        }

        if (locked)
        {
            target = enemiesOnScreen[0].transform;
        }
    }
}
