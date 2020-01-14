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
        knight = GameObject.FindGameObjectWithTag("Knight");
        kt = knight.GetComponent<Knight>();
        archer = GameObject.FindGameObjectWithTag("Archer");
        ac = archer.GetComponent<Archer>();
        mage = GameObject.FindGameObjectWithTag("Mage");
        mg = mage.GetComponent<Mage>();
        iChecker = GameObject.FindGameObjectWithTag("ItemChecker");
        ic = iChecker.GetComponent<ItemChecker>();
        ItemDisplay();
        if (kt.playerHp <= 0 && ic.RevivalFlag)
        {
            kt.playerHp = kt.playerMaxHp / 2;
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
        if (ic.HpPortion > 0 && kt.playerHp < kt.playerMaxHp)
        {
            ic.HpPortion -= 1;
            kt.playerHp += 10;
        }

    }
    public void UseMpPortion()
    {
        if (ic.MpPortion > 0 && kt.playerMp < kt.playerMaxMp)
        {
            ic.MpPortion -= 1;
            kt.playerMp += 10;
        }

    }
    public void UseSpeedUP()
    {
        if (ic.SpeedUP > 0&&!ic.SpeedFlag)
        {
            ic.SpeedFlag = true;
            kt.moveSpeed = kt.moveSpeed * 3;
            ic.SpeedUP -= 1;
        }

    }
    public void UseDamageUP()
    {
        if (ic.DamageUP > 0&&!ic.DamageFlag)
        {
            ic.DamageFlag = true;
            ic.DamageUP -= 1;
        }

    }
    public void UseRevivalPendant()
    {
        if (ic.RevivalPendant > 0&& !ic.RevivalFlag)
        {
            ic.RevivalFlag = true;
            ic.RevivalPendant -= 1;
        }

    }
    public void UseArmor()
    {
        if (ic.Armor > 0&&!ic.ArmorFlag)
        {
            ic.ArmorFlag = true;
            ic.Armor -= 1;
        }

    }
    public void UseBomb()
    {
        if (ic.Bomb > 0&&!ic.BombFlag)
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
