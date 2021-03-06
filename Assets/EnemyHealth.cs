using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    public GameObject collisionExplosion;

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;
        Debug.Log(enemyHealth);
        if (enemyHealth <= 0) { EnemyDead();}
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
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }
}
