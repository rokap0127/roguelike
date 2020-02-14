using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher1 : MonoBehaviour
{
    public GameObject swich1;
    public GameObject swich2;
    public GameObject[] swich3;
    public GameObject bridge1;
    public GameObject[] bridge2;
    public GameObject hole1;
    public GameObject[] hole2;
    public GameObject[] wall;
    public GameObject lever;
    public int rnd;
    SwitchOn so;
    // Start is called before the first frame update
    void Start()
    {
        rnd = Random.Range(0, 2);
        so = GetComponent<SwitchOn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && so.OnFlag)
        {
            swich1.SetActive(false);
            swich2.SetActive(false);
            swich3[rnd].SetActive(true);
            bridge1.SetActive(true);
            bridge2[rnd].SetActive(true);
            hole1.SetActive(false);
            hole2[rnd].SetActive(false);
            wall[rnd].SetActive(true);
            lever.SetActive(true);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Knight"
    //        || collision.gameObject.tag == "Archer"
    //        || collision.gameObject.tag == "Mage")
    //    {
    //        swich1.SetActive(false);
    //        swich2.SetActive(false);
    //        swich3[rnd].SetActive(true);
    //        bridge1.SetActive(true);
    //        bridge2[rnd].SetActive(true);
    //        hole1.SetActive(false);
    //        hole2[rnd].SetActive(false);
    //        wall[rnd].SetActive(true);
    //        lever.SetActive(true);
    //    }
    //}
}
