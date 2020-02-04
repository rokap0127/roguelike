using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager3 : MonoBehaviour
{
    public GameObject shutter;
    public GameObject knight;
    public GameObject archer;
    public GameObject mage;
    // Start is called before the first frame update
    void Start()
    {
        Setting();
        Invoke("Shut", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Shut()
    {
        shutter.SetActive(true);
    }
    void Setting()
    {
        if (!Operation.knightDead)
        {
            knight = GameObject.FindGameObjectWithTag("Knight");
            Knight kt = knight.GetComponent<Knight>();
            kt.playerHp = DataShare.knightHp;
            kt.playerMp = DataShare.knightMp;
        }
        else if (Operation.knightDead)
        {
            knight = GameObject.FindGameObjectWithTag("Knight");
            Knight kt = knight.GetComponent<Knight>();
            kt.playerHp = DataShare.knightHp;
            kt.playerMp = DataShare.knightMp;
            knight.SetActive(false);
        }
        if (!Operation.archerDead)
        {
            archer = GameObject.FindGameObjectWithTag("Archer");
            Archer ac = archer.GetComponent<Archer>();
            ac.playerHp = DataShare.archerHp;
            ac.playerMp = DataShare.archerMp;
        }
        else if(Operation.archerDead)
        {
            archer = GameObject.FindGameObjectWithTag("Archer");
            Archer ac = archer.GetComponent<Archer>();
            ac.playerHp = DataShare.archerHp;
            ac.playerMp = DataShare.archerMp;
            archer.SetActive(false);
        }
        if (!Operation.mageDead)
        {
            mage = GameObject.FindGameObjectWithTag("Mage");
            Mage mg = mage.GetComponent<Mage>();
            mg.playerHp = DataShare.mageHp;
            mg.playerMp = DataShare.mageMp;
        }
        else if(Operation.mageDead)
        {
            mage = GameObject.FindGameObjectWithTag("Mage");
            Mage mg = mage.GetComponent<Mage>();
            mg.playerHp = DataShare.mageHp;
            mg.playerMp = DataShare.mageMp;
            mage.SetActive(false);
        }
    }
}