﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBarrel : MonoBehaviour
{
    public Explotion explosionPrefab; //爆発エフェクト
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Knight" ||
            collision.gameObject.tag == "Archer" ||
            collision.gameObject.tag == "Mage")
        {
            Instantiate(
                explosionPrefab,
                collision.transform.position,
                Quaternion.identity);
            Destroy(gameObject);
        }
      
            
    }
}
