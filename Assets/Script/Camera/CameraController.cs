using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject[] sceneCamera;
    public GameObject[] entrance;
    public GameObject enemy;
    GameObject operation;
    Operation op;
    GameObject knight;
    GameObject archer;
    GameObject mage;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        operation = GameObject.FindGameObjectWithTag("Operation");
        op = operation.GetComponent<Operation>();
        sceneCamera[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Operation.knightFlag)
        {
            knight = GameObject.FindGameObjectWithTag("Knight");
            pos = knight.transform.position;
        }
        if (Operation.archerFlag)
        {
            archer = GameObject.FindGameObjectWithTag("Archer");
            pos = archer.transform.position;
        }
        if (Operation.mageFlag)
        {
            mage = GameObject.FindGameObjectWithTag("Mage");
            pos = mage.transform.position;
        }
        if (pos.y < entrance[0].transform.position.y)
        {
            sceneCamera[1].SetActive(true);
            sceneCamera[2].SetActive(false);
            sceneCamera[3].SetActive(false);
            enemy.SetActive(false);
        }
        if (pos.y > entrance[0].transform.position.y&& pos.y < entrance[1].transform.position.y)
        {
            sceneCamera[1].SetActive(false);
            sceneCamera[2].SetActive(true);
            sceneCamera[3].SetActive(false);
            enemy.SetActive(true);
        }
        if (pos.y > entrance[1].transform.position.y)
        {
            sceneCamera[1].SetActive(false);
            sceneCamera[2].SetActive(false);
            sceneCamera[3].SetActive(true);
            enemy.SetActive(false);
        }
        //if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))
        //{
        //    sceneCamera[0].SetActive(true);
        //    sceneCamera[1].SetActive(false);
        //    sceneCamera[2].SetActive(false);
        //    sceneCamera[3].SetActive(false);
        //    sceneCamera[4].SetActive(false);
        //    sceneCamera[5].SetActive(false);
        //    sceneCamera[6].SetActive(false);
        //    sceneCamera[7].SetActive(false);
        //}
        //if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl))
        //{
        //    sceneCamera[0].SetActive(false);
        //}
        if (pos.y > entrance[5].transform.position.y)
        {
            if (!Operation.knightDead)
            {
                knight = GameObject.FindGameObjectWithTag("Knight");
                Knight kt = knight.GetComponent<Knight>();
                DataShare.knightHp = kt.playerHp;
                DataShare.knightMp = kt.playerMp;
            }
            if (!Operation.archerDead)
            {
                archer = GameObject.FindGameObjectWithTag("Archer");
                Archer ac = archer.GetComponent<Archer>();
                DataShare.archerHp = ac.playerHp;
                DataShare.archerMp = ac.playerMp;
            }
            if (!Operation.mageDead)
            {
                mage = GameObject.FindGameObjectWithTag("Mage");
                Mage mg = mage.GetComponent<Mage>();
                DataShare.mageHp = mg.playerHp;
                DataShare.mageMp = mg.playerMp;
            }
            SceneManager.LoadScene("Stage02");
        }
        if (pos.x > entrance[6].transform.position.x)
        {
            if (!Operation.knightDead)
            {
                knight = GameObject.FindGameObjectWithTag("Knight");
                Knight kt = knight.GetComponent<Knight>();
                DataShare.knightHp = kt.playerHp;
                DataShare.knightMp = kt.playerMp;
            }
            if (!Operation.archerDead)
            {
                archer = GameObject.FindGameObjectWithTag("Archer");
                Archer ac = archer.GetComponent<Archer>();
                DataShare.archerHp = ac.playerHp;
                DataShare.archerMp = ac.playerMp;
            }
            if (!Operation.mageDead)
            {
                mage = GameObject.FindGameObjectWithTag("Mage");
                Mage mg = mage.GetComponent<Mage>();
                DataShare.mageHp = mg.playerHp;
                DataShare.mageMp = mg.playerMp;
            }
            SceneManager.LoadScene("Stage02");
        }
    }
}