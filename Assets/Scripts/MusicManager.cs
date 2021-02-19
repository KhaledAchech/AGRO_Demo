using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private static MusicManager musicManagerInstance;

    // Awake is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        
        if (musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
