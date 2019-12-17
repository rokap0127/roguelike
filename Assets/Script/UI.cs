using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image hpGauge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var mage = Mage.mageInstance;

        //var hp = mage.playerHp;
        //var hpMax = mage.MaxHp;

        //hpGauge.fillAmount = (float)hp / hpMax;

        var player = Knight.knightInstance;
        var hp = player.playerHp;
        var hpMax = player.MaxHp;

        hpGauge.fillAmount = (float)hp / hpMax;
    }
}
