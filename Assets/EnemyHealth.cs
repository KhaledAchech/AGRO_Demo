using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth = 100f;
    public GameObject collisionExplosion;

    public UIBarScript EnemyHpBar;
    public HealthBar HpBar;
    
    float enemyHealth;

    void Start()
    {
        enemyHealth = enemyMaxHealth;
        HpBar.setMaxHealthSlider((int)enemyMaxHealth);
    }

    

    public void DeductHealth(float deductHealth)
    {
        enemyHealth = enemyHealth - deductHealth;

        int HP = (int)enemyHealth;
		int MaxHP = (int)enemyMaxHealth;
        
        EnemyHpBar.UpdateValue(HP,MaxHP);
        HpBar.setHealth(HP);
        Debug.Log(enemyHealth);
        if (enemyHealth == 0) 
        { 
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        explode();
    }
    void explode()
    {
        if (collisionExplosion  != null) {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            ScoringSystem.Score += 50;
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }
}
