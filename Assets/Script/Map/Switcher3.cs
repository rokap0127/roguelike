using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher3 : MonoBehaviour
{
    public GameObject swich;
    public GameObject bridge;
    public GameObject hole;
    public GameObject wall;
    public GameObject lever;
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
        if (collision.gameObject.tag == "Knight"
            || collision.gameObject.tag == "Archer"
            || collision.gameObject.tag == "Mage")
        {
            swich.SetActive(false);
            bridge.SetActive(true);
            hole.SetActive(false);
            wall.SetActive(true);
            lever.SetActive(true);
        }
    }
}
