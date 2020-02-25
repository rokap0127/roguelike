using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController3: MonoBehaviour
{
    public GameObject camera0;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;
    public GameObject camera6;
    public GameObject camera7;
    public GameObject entrance1;
    public GameObject entrance2;
    public GameObject entrance3;
    public GameObject entrance4;
    public GameObject entrance5;
    public GameObject entrance6;
    public GameObject entrance7;
    public GameObject[] enemy;
    public GameObject shutter;

    GameObject operation;
    Operation op;
    GameObject knight;
    GameObject archer;
    GameObject mage;
    Vector2 pos;
    public GameObject boss;
    public GameObject bossPosition;
    // Start is called before the first frame update
    void Start()
    {
        operation = GameObject.FindGameObjectWithTag("Operation");
        op = operation.GetComponent<Operation>();
        knight = GameObject.FindGameObjectWithTag("Knight");
        archer = GameObject.FindGameObjectWithTag("Archer");
        mage = GameObject.FindGameObjectWithTag("Mage");
        camera1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Operation.knightFlag)
        {
            pos = knight.transform.position;
        }
        if (Operation.archerFlag)
        {
            pos = archer.transform.position;
        }
        if (Operation.mageFlag)
        {
            pos = mage.transform.position;
        }
        if (pos.y < entrance1.transform.position.y)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            enemy[1].SetActive(true);
            enemy[2].SetActive(false);
            enemy[3].SetActive(false);
            enemy[4].SetActive(false);
            enemy[5].SetActive(false);
            enemy[6].SetActive(false);
            enemy[7].SetActive(false);
        }
        if (pos.y > entrance1.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            enemy[1].SetActive(false);
            enemy[2].SetActive(false);
            enemy[3].SetActive(false);
            enemy[4].SetActive(true);
            enemy[5].SetActive(false);
            enemy[6].SetActive(false);
            enemy[7].SetActive(false);
        }
        if (pos.x < entrance2.transform.position.x && pos.y < entrance1.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(true);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            enemy[1].SetActive(false);
            enemy[2].SetActive(true);
            enemy[3].SetActive(false);
            enemy[4].SetActive(false);
            enemy[5].SetActive(false);
            enemy[6].SetActive(false);
            enemy[7].SetActive(false);
        }
        if (pos.x > entrance3.transform.position.x && pos.y < entrance1.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(true);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(false);
            enemy[1].SetActive(false);
            enemy[2].SetActive(false);
            enemy[3].SetActive(true);
            enemy[4].SetActive(false);
            enemy[5].SetActive(false);
            enemy[6].SetActive(false);
            enemy[7].SetActive(false);
        }
        if (pos.x < entrance4.transform.position.x && pos.y > entrance1.transform.position.y && pos.y < entrance6.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(true);
            camera6.SetActive(false);
            camera7.SetActive(false);
            enemy[1].SetActive(false);
            enemy[2].SetActive(false);
            enemy[3].SetActive(false);
            enemy[4].SetActive(false);
            enemy[5].SetActive(true);
            enemy[6].SetActive(false);
            enemy[7].SetActive(false);
        }
        if (pos.x > entrance5.transform.position.x && pos.y > entrance1.transform.position.y&& pos.y < entrance6.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(true);
            camera7.SetActive(false);
            enemy[1].SetActive(false);
            enemy[2].SetActive(false);
            enemy[3].SetActive(false);
            enemy[4].SetActive(false);
            enemy[5].SetActive(false);
            enemy[6].SetActive(true);
            enemy[7].SetActive(false);
        }
        if (pos.y > entrance6.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
            camera5.SetActive(false);
            camera6.SetActive(false);
            camera7.SetActive(true);
            enemy[1].SetActive(false);
            enemy[2].SetActive(false);
            enemy[3].SetActive(false);
            enemy[4].SetActive(false);
            enemy[5].SetActive(false);
            enemy[6].SetActive(false);
            enemy[7].SetActive(true);
            //Invoke("Shut", 0.5f);
        }
        if (pos.y > entrance7.transform.position.y)
        {
            if (!Operation.knightDead)
            {
                knight = GameObject.FindGameObjectWithTag("Knight");
                Knight kt = knight.GetComponent<Knight>();
                DataShare.knightHp = kt.playerHp;
                DataShare.knightMp = kt.playerMp;
            }
            else if (Operation.knightDead)
            {
                DataShare.knightHp = 0;
                DataShare.knightMp = 0;
            }
            if (!Operation.archerDead)
            {
                archer = GameObject.FindGameObjectWithTag("Archer");
                Archer ac = archer.GetComponent<Archer>();
                DataShare.archerHp = ac.playerHp;
                DataShare.archerMp = ac.playerMp;
            }
            if (Operation.archerDead)
            {
                DataShare.archerHp = 0;
                DataShare.archerMp = 0;
            }
            if (!Operation.mageDead)
            {
                mage = GameObject.FindGameObjectWithTag("Mage");
                Mage mg = mage.GetComponent<Mage>();
                DataShare.mageHp = mg.playerHp;
                DataShare.mageMp = mg.playerMp;
            }
            if (Operation.mageDead)
            {
                DataShare.mageHp = 0;
                DataShare.mageMp = 0;
            }
            SceneManager.LoadScene("Stage03");
        }
    }
    void Shut()
    {
        shutter.SetActive(true);
    }
}