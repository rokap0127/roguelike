using System.Collections;
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
        knight = GameObject.FindGameObjectWithTag("Knight");
        kt = knight.GetComponent<Knight>();
        archer = GameObject.FindGameObjectWithTag("Archer");
        ac = archer.GetComponent<Archer>();
        mage = GameObject.FindGameObjectWithTag("Mage");
        mg = mage.GetComponent<Mage>();      
        operation = GameObject.FindGameObjectWithTag("Operation");
        op = operation.GetComponent<Operation>();
    }
    // Update is called once per frame
    void Update()
    {
        iChecker = GameObject.FindGameObjectWithTag("ItemChecker");
        ic = iChecker.GetComponent<ItemChecker>();
        ItemDisplay();
        if (Knight.instance.playerHp <= 0 && ic.RevivalFlag)
        {
            Knight.instance.playerHp = Knight.instance.playerMaxHp / 2;
            ic.RevivalFlag = false;
        }
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
        if (ic.HpPortion > 0 && Knight.instance.playerHp < Knight.instance.playerMaxHp && Operation.knightFlag)
        {
            Knight.instance.playerHp += 10;
            ic.HpPortion -= 1;
        }
        if (ic.HpPortion > 0 && Archer.instance.playerHp < Archer.instance.playerMaxHp && Operation.archerFlag)
        {
            Archer.instance.playerHp += 10;
            ic.HpPortion -= 1;
        }
        if (ic.HpPortion > 0 && Mage.instance.playerHp < Mage.instance.playerMaxHp && Operation.mageFlag)
        {
            Mage.instance.playerHp += 10;
            ic.HpPortion -= 1;
        }
    }
    public void UseMpPortion()
    {
        if (ic.MpPortion > 0 && Knight.instance.playerMp < Knight.instance.playerMaxMp && Operation.knightFlag)
        {
            Knight.instance.playerMp += 10;
            ic.MpPortion -= 1;
        }
        if (ic.MpPortion > 0 && Archer.instance.playerMp < Archer.instance.playerMaxMp && Operation.archerFlag)
        {
            Archer.instance.playerMp += 10;
            ic.MpPortion -= 1;
        }
        if (ic.MpPortion > 0 && Mage.instance.playerMp < Mage.instance.playerMaxMp && Operation.mageFlag)
        {
            Mage.instance.playerMp += 10;
            ic.MpPortion -= 1;
        }
    }
    public void UseSpeedUP()
    {
        if (ic.SpeedUP > 0 && !ic.SpeedFlag)
        {
            ic.SpeedFlag = true;
            Knight.instance.moveSpeed = Knight.instance.moveSpeed * 3;
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
