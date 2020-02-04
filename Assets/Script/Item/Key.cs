using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject[] shutter;
    public GameObject[] bridge;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Knight")
        {
            bridge[0].SetActive(true);
            bridge[1].SetActive(true);
            shutter[0].SetActive(false);
            shutter[1].SetActive(false);
            shutter[2].SetActive(false);
            shutter[3].SetActive(false);
        }
        if (collision.gameObject.tag == "Archer")
        {
            bridge[0].SetActive(true);
            bridge[1].SetActive(true);
            shutter[0].SetActive(false);
            shutter[1].SetActive(false);
            shutter[2].SetActive(false);
            shutter[3].SetActive(false);
        }
        if (collision.gameObject.tag == "Mage")
        {
            bridge[0].SetActive(true);
            bridge[1].SetActive(true);
            shutter[0].SetActive(false);
            shutter[1].SetActive(false);
            shutter[2].SetActive(false);
            shutter[3].SetActive(false);
        }
    }
}
