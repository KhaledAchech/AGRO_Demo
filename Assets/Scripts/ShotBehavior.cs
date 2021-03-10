using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    
    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed;
    public float HitWithLaser;
    


    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
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
/*
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealthScript = other.transform.GetComponent<EnemyHealth>();
            enemyHealthScript.DeductHealth(HitWithLaser);
        }
    }
*/
    public void setTarget(Vector3 target)
    {
        m_target = target;
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