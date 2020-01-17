using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController2 : MonoBehaviour
{
    public GameObject[] sceneCamera;
    public GameObject[] entrance;
    public GameObject[] enemy;
    int enemynum;
    public int enemylim;
    bool callEnemy1;
    bool callEnemy2;
    bool callEnemy3;
    bool callEnemy4;
    bool callEnemy5;
    bool callEnemy6;
    public GameObject[] item;
    public GameObject[] rareItem;
    public int itemlim;
    int itemnum;
    int rareItemnum;
    public GameObject[] gimmick;
    int gimmicknum;
    public int gimmicklim;

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
        if(op.knightFlag)
        {
            knight = GameObject.FindGameObjectWithTag("Knight");
            pos = knight.transform.position;
        }
        if(op.archerFlag)
        {
            archer = GameObject.FindGameObjectWithTag("Archer");
            pos = archer.transform.position;
        }
        if(op.mageFlag)
        {
            mage = GameObject.FindGameObjectWithTag("Mage");
            pos = mage.transform.position;
        }
        if (pos.x < entrance[0].transform.position.x)
        {
            sceneCamera[1].SetActive(true);
            sceneCamera[2].SetActive(false);
            sceneCamera[3].SetActive(false);
            sceneCamera[4].SetActive(false);
            sceneCamera[5].SetActive(false);
            sceneCamera[6].SetActive(false);
            sceneCamera[7].SetActive(false);
        }
        if (pos.x > entrance[0].transform.position.x&& pos.y < entrance[1].transform.position.y)
        {
            sceneCamera[1].SetActive(false);
            sceneCamera[2].SetActive(true);
            sceneCamera[3].SetActive(false);
            sceneCamera[4].SetActive(false);
            sceneCamera[5].SetActive(false);
            sceneCamera[6].SetActive(false);
            sceneCamera[7].SetActive(false);
            if (!callEnemy1)
            {
                int i = 0;
                itemnum = Random.Range(0, 3);
                itemlim = Random.Range(3, 8);
                while (i < itemlim)
                {
                    if (itemnum >= 2)
                    {
                        rareItemnum = Random.Range(0, 5);
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int g = 0;
                gimmicknum = Random.Range(0, 2);
                gimmicklim = Random.Range(0, 3);
                while (g < gimmicklim)
                {
                    Instantiate(gimmick[gimmicknum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                    gimmicknum = Random.Range(0, 2);
                    g++;
                }
                callEnemy1 = true;
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy1 = true;
            }
        }
        if (pos.y > entrance[1].transform.position.y && pos.x > entrance[0].transform.position.x&&pos.x< entrance[2].transform.position.x)
        {
            sceneCamera[1].SetActive(false);
            sceneCamera[2].SetActive(false);
            sceneCamera[3].SetActive(true);
            sceneCamera[4].SetActive(false);
            sceneCamera[5].SetActive(false);
            sceneCamera[6].SetActive(false);
            sceneCamera[7].SetActive(false);
            if (!callEnemy2)
            {
                int i = 0;
                itemnum = Random.Range(0, 3);
                itemlim = Random.Range(3, 8);
                while (i < itemlim)
                {
                    if (itemnum >= 2)
                    {
                        rareItemnum = Random.Range(0, 5);
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(0.1f, 2.3f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(0.1f, 2.3f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int g = 0;
                gimmicknum = Random.Range(0, 2);
                gimmicklim = Random.Range(0, 3);
                while (g < gimmicklim)
                {
                    Instantiate(gimmick[gimmicknum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(0.1f, 2.3f), 0), transform.rotation);
                    gimmicknum = Random.Range(0, 2);
                    g++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(0.1f, 2.3f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy2 = true;
            }
        }
        if (pos.x > entrance[2].transform.position.x)
        {
            sceneCamera[1].SetActive(false);
            sceneCamera[2].SetActive(false);
            sceneCamera[3].SetActive(false);
            sceneCamera[4].SetActive(true);
            sceneCamera[5].SetActive(false);
            sceneCamera[6].SetActive(false);
            sceneCamera[7].SetActive(false);
            if (!callEnemy3)
            {
                int i = 0;
                itemnum = Random.Range(0, 3);
                itemlim = Random.Range(3, 8);
                while (i < itemlim)
                {
                    if (itemnum >= 2)
                    {
                        rareItemnum = Random.Range(0, 5);
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(3.3f, 10.4f), Random.Range(-4.0f, -0.5f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(3.3f, 10.4f), Random.Range(-4.0f, -0.5f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int g = 0;
                gimmicknum = Random.Range(0, 2);
                gimmicklim = Random.Range(0, 3);
                while (g < gimmicklim)
                {
                    Instantiate(gimmick[gimmicknum], new Vector3(Random.Range(3.3f, 10.4f), Random.Range(-4.0f, -0.5f), 0), transform.rotation);
                    gimmicknum = Random.Range(0, 2);
                    g++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(3.3f, 10.4f), Random.Range(-4.0f, -0.5f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy3 = true;
            }
        }
        if (pos.x > entrance[2].transform.position.x && pos.y > entrance[3].transform.position.y)
        {
            sceneCamera[1].SetActive(false);
            sceneCamera[2].SetActive(false);
            sceneCamera[3].SetActive(false);
            sceneCamera[4].SetActive(false);
            sceneCamera[5].SetActive(true);
            sceneCamera[6].SetActive(false);
            sceneCamera[7].SetActive(false);
            if (!callEnemy4)
            {
                int i = 0;
                itemnum = Random.Range(0, 3);
                itemlim = Random.Range(3, 8);
                while (i < itemlim)
                {
                    if (itemnum >= 2)
                    {
                        rareItemnum = Random.Range(0, 5);
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(4.3f, 9.4f), Random.Range(1.1f, 3.6f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(4.3f, 9.4f), Random.Range(1.1f, 3.6f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int g = 0;
                gimmicknum = Random.Range(0, 2);
                gimmicklim = Random.Range(0, 3);
                while (g < gimmicklim)
                {
                    Instantiate(gimmick[gimmicknum], new Vector3(Random.Range(4.3f, 9.4f), Random.Range(1.1f, 3.6f), 0), transform.rotation);
                    gimmicknum = Random.Range(0, 2);
                    g++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(4.3f, 9.4f), Random.Range(1.1f, 3.6f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy4 = true;
            }
        }
        if (pos.y > entrance[1].transform.position.y && pos.x < entrance[0].transform.position.x)
        {
            sceneCamera[1].SetActive(false);
            sceneCamera[2].SetActive(false);
            sceneCamera[3].SetActive(false);
            sceneCamera[4].SetActive(false);
            sceneCamera[5].SetActive(false);
            sceneCamera[6].SetActive(true);
            sceneCamera[7].SetActive(false);
            if (!callEnemy5)
            {
                int i = 0;
                itemnum = Random.Range(0, 3);
                itemlim = Random.Range(3, 8);
                while (i < itemlim)
                {
                    if (itemnum >= 2)
                    {
                        rareItemnum = Random.Range(0, 5);
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-0.1f, 2.3f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-0.1f, 2.3f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int g = 0;
                gimmicknum = Random.Range(0, 2);
                gimmicklim = Random.Range(0, 3);
                while (g < gimmicklim)
                {
                    Instantiate(gimmick[gimmicknum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-0.1f, 2.3f), 0), transform.rotation);
                    gimmicknum = Random.Range(0, 2);
                    g++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-0.1f, 2.3f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy5 = true;
            }
        }
        if (pos.y > entrance[4].transform.position.y && pos.x < entrance[1].transform.position.x)
        {
            sceneCamera[1].SetActive(false);
            sceneCamera[2].SetActive(false);
            sceneCamera[3].SetActive(false);
            sceneCamera[4].SetActive(false);
            sceneCamera[5].SetActive(false);
            sceneCamera[6].SetActive(false);
            sceneCamera[7].SetActive(true);
            if (!callEnemy6)
            {
                int i = 0;
                itemnum = Random.Range(0, 3);
                itemlim = Random.Range(3, 8);
                while (i < itemlim)
                {
                    if (itemnum >= 2)
                    {
                        rareItemnum = Random.Range(0, 5);
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(-12.3f, -5.25f), Random.Range(3.8f, 7.15f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(-12.3f, -5.25f), Random.Range(3.8f, 7.15f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int g = 0;
                gimmicknum = Random.Range(0, 2);
                gimmicklim = Random.Range(0, 3);
                while (g < gimmicklim)
                {
                    Instantiate(gimmick[gimmicknum], new Vector3(Random.Range(-12.3f, -5.25f), Random.Range(3.8f, 7.15f), 0), transform.rotation);
                    gimmicknum = Random.Range(0, 2);
                    g++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(3, 8);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(-12.3f, -5.25f), Random.Range(3.8f, 7.15f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy6 = true;
            }
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
            SceneManager.LoadScene("Stage03");
        }
        if (pos.x > entrance[6].transform.position.x)
        {
            SceneManager.LoadScene("Stage03");
        }
    }
}