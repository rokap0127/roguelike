using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher1 : MonoBehaviour
{
    public GameObject swich1;
    public GameObject swich3;
    public GameObject bridge1;
    public GameObject bridge2;
    public GameObject hole1;
    public GameObject hole2;
    public GameObject wall;
    public GameObject lever;
    SwitchOn so;
    // Start is called before the first frame update
    void Start()
    {
        so = GetComponent<SwitchOn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && so.OnFlag)
        {
            swich1.SetActive(false);
            swich3.SetActive(true);
            bridge1.SetActive(true);
            bridge2.SetActive(true);
            hole1.SetActive(false);
            hole2.SetActive(false);
            wall.SetActive(true);
            lever.SetActive(true);
        }
    }
}
