using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open2 : MonoBehaviour
{
    GameObject iChecker;
    ItemChecker ic;
    public bool OpenFlag = false;
    public GameObject[] shutter;
    public GameObject[] bridge;
    public GameObject map;
    public Text TextHud;

    // Start is called before the first frame update
    void Start()
    {
        iChecker = GameObject.FindGameObjectWithTag("ItemChecker");
        ic = iChecker.GetComponent<ItemChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && OpenFlag && ic.KeyFlag)
        {
            bridge[0].SetActive(true);
            map.SetActive(true);
            shutter[0].SetActive(false);
            shutter[1].SetActive(false);
            TextHud.text = "扉を開けた！";
            Invoke("text", 5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Knight"||
               col.gameObject.tag == "Archer"||
               col.gameObject.tag == "Mage")
        {
            if(Operation.archerDead && Operation.mageDead||
               Operation.knightDead && Operation.mageDead||
               Operation.knightDead && Operation.mageDead)
            {
                OpenFlag = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight" ||
            collision.gameObject.tag == "Archer" ||
            collision.gameObject.tag == "Mage")
        {
            OpenFlag = false;
        }
    }
    void text()
    {
        TextHud.text = " ";
    }
}
