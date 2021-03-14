﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootThePlayer : MonoBehaviour
{
       
    
    public GameObject collisionExplosion;
    public float speed;

    private Vector3 target;
    private Transform player;
    

    public float HitWithLaser = 1;

    public AudioSource LaserImpact;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        LaserImpact = GetComponent<AudioSource>();
        target = new Vector3(player.position.x, player.position.y, player.position.z);

        
    } 


    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        if (target != null)
        {
            if (transform.position == target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            LaserImpact.Play();
            /*PlayerAttributs playerHealth = other.GetComponent<PlayerAttributs>();
            Debug.Log("am here");
            playerHealth.DeductHealth(HitWithLaser);
            Debug.Log("am here now");*/
            explode();
            
        }
    }
    
    void explode()
    {
        if (collisionExplosion  != null) {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            PlayerAttributs playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributs>();
            //Debug.Log("am here");
            playerHealth.DeductHealth(HitWithLaser);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }

}
