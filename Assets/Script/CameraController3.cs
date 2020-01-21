using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bool callEnemy1;
    bool callEnemy2;
    bool callEnemy3;
    bool callEnemy4;
    bool callEnemy5;
    public GameObject[] enemy;
    int enemynum;
    public int enemylim;
    public GameObject[] item;
    public GameObject[] rareItem;
    public int itemlim;
    int itemnum;
    int rareItemnum;
    public GameObject shutter;

    GameObject operation;
    Operation op;
    GameObject knight;
    GameObject archer;
    GameObject mage;
    Vector2 pos;
    public GameObject boss;
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
            if (!callEnemy1)
            {
                int i = 0;
                itemnum = Random.Range(0, 3);
                itemlim = Random.Range(3,8);
                while (i < itemlim)
                {
                    if(itemnum >= 2)
                    {
                       rareItemnum = Random.Range(0, 5);
                       Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(-8.8f, -3.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(-8.8f, -3.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0,3);
                    i++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(-8.8f, -3.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy1 = true;
            }
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
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(4.6f, 9.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(4.6f, 9.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(4.6f, 9.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy2 = true;
            }
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
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(-9.1f, -4.0f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(-9.1f, -4.0f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(-9.1f, -4.0f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy3 = true;
            }
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
            if (!callEnemy4)
            {
                int i = 0;
                itemnum = Random.Range(0, 2);
                itemlim = Random.Range(3, 8);
                while (i < itemlim)
                {
                    if (itemnum >= 2)
                    {
                        rareItemnum = Random.Range(0, 5);
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(5.0f, 10.1f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(5.0f, 10.1f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 5);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(5.0f, 10.1f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy4 = true;
            }
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
            if (!callEnemy5)
            {
                int i = 0;
                itemnum = Random.Range(0, 3);
                itemlim = Random.Range(10, 21);
                while (i < itemlim)
                {
                    if (itemnum == 2)
                    {
                        rareItemnum = Random.Range(0, 5);
                        Instantiate(rareItem[rareItemnum], new Vector3(Random.Range(-4.3f, 5.4f), Random.Range(2.0f, 6.2f), 0), transform.rotation);
                    }
                    else
                    {
                        Instantiate(item[itemnum], new Vector3(Random.Range(-4.3f, 5.4f), Random.Range(2.0f, 6.2f), 0), transform.rotation);
                    }
                    itemnum = Random.Range(0, 3);
                    i++;
                }
                Instantiate(boss, new Vector3(0.2f, 2.7f, 0), transform.rotation);
                callEnemy5 = true;
            }
            //Invoke("Shut", 0.5f);
        }
        //if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))
        //{
        //    camera0.SetActive(true);
        //    camera1.SetActive(false);
        //    camera2.SetActive(false);
        //    camera3.SetActive(false);
        //    camera4.SetActive(false);
        //    camera5.SetActive(false);
        //    camera6.SetActive(false);
        //    camera7.SetActive(false);
        //}
        //if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl))
        //{
        //    camera0.SetActive(false);
        //}
    }
    void Shut()
    {
        shutter.SetActive(true);
    }
}