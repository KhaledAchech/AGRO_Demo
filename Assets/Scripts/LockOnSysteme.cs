using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnSysteme : MonoBehaviour
{

    public bool locked;

    public GameObject MissleCrossHair;
    public GameObject CrossHair;
    public GameObject gunMuzzles;
    public GameObject RocketLauncher;

    public GameObject SpawnEffect;
    //public Transform SpawnPosition;
    public float timeToWait;
    
    public Transform target;

    public static List<GameObject> enemiesInGame = new List<GameObject>();
    public static List<GameObject> enemiesOnScreen = new List<GameObject>();

    public static int i = 0;

    void Start()
    {
        MissleCrossHair.SetActive(false);
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in allEnemies)
        {
            enemiesInGame.Add(e);
        }
    }

    IEnumerator ExecuteAfterTime(float timeToWait)
    {
        
        yield return new WaitForSeconds(timeToWait);
     // Code to execute after the delay
        gunMuzzles.SetActive(false);
        RocketLauncher.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        try{
        if (enemiesInGame.Count > 0)
        {
           
            for (int i = 0; i < enemiesInGame.Count; i++)
            {
                Vector3 enemyPos = Camera.main.WorldToViewportPoint(enemiesInGame[i].transform.position);

                bool isOnScreen = (enemyPos.z > 0 && enemyPos.x > 0 && enemyPos.x < 1 && enemyPos.y > 0 && enemyPos.y < 1) ?true:false;

                if (isOnScreen && !enemiesOnScreen.Contains(enemiesInGame[i]))
                {
                        enemiesOnScreen.Add(enemiesInGame[i]);
                }
                else if (enemiesOnScreen.Contains(enemiesInGame[i]) && !isOnScreen)
                {
                    locked = false;
                    enemiesOnScreen.Remove(enemiesInGame[i]);
                    target = null;
                    MissleCrossHair.SetActive(false);
                    CrossHair.SetActive(true);
                    gunMuzzles.SetActive(true);
                    RocketLauncher.SetActive(false);
                }
                }
            }
            }
            catch (System.IndexOutOfRangeException ex)  // CS0168
                {
                    Debug.Log("Index Error");
                }
            
        
        if (Input.GetKeyDown(KeyCode.Space) && !locked && enemiesOnScreen.Count > 0)
        {
            //SpawnEffect.SetActive(true);
            //StartCoroutine(ExecuteAfterTime(timeToWait));
            i = 0;
            locked = true;
            MissleCrossHair.SetActive(true);
            CrossHair.SetActive(false);
            SpawnEffect.SetActive(true);
            StartCoroutine(ExecuteAfterTime(timeToWait));
            //gunMuzzles.SetActive(false);
            //RocketLauncher.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && locked)
        {
            locked = false;
            i = 0;
            target = null;
            MissleCrossHair.SetActive(false);
            CrossHair.SetActive(true);
            gunMuzzles.SetActive(true);
            RocketLauncher.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab) && locked)
        {
            if (enemiesOnScreen.Count > 0)
            {
                try
                {
                   i++;
                }
                catch (System.IndexOutOfRangeException ex)  // CS0168
                {
                    Debug.Log("Index Error");
                }
                try
                {
                    if (i >= enemiesOnScreen.Count)
                    {
                        i = 0;
                    } 

                }
                catch (System.IndexOutOfRangeException ex)
                {
                    
                    Debug.Log("Index Error");
                }
               
            }
        }

        if (locked)
        {
            try
            {
                target = enemiesOnScreen[i].transform;
                MissleCrossHair.transform.position = Camera.main.WorldToScreenPoint(target.position);
            }
            catch (System.IndexOutOfRangeException ex)  // CS0168
            {
                    Debug.Log("Index Error");
            }
            
        }
        /*else
        {
            target = null;
            MissleCrossHair.SetActive(false);
            CrossHair.SetActive(true);
            gunMuzzles.SetActive(true);
            RocketLauncher.SetActive(false);
        }*/
    }

    public void turnOffSystem()
    {
        if (locked)
            {
                locked = false;
                target = null;
                i = 0;
                MissleCrossHair.SetActive(false);
                CrossHair.SetActive(true);
                gunMuzzles.SetActive(true);
                RocketLauncher.SetActive(false);
            }
    }
}
