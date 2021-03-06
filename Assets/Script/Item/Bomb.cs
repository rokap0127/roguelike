﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Explotion explosionPrefab; //爆発エフェクト

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Invoke("Blast", 5.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(
            explosionPrefab,
            collision.transform.position,
            Quaternion.identity);
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            float pos = (transform.position - enemy.transform.position).magnitude;
            if (pos < 0.5f && pos > -0.5f)
            {
                Destroy(enemy);
            }
        }
        Destroy(gameObject);
    }
    void Blast()
    {
        Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity);
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            float pos = (transform.position - enemy.transform.position).magnitude;
            if (pos < 1.0f && pos > -1.0f)
            {
                Destroy(enemy);
            }
        }
        Destroy(gameObject);
    }
}
