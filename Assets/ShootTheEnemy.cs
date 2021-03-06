using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTheEnemy : MonoBehaviour
{

    public float HitWithLaser = 10f; //=> the laser shots with the mouse button
    

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealthScript = other.transform.GetComponent<EnemyHealth>();
            enemyHealthScript.DeductHealth(HitWithLaser);
        }
    }
}
