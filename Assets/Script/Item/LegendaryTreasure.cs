using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LegendaryTreasure : MonoBehaviour
{
    GameObject checker;
    GameObject operation;
    GameObject data;
    bool OpenFlag=false;
    // Start is called before the first frame update
    void Start()
    {
        checker = GameObject.FindGameObjectWithTag("ItemChecker");
        operation = GameObject.FindGameObjectWithTag("Operation");
        data = GameObject.FindGameObjectWithTag("Data");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && OpenFlag)
        {
            Destroy(operation);
            Destroy(checker);
            Destroy(data);

            SceneManager.LoadScene("GameClear");
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Knight" ||
               col.gameObject.tag == "Archer" ||
               col.gameObject.tag == "Mage")
        {
            OpenFlag = true;
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
}
