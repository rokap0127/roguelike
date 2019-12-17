using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager3 : MonoBehaviour
{
    public GameObject player;
    public GameObject[] map;
    public GameObject[] shutter;
    public GameObject[] bridge;
    public GameObject[] hole;
    public GameObject[] gimmick;
    public GameObject[] item;
    public GameObject[] enemy;
    public int rnd;
    int itemnum;
    public int itemlim;
    int itempos;
    int enemynum;
    public int enemylim;
    int enemypos;
    // Start is called before the first frame update
    void Start()
    {
        //rnd = Random.Range(1, 3);
        rnd = 1;
        itemnum = Random.Range(0, 7);
        //itemnum = 1;
        itemlim = Random.Range(2, 6);
        //itempos = Random.Range(1, 7);
        itempos = 1;
        enemynum = Random.Range(0, 2);
        enemylim = Random.Range(2, 5);
        enemypos = 1;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = new Vector3(0.52f, -5.3f,0);
        player.transform.position = pos;
        //map[0].SetActive(true);
        Invoke("Shut", 0.5f);
        MapMaker();
        ItemGenerator();
        EnemyGenerator();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Shut()
    {
        shutter[0].SetActive(true);
    }
    void MapMaker()
    {
        //Instantiate(player, new Vector3(0.52f, -5.3f, 0), transform.rotation);
        switch (rnd)
        {
            case 0:
                break;
            case 1:
                map[0].SetActive(true);
                map[1].SetActive(true);
                map[2].SetActive(true);
                map[3].SetActive(true);
                bridge[0].SetActive(true);
                bridge[1].SetActive(true);
                bridge[2].SetActive(true);
                gimmick[0].SetActive(true);
                gimmick[1].SetActive(true);
                break;
            case 2:
                map[0].SetActive(true);
                map[1].SetActive(true);
                map[2].SetActive(true);
                map[3].SetActive(true);
                map[4].SetActive(true);
                bridge[0].SetActive(true);
                bridge[1].SetActive(true);
                bridge[2].SetActive(true);
                gimmick[5].SetActive(true);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;

        }
    }
    void ItemGenerator()
    {
        int i = 0;
        while (i < itemlim)
        {
            ItemManager();
            i++;
        }
    }
    void ItemManager()
    {
        switch (rnd)
        {
            case 0:
                break;
            case 1:
                switch (itempos)
                {
                    case 0:
                        break;
                    case 1:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-2.1f, 3.0f), Random.Range(-5.3f, -3.4f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        //itempos = Random.Range(2, 7);
                        break;
                    case 2:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-8.8f, -3.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                        //itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 7);
                        while (itempos == 2)
                        {
                            itempos = Random.Range(1, 7);
                        }
                        break;
                    case 3:
                        Instantiate(item[itemnum], new Vector3(Random.Range(4.6f, 9.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                        //itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 7);
                        while (itempos == 3)
                        {
                            itempos = Random.Range(1, 7);
                        }
                        break;
                    case 4:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-9.1f, -4.0f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                        //itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 7);
                        while (itempos == 4)
                        {
                            itempos = Random.Range(1, 7);
                        }
                        break;
                    case 5:
                        Instantiate(item[itemnum], new Vector3(Random.Range(5.0f, 10.1f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                        //itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 7);
                        while (itempos == 5)
                        {
                            itempos = Random.Range(1, 7);
                        }
                        break;
                    case 6:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-4.3f, 5.4f), Random.Range(2.0f, 6.2f), 0), transform.rotation);
                        //itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 7);
                        while (itempos == 6)
                        {
                            itempos = Random.Range(1, 7);
                        }
                        break;
                }
                break;
            case 2:
                switch (itempos)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                }
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                rnd = 0;
                break;
            case 7:
                rnd = 0;
                break;
            case 8:
                rnd = 0;
                break;
            case 9:
                rnd = 0;
                break;
            case 10:
                rnd = 0;
                break;
        }
    }
    void EnemyGenerator()
    {
        int e = 0;
        while (e < enemylim)
        {
            EnemyManager();
            e++;
        }
    }
    void EnemyManager()
    {
        switch (rnd)
        {
            case 0:
                break;
            case 1:
                switch (enemypos)
                {
                    case 0:
                        break;
                    case 1:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-2.1f, 3.0f), Random.Range(-5.3f, -3.4f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        //enemypos = Random.Range(2, 7);
                        break;
                    case 2:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-8.8f, -3.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 7);
                        while (enemypos == 2)
                        {
                            enemypos = Random.Range(1, 7);
                        }
                        break;
                    case 3:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(4.6f, 9.7f), Random.Range(-5.6f, -3.1f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 7);
                        while (enemypos == 3)
                        {
                            enemypos = Random.Range(1, 7);
                        }
                        break;
                    case 4:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-9.1f, -4.0f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 7);
                        while (enemypos == 4)
                        {
                            enemypos = Random.Range(1, 7);
                        }
                        break;
                    case 5:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(5.0f, 10.1f), Random.Range(-2.1f, 0.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 7);
                        while (enemypos == 5)
                        {
                            enemypos = Random.Range(1, 7);
                        }
                        break;
                    case 6:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-4.3f, 5.4f), Random.Range(2.0f, 6.2f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 7);
                        while (enemypos == 6)
                        {
                            enemypos = Random.Range(1, 7);
                        }
                        break;
                }
                break;
            case 2:
                switch (enemypos)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                }
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                rnd = 0;
                break;
            case 7:
                rnd = 0;
                break;
            case 8:
                rnd = 0;
                break;
            case 9:
                rnd = 0;
                break;
            case 10:
                rnd = 0;
                break;
        }
    }
}