using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher3 : MonoBehaviour
{
    public GameObject swich;
    public GameObject swich2;
    public GameObject bridge;
    public GameObject hole;
    public GameObject wall;
    public GameObject lever;
    public GameObject lever2;
    SwitchOn so;
    // Start is called before the first frame update
    void Start()
    {
        so = GetComponent<SwitchOn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && so.OnFlag)
        {
            swich.SetActive(false);
            swich2.SetActive(false);
            bridge.SetActive(true);
            hole.SetActive(false);
            wall.SetActive(true);
            lever.SetActive(true);
            lever2.SetActive(true);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Knight"
    //        || collision.gameObject.tag == "Archer"
    //        || collision.gameObject.tag == "Mage")
    //    {
    //        swich.SetActive(false);
    //        bridge.SetActive(true);
    //        hole.SetActive(false);
    //        wall.SetActive(true);
    //        lever.SetActive(true);
    //    }
    //}
}
