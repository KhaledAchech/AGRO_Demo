using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    void Awake()
    {
        
    }
    void Update()
    {
        CinemachineShake.Instance.ShakeCamera(1.2f,0.1f);
    }

}
