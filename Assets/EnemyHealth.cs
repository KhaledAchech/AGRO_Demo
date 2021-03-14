using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth = 100f;
    public GameObject collisionExplosion;
    public GameObject lockSystem;

    public UIBarScript EnemyHpBar;
    public HealthBar HpBar;
    
    float enemyHealth;

    public bool enemyIsDead;

    public float hitWithRocket = 50f;

    public GameObject EnemyExplosion;

    void Start()
    {
        enemyHealth = enemyMaxHealth;
        HpBar.setMaxHealthSlider((int)enemyMaxHealth);
        enemyIsDead = false;
    }

    void Update()
    {
        if (enemyIsDead)
        {
           
            explode();
        }
    }

    public void DeductHealth(float deductHealth)
    {
        enemyHealth = enemyHealth - deductHealth;

        int HP = (int)enemyHealth;
		int MaxHP = (int)enemyMaxHealth;
        
        EnemyHpBar.UpdateValue(HP,MaxHP);
        HpBar.setHealth(HP);
        //Debug.Log(enemyHealth);
        if (enemyHealth <= 0) 
        { 
            enemyIsDead = true;
            GameObject enemyExplosion = (GameObject)Instantiate(
                EnemyExplosion, transform.position, transform.rotation);
            EnemyDead();
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("am here on trigger EnemyScript");
        if (other.tag == "Rocket")
        {   
            Debug.Log("am here on trigger EnemyScript");
            DeductHealth(hitWithRocket);
            explode();
        }
    }

    
    void EnemyDead()
    {
        enemyIsDead = true;
        explode();
    }
    void explode()
    {
        if (collisionExplosion  != null) {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            LockOnSysteme.enemiesInGame.Remove(gameObject);
            if (LockOnSysteme.enemiesOnScreen.Contains(gameObject)) { LockOnSysteme.enemiesOnScreen.Remove(gameObject);}
            LockOnSysteme.i = 0;
            LockOnSysteme lockoff = lockSystem.GetComponent<LockOnSysteme>();
            lockoff.turnOffSystem();
            ScoringSystem.Score += 50;
            Destroy(gameObject);
            CinemachineShake.Instance.ShakeCamera(1.5f,0.01f);
            Destroy(explosion, 1f);
        }


    }
}
