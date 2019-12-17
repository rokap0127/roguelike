using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager2 : MonoBehaviour
{
    public GameObject knight;
    public GameObject mage;
    public GameObject archer;
    public GameObject[] map;
    public GameObject[] shutter;
    public GameObject[] bridge;
    public GameObject[] hole;
    public GameObject[] key;
    public GameObject[] item;
    public GameObject[] enemy;
    public int rnd;
    int itemnum;
    int rareItem;
    public int itemlim;
    int itempos;
    int enemynum;
    public int enemylim;
    int enemypos;

    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        rnd = Random.Range(1, 4);
        itemnum = Random.Range(0, 7);
        //itemnum = 0;
        itemlim = Random.Range(3, 6);
        itempos = 1;
        //itempos = Random.Range(1, 5);
        enemynum = Random.Range(0, 2);
        enemylim = Random.Range(2, 5);
        enemypos = 1;
        //enemypos = Random.Range(1, 5);
        //map[0].SetActive(true);
        shutter[2].SetActive(true);
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
        shutter[3].SetActive(true);
    }
    void MapMaker()
    {
        Instantiate(knight, new Vector3(-8.8f, -4, 0), transform.rotation);
        Instantiate(archer, new Vector3(-8.8f, -3.8f), transform.rotation);
        Instantiate(mage, new Vector3(-8.8f, -3.6f), transform.rotation);
        switch (rnd)
        {
            case 0:
                break;
            case 1:
                map[1].SetActive(true);
                map[2].SetActive(true);
                map[3].SetActive(true);
                map[4].SetActive(true);
                shutter[1].SetActive(true);
                shutter[4].SetActive(true);
                shutter[7].SetActive(true);
                shutter[8].SetActive(true);
                shutter[9].SetActive(true);
                shutter[10].SetActive(true);
                bridge[0].SetActive(true);
                bridge[1].SetActive(true);
                bridge[3].SetActive(true);
                key[0].SetActive(true);
                break;
            case 2:
                map[1].SetActive(true);
                map[3].SetActive(true);
                map[4].SetActive(true);
                map[5].SetActive(true);
                shutter[4].SetActive(true);
                shutter[5].SetActive(true);
                shutter[7].SetActive(true);
                shutter[12].SetActive(true);
                shutter[13].SetActive(true);
                bridge[0].SetActive(true);
                bridge[3].SetActive(true);
                bridge[4].SetActive(true);
                key[1].SetActive(true);
                break;
            case 5:
                map[1].SetActive(true);
                map[2].SetActive(true);
                map[3].SetActive(true);
                map[4].SetActive(true);
                shutter[7].SetActive(true);
                shutter[8].SetActive(true);
                bridge[1].SetActive(true);
                map[5].SetActive(true);
                bridge[0].SetActive(true);
                bridge[3].SetActive(true);
                bridge[4].SetActive(true);
                break;
            case 4:
                map[1].SetActive(true);
                map[2].SetActive(true);
                map[3].SetActive(true);
                map[4].SetActive(true);
                shutter[1].SetActive(true);
                shutter[4].SetActive(true);
                shutter[7].SetActive(true);
                shutter[8].SetActive(true);
                shutter[9].SetActive(true);
                shutter[10].SetActive(true);
                bridge[0].SetActive(true);
                bridge[1].SetActive(true);
                bridge[3].SetActive(true);
                hole[5].SetActive(true);
                break;
            case 3:
                map[2].SetActive(true);
                map[5].SetActive(true);
                map[6].SetActive(true);
                shutter[0].SetActive(true);
                shutter[8].SetActive(true);
                shutter[9].SetActive(true);
                shutter[11].SetActive(true);
                bridge[4].SetActive(true);
                bridge[5].SetActive(true);
                bridge[6].SetActive(true);
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
        int i=0;
        while(i<itemlim)
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
                switch(itempos)
                {
                    case 0:
                        break;
                    case 1:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        itemnum = Random.Range(0, 2);
                        //itempos = Random.Range(2, 6);
                        break;
                    case 2:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 6);
                        while (itempos == 2)
                        {
                            itempos = Random.Range(1, 6);
                        }
                        break;
                    case 3:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(0.1f, 2.3f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 6);
                        while (itempos == 3)
                        {
                            itempos = Random.Range(1, 6);
                        }
                        break;
                    case 4:
                        Instantiate(item[itemnum], new Vector3(Random.Range(3.3f, 10.4f), Random.Range(-4.0f, -0.5f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 6);
                        while (itempos == 4)
                        {
                            itempos = Random.Range(1, 6);
                        }
                        break;
                    case 5:
                        Instantiate(item[itemnum], new Vector3(Random.Range(4.3f, 9.4f), Random.Range(1.1f, 3.6f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 6);
                        while (itempos == 5)
                        {
                            itempos = Random.Range(1, 6);
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
                        Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        itemnum = Random.Range(0, 2);
                        //itempos = Random.Range(2, 6);
                        break;
                    case 2:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 6);
                        while (itempos == 2)
                        {
                            itempos = Random.Range(1, 6);
                        }
                        break;
                    case 3:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-0.1f, 2.3f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 6);
                        while (itempos == 3)
                        {
                            itempos = Random.Range(1, 6);
                        }
                        break;
                    case 4:
                        Instantiate(item[itemnum], new Vector3(Random.Range(3.3f, 10.4f), Random.Range(-4.0f, -0.5f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 6);
                        while (itempos == 4)
                        {
                            itempos = Random.Range(1, 6);
                        }
                        break;
                    case 5:
                        Instantiate(item[itemnum], new Vector3(Random.Range(4.3f, 9.4f), Random.Range(1.1f, 3.6f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 6);
                        while (itempos == 5)
                        {
                            itempos = Random.Range(1, 6);
                        }
                        break;
                }
                break;
            case 5:
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                break;
            case 4:
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                break;
            case 3:
                switch (itempos)
                {
                    case 0:
                        break;
                    case 1:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        itemnum = Random.Range(0, 2);
                        //itempos = Random.Range(2, 5);
                        break;
                    case 2:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-0.1f, 2.3f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 5);
                        while (itempos == 2)
                        {
                            itempos = Random.Range(1, 5);
                        }
                        break;
                    case 3:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(0.1f, 2.3f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 5);
                        while (itempos == 3)
                        {
                            itempos = Random.Range(1, 5);
                        }
                        break;
                    case 4:
                        Instantiate(item[itemnum], new Vector3(Random.Range(-12.3f, -5.25f), Random.Range(3.8f, 7.15f), 0), transform.rotation);
                        itemnum = Random.Range(0, 7);
                        itempos = Random.Range(1, 5);
                        while (itempos == 4)
                        {
                            itempos = Random.Range(1, 5);
                        }
                        break;
                    case 5:
                        break;
                }
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
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        //enemypos = Random.Range(2, 6);
                        break;
                    case 2:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 6);
                        while (enemypos == 2)
                        {
                            enemypos = Random.Range(1, 6);
                        }
                        break;
                    case 3:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(0.1f, 2.3f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 6);
                        while (itempos == 3)
                        {
                            itempos = Random.Range(1, 6);
                        }
                        break;
                    case 4:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(3.3f, 10.4f), Random.Range(-4.0f, -0.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 6);
                        while (enemypos == 4)
                        {
                            enemypos = Random.Range(1, 6);
                        }
                        break;
                    case 5:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(4.3f, 9.4f), Random.Range(1.1f, 3.6f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 6);
                        while (enemypos == 5)
                        {
                            enemypos = Random.Range(1, 6);
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
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        //enemypos = Random.Range(2, 6);
                        break;
                    case 2:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 6);
                        while (enemypos == 2)
                        {
                            enemypos = Random.Range(1, 6);
                        }
                        break;
                    case 3:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-0.1f, 2.3f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 6);
                        while (enemypos == 3)
                        {
                            enemypos = Random.Range(1, 6);
                        }
                        break;
                    case 4:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(3.3f, 10.4f), Random.Range(-4.0f, -0.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 6);
                        while (enemypos == 4)
                        {
                            enemypos = Random.Range(1, 6);
                        }
                        break;
                    case 5:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(4.3f, 9.4f), Random.Range(1.1f, 3.6f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 6);
                        while (enemypos == 5)
                        {
                            enemypos = Random.Range(1, 6);
                        }
                        break;
                }
                break;
            case 5:
                Instantiate(enemy[enemynum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                enemynum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                break;
            case 4:
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                itemnum = Random.Range(0, 7);
                Instantiate(item[itemnum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                break;
            case 3:
                switch (enemypos)
                {
                    case 0:
                        break;
                    case 1:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-4.0f, -1.5f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        //enemypos = Random.Range(2, 5);
                        break;
                    case 2:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-11.3f, -6.2f), Random.Range(-0.1f, 2.3f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 5);
                        while (enemypos == 2)
                        {
                            enemypos = Random.Range(1, 5);
                        }
                        break;
                    case 3:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-4.0f, 1.1f), Random.Range(0.1f, 2.3f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 5);
                        while (enemypos == 3)
                        {
                            enemypos = Random.Range(1, 5);
                        }
                        break;
                    case 4:
                        Instantiate(enemy[enemynum], new Vector3(Random.Range(-12.3f, -5.25f), Random.Range(3.8f, 7.15f), 0), transform.rotation);
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 5);
                        while (enemypos == 4)
                        {
                            enemypos = Random.Range(1, 5);
                        }
                        break;
                    case 5:
                        enemynum = Random.Range(0, 2);
                        enemypos = Random.Range(1, 5);
                        while (enemypos == 5)
                        {
                            enemypos = Random.Range(1, 5);
                        }
                        break;
                }
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
