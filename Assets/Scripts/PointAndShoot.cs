﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public float depth = 10.0f;
    public float speed = 1.5f;
    Vector3 mousePos;
    Vector3 wantedPos;
    private void Start()
    {
        Cursor.visible = false;
        
    }
/*
    private Vector3 target;

    [Header("CrossHair Refrence")]
    public GameObject crossHairs;

    [Header("CrossHair Transform Refrence")]
    public Transform crossHair;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        crossHairs.transform.position = new Vector3(target.x, target.y, crossHair.position.z) ;
    }
    */
    private void Update()
    {
        toggleCursor();
        transform.position = Input.mousePosition; 
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void toggleCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
    }
}
