using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image knightHpGauge;
    public Image archerHpGauge;
    public Image mageHpGauge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KnightGauge();
        ArcherGauge();
        MageGauge();
    }

    void KnightGauge()
    {
        var player = Knight.instance;
        var hp = player.playerHp;
        var hpMax = player.playerMaxHp;

        knightHpGauge.fillAmount = (float)hp / hpMax;
    }

    void ArcherGauge()
    {
        var player = Archer.instance;
        var hp = player.playerHp;
        var hpMax = player.playerMaxHp;

        archerHpGauge.fillAmount = (float)hp / hpMax;
    }

    void MageGauge()
    {
        var player = Mage.instance;
        var hp = player.playerHp;
        var hpMax = player.playerMaxHp;

        mageHpGauge.fillAmount = (float)hp / hpMax;
    }
}
