using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher2: MonoBehaviour
{
    public GameObject swich1;
    public GameObject swich2;
    public GameObject bridge;
    public GameObject hole;
    public GameObject wall;
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
        if (collision.gameObject.tag == "Player")
        {
            swich1.SetActive(false);
            swich2.SetActive(true);
            bridge.SetActive(true);
            hole.SetActive(false);
            wall.SetActive(true);
        }
    }
}
