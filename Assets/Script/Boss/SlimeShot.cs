﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShot : MonoBehaviour
{
    public GameObject miniSlime; //ミニスライム

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Wall"))
        {
            Destroy(gameObject);
            Instantiate(miniSlime, transform.position, Quaternion.identity);
        }
    }
}