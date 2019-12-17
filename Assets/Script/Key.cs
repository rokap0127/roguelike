﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject[] shutter;
    public GameObject bridge;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bridge.SetActive(true);
            shutter[0].SetActive(false);
            shutter[1].SetActive(false);
        }
    }
}
