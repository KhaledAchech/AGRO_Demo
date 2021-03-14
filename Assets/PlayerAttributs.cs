using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributs : MonoBehaviour
{
    [Header("HP Settings")]
    public float playerMaxHealth = 1000f;
    public GameObject collisionExplosion;

    public UIBarScript PlayerHpBar;
    public HealthBar HpBar;
    
    
    float playerHealth;

    public GameObject DeathExplosion;
    

    void Start()
    {
        playerHealth = playerMaxHealth;
        HpBar.setMaxHealthSlider((int)playerMaxHealth);
    }

    public void DeductHealth(float deductHealth)
    {
        
        playerHealth = playerHealth - deductHealth;

        int HP = (int)playerHealth;
		int MaxHP = (int)playerMaxHealth;
        
        PlayerHpBar.UpdateValue(HP,MaxHP);
        HpBar.setHealth(HP);
        //Debug.Log(playerHealth);
        if (playerHealth == 0) 
        { 
            PlayerDead();
            GameObject death = (GameObject)Instantiate( 
                DeathExplosion, transform.position, transform.rotation);
        }
    }

    void PlayerDead()
    {
        explode();
    }
    void explode()
    {
        if (collisionExplosion  != null) {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            ScoringSystem.Score = 0;
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }
}
