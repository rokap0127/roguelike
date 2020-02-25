using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LegendaryTreasure : MonoBehaviour
{
    GameObject knight;
    GameObject archer;
    GameObject mage;
    GameObject checker;
    bool OpenFlag=false;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Knight");
        archer = GameObject.FindGameObjectWithTag("Archer");
        mage = GameObject.FindGameObjectWithTag("Mage");
        checker = GameObject.FindGameObjectWithTag("ItemChecker");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && OpenFlag)
        {
            Destroy(knight);
            Destroy(checker);
            Destroy(mage);
            Destroy(archer);

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
