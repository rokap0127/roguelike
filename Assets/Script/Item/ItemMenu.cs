﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    GameObject knight;
    GameObject archer;
    GameObject mage;
    GameObject iChecker;
    Knight kt;
    Archer ac;
    Mage mg;
    ItemChecker ic;
    bool menuflag = false;
    public GameObject ItemUI;
    public Text[] text;
    public Button[] button;
    GameObject operation;
    Operation op;


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        operation = GameObject.FindGameObjectWithTag("Operation");
        op = operation.GetComponent<Operation>();
        iChecker = GameObject.FindGameObjectWithTag("ItemChecker");
        ic = iChecker.GetComponent<ItemChecker>();
        operation = GameObject.FindGameObjectWithTag("Operation");
        ItemDisplay();
    }
    void ItemDisplay()
    {
        text[0].text = "HPポーション ×" + ic.HpPortion;
        text[1].text = "MPポーション ×" + ic.MpPortion;
        text[2].text = "スピードUP ×" + ic.SpeedUP;
        text[3].text = "ダメージUP ×" + ic.DamageUP;
        text[4].text = "復活ペンダント ×" + ic.RevivalPendant;
        text[5].text = "強化アーマー ×" + ic.Armor;
        text[6].text = "爆弾 ×" + ic.Bomb;
    }
    public void UseHpPortion()
    {
        if(Operation.knightFlag)
        {
            knight = GameObject.FindGameObjectWithTag("Knight");
            kt = knight.GetComponent<Knight>();
            if (ic.HpPortion > 0 && kt.playerHp < kt.playerMaxHp)
            {
                kt.playerHp += 20;
                ic.HpPortion -= 1;
            }
        }
        if(Operation.archerFlag)
        {
            archer = GameObject.FindGameObjectWithTag("Archer");
            ac = archer.GetComponent<Archer>();
            if (ic.HpPortion > 0 && ac.playerHp < ac.playerMaxHp)
            {
                ac.playerHp += 20;
                ic.HpPortion -= 1;
            }
        }
        if(Operation.mageFlag)
        {
            mage = GameObject.FindGameObjectWithTag("Mage");
            mg = mage.GetComponent<Mage>();
            if (ic.HpPortion > 0 && mg.playerHp < mg.playerMaxHp)
            {
                mg.playerHp += 20;
                ic.HpPortion -= 1;
            }
        }
    }
    public void UseMpPortion()
    {
        if(Operation.knightFlag)
        {
            knight = GameObject.FindGameObjectWithTag("Knight");
            kt = knight.GetComponent<Knight>();
            if (ic.MpPortion > 0 && kt.playerMp < kt.playerMaxMp)
            {
                kt.playerMp += 20;
                ic.MpPortion -= 1;
            }
        }
        if(Operation.archerFlag)
        {
            archer = GameObject.FindGameObjectWithTag("Archer");
            ac = archer.GetComponent<Archer>();
            if (ic.MpPortion > 0 && ac.playerMp < ac.playerMaxMp)
            {
                ac.playerMp += 20;
                ic.MpPortion -= 1;
            }
        }
        if(Operation.mageFlag)
        {
            mage = GameObject.FindGameObjectWithTag("Mage");
            mg = mage.GetComponent<Mage>();
            if (ic.MpPortion > 0 && mg.playerMp < mg.playerMaxMp)
            {
                mg.playerMp += 20;
                ic.MpPortion -= 1;
            }
        }
    }
    public void UseSpeedUP()
    {
        if (ic.SpeedUP > 0 && !ic.SpeedFlag)
        {
            ic.SpeedFlag = true;
            if(!Operation.knightDead)
            {
                knight = GameObject.FindGameObjectWithTag("Knight");
                kt = knight.GetComponent<Knight>();
                kt.moveSpeed = kt.moveSpeed * 3;
            }
            if(!Operation.archerDead)
            {
                archer = GameObject.FindGameObjectWithTag("Archer");
                ac = archer.GetComponent<Archer>();
                ac.moveSpeed = ac.moveSpeed * 3;
            }
            if(!Operation.mageDead)
            {
                mage = GameObject.FindGameObjectWithTag("Mage");
                mg = mage.GetComponent<Mage>();
                mg.moveSpeed = mg.moveSpeed * 3;
            }
            ic.SpeedUP -= 1;
        }

    }
    public void UseDamageUP()
    {
        if (ic.DamageUP > 0 && !ic.DamageFlag)
        {
            ic.DamageFlag = true;
            ic.DamageUP -= 1;
        }

    }
    public void UseRevivalPendant()
    {
        if (ic.RevivalPendant > 0 && !ic.RevivalFlag)
        {
            ic.RevivalFlag = true;
            ic.RevivalPendant -= 1;
        }

    }
    public void UseArmor()
    {
        if (ic.Armor > 0 && !ic.ArmorFlag)
        {
            ic.ArmorFlag = true;
            ic.Armor -= 1;
        }

    }
    public void UseBomb()
    {
        if (ic.Bomb > 0 && !ic.BombFlag)
        {
            ic.BombFlag = true;
            ic.Bomb -= 1;
        }

    }

    public void MenuFlag()
    {
        if (menuflag)
        {
            enabled = false;
        }
        else if (!menuflag)
        {
            enabled = true;
        }
    }
}
