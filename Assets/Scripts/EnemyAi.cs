using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CodeMonkey.Utils;

public class EnemyAi : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Vector3 ofset;

    public float timeBtwShots;
    public float startTimeBtwShots;
    

    public GameObject projectile;
    public Transform player;

    public AudioSource LeaserShot;


    private bool shoot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
        shoot = true;
        LeaserShot = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position + ofset, speed * Time.deltaTime);
            shoot = true;
        }
        else if (Vector3.Distance(transform.position, player.position) > stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            shoot = false;
        }
        else if (Vector3.Distance(transform.position, player.position)  < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            shoot = true;
        }

        if (timeBtwShots <= 0 && shoot)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            LeaserShot.Play();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
