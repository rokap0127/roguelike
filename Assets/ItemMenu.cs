using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    GameObject player;
    Player psc;
    ItemChecker ic;
    bool menuflag = false;
    public GameObject ItemUI;
    public Text[] text;
    public Button[] button;
    private void Awake()
    {
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        psc = player.GetComponent<Player>();
        ic = player.GetComponent<ItemChecker>();
        UseItem();
    }

    // Update is called once per frame
    void Update()
    {
        ItemDisplay();
        if (Input.GetKeyDown(KeyCode.RightControl) && !menuflag ||
            Input.GetKeyDown(KeyCode.LeftControl) && !menuflag)
        {
            ItemUI.SetActive(true);
            Time.timeScale = 0f;
            menuflag = !menuflag;
        }
        else if (Input.GetKeyDown(KeyCode.RightControl) && menuflag ||
                 Input.GetKeyDown(KeyCode.LeftControl) && menuflag||
                 Input.GetMouseButtonDown(1) && menuflag)
        {
            ItemUI.SetActive(false);
            Time.timeScale = 1f;
            menuflag = !menuflag;
        }

        if (psc.playerHp <= 0 && ic.RevivalFlag)
        {
            player.SetActive(true);
            psc.playerHp = psc.MaxHp/2;
            ic.RevivalFlag = false;
        }
        if (psc.playerHp <= 0 && !ic.RevivalFlag)
        {
            Destroy(gameObject);
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
    void UseItem()
    {
        button[0].onClick.AddListener(UseHpPortion);
        button[1].onClick.AddListener(UseMpPortion);
        button[2].onClick.AddListener(UseSpeedUP);
        button[3].onClick.AddListener(UseDamageUP);
        button[4].onClick.AddListener(UseRevivalPendant);
        button[5].onClick.AddListener(UseArmor);
        button[6].onClick.AddListener(UseBomb);
    }
    void UseHpPortion()
    {
        if (ic.HpPortion > 0 && psc.playerHp < psc.MaxHp)
        {
            ic.HpPortion -= 1;
            psc.playerHp += 10;
        }

    }
    void UseMpPortion()
    {
        if (ic.MpPortion > 0)
        {
            ic.MpPortion -= 1;
        }

    }
    void UseSpeedUP()
    {
        if (ic.SpeedUP > 0&&!ic.SpeedFlag)
        {
            ic.SpeedFlag = true;
            psc.moveSpeed = psc.moveSpeed * 3;
            ic.SpeedUP -= 1;
        }

    }
    void UseDamageUP()
    {
        if (ic.DamageUP > 0&&!ic.DamageFlag)
        {
            ic.DamageFlag = true;
            ic.DamageUP -= 1;
        }

    }
    void UseRevivalPendant()
    {
        if (ic.RevivalPendant > 0&& !ic.RevivalFlag)
        {
            ic.RevivalFlag = true;
            ic.RevivalPendant -= 1;
        }

    }
    void UseArmor()
    {
        if (ic.Armor > 0&&!ic.ArmorFlag)
        {
            ic.ArmorFlag = true;
            ic.Armor -= 1;
        }

    }
    void UseBomb()
    {
        if (ic.Bomb > 0&&!ic.BombFlag)
        {
            ic.BombFlag = true;
            ic.Bomb -= 1;
        }

    }
}
