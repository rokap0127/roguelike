using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public GameObject bridge1;
    public GameObject bridge2;
    public GameObject bridge3;
    public GameObject bridge4;
    public GameObject hole1;
    public GameObject hole2;
    public GameObject hole3;
    public GameObject hole4;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            bridge1.SetActive(true);
            bridge2.SetActive(true);
            bridge3.SetActive(true);
            bridge4.SetActive(true);
            hole1.SetActive(false);
            hole2.SetActive(false);
            hole3.SetActive(false);
            hole4.SetActive(false);
            wall1.SetActive(true);
            wall2.SetActive(true);
            wall3.SetActive(true);
        }
    }
}
