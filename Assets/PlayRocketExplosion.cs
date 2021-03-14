using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRocketExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource RocketExplosion;
    void Start()
    {
        RocketExplosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RocketExplosion.Play();
    }
}
