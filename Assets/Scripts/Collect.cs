using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
   //public AudioSource collectSound;

   void OnTriggerEnter(Collider other)
   {
       //collectSound.play();
       Debug.Log("score !");
       ScoringSystem.Score += 10;
       Destroy(gameObject);
   }
}
