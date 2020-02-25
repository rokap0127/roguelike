using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image knightHpGauge;
    public Image archerHpGauge;
    public Image mageHpGauge;

    public Image knightMpGauge;
    public Image archerMpGauge;
    public Image mageMpGauge;

    public Image knightPlayFlag;
    public Image archerPlayFlag;
    public Image magePlayFlag;






    // Start is called before the first frame update
    void Start()
    {

        knightPlayFlag.fillAmount = 0;
        archerPlayFlag.fillAmount = 0;
        magePlayFlag.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        KnightHpGauge();
        ArcherHpGauge();
        MageHpGauge();
        KnightMpGauge();
        ArcherMpGauge();
        MageMpGauge();

        if (Operation.knightFlag)
        {
            knightPlayFlag.fillAmount = 1;
            archerPlayFlag.fillAmount = 0;
            magePlayFlag.fillAmount = 0;
        }
        if (Operation.archerFlag)
        {
            knightPlayFlag.fillAmount = 0;
            archerPlayFlag.fillAmount = 1;
            magePlayFlag.fillAmount = 0;
        }
        if (Operation.mageFlag)
        {
            knightPlayFlag.fillAmount = 0;
            archerPlayFlag.fillAmount = 0;
            magePlayFlag.fillAmount = 1;
        }
    }

    void KnightHpGauge()
    {
        var player = Knight.instance;
        var hp = player.playerHp;
        var hpMax = player.playerMaxHp;

        knightHpGauge.fillAmount = (float)hp / hpMax;
    }

    void ArcherHpGauge()
    {
        var player = Archer.instance;
        var hp = player.playerHp;
        var hpMax = player.playerMaxHp;

        archerHpGauge.fillAmount = (float)hp / hpMax;
    }

    void MageHpGauge()
    {
        var player = Mage.instance;
        var hp = player.playerHp;
        var hpMax = player.playerMaxHp;

        mageHpGauge.fillAmount = (float)hp / hpMax;
    }

    void KnightMpGauge()
    {
        var player = Knight.instance;
        var mp = player.playerMp;
        var mpMax = player.playerMaxMp;

        knightMpGauge.fillAmount = (float)mp / mpMax;
    }

    void ArcherMpGauge()
    {
        var player = Archer.instance;
        var mp = player.playerMp;
        var mpMax = player.playerMaxMp;

        archerMpGauge.fillAmount = (float)mp / mpMax;
    }

    void MageMpGauge()
    {
        var player = Mage.instance;
        var mp = player.playerMp;
        var mpMax = player.playerMaxMp;

        mageMpGauge.fillAmount = (float)mp / mpMax;
    }

   
}
