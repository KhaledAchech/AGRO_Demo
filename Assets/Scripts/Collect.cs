using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
   public GameObject collectSound;


   void OnTriggerEnter(Collider other)
   {
        GameObject sound = (GameObject)Instantiate( 
                collectSound, transform.position, transform.rotation);
       Debug.Log("score !");
       ScoringSystem.Score += 10;
       Destroy(gameObject);
   }
}
