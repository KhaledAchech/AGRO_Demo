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
        Debug.Log(enemyHealth);
        if (enemyHealth <= 0) 
        { 
            enemyIsDead = true;
            EnemyDead();
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
            if (LockOnSysteme.enemiesOnScreen.Contains(gameObject)) { LockOnSysteme.enemiesOnScreen.Remove(gameObject); }
            LockOnSysteme.i = 0;
            LockOnSysteme lockoff = lockSystem.GetComponent<LockOnSysteme>();
            lockoff.turnOffSystem();
            ScoringSystem.Score += 50;
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }
}
