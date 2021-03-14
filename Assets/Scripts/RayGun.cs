using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;

    RaycastHit hit;
    float range = 1000.0f;

    public float HitWithLaser = 25;

    public AudioSource LaserShot;
    public AudioSource LaserImpact;
    public AudioSource LaserImpactonWall;
    public AudioSource[] sounds;

    void Start()
    {
        sounds = GetComponents<AudioSource>();
        LaserShot = sounds[0];
        LaserImpact = sounds[1];
        LaserImpactonWall = sounds[2];
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        { 

            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();
                if(!LaserShot.isPlaying) LaserShot.Play();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }

    }

    void shootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range))
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
            if (hit.transform.tag == "Enemy")
            {
            LaserImpact.Play();
            CinemachineShake.Instance.ShakeCamera(0.8f,0.1f);
            EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
            enemyHealthScript.DeductHealth(HitWithLaser);
            }
            else
            {
                CinemachineShake.Instance.ShakeCamera(0.5f,0.1f);
                LaserImpactonWall.Play();
            }


        }

    }

}
