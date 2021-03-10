using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    [Header("Setup")]
    public GameObject lockOnSystemeScript;
    //public Rigidbody RocketRgb;
    public GameObject m_shotPrefab;
   

    Vector3 rocketTarget;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        LockOnSysteme lockOnSystem = lockOnSystemeScript.GetComponent<LockOnSysteme>();
        rocketTarget = lockOnSystem.target.position;
        if (Input.GetMouseButtonDown(0))
        {
            launchRocket();
        }

    }

    void launchRocket()
    {
        GameObject rocket = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
        rocket.GetComponent<RocketBehavior>().setTarget(rocketTarget);
        Debug.Log("Rocket Hit");
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            /*EnemyHealth enemyHealthScript = collision.transform.GetComponent<EnemyHealth>();
            enemyHealthScript.DeductHealth(hitWithRocket);
            //Deactivate Rocket..
            Destroy(gameObject);
        }
    }*/

    /* void OnTriggerEnter(Collider other) 
    {
        Debug.Log("am here on trigger");
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealthScript = other.transform.GetComponent<EnemyHealth>();
            enemyHealthScript.DeductHealth(hitWithRocket);
            Debug.Log("am here");
            //Deactivate Rocket..
            Destroy(gameObject);
            
        }
    }*/
    
}
