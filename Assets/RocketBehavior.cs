using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed;

     public float hitWithRocket = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float step = speed * Time.deltaTime;

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("am here on trigger");
        if (other.CompareTag("Enemy"))
        {   
            explode();
        }
    }
    void explode()
    {
        if (collisionExplosion  != null) {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            EnemyHealth enemyHealthScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
            if (enemyHealthScript)
            {enemyHealthScript.DeductHealth(hitWithRocket);}
            Debug.Log("am here");
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }
}
