﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    GameObject player;
    Player psc;
    ItemChecker ic;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        psc = player.GetComponent<Player>();
        ic = player.GetComponent<ItemChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        float pos = (transform.position- player.transform.position).magnitude;
        if (pos<1&&pos>-1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if(this.tag == "HPportion")
                {
                    ic.HpPortion += 1;
                }
                if(this.tag== "MPportion")
                {
                    ic.MpPortion += 1;
                }
                if (this.tag == "SpeedUP")
                {
                    ic.SpeedUP += 1;
                }
                if (this.tag == "DamageUP")
                {
                    ic.DamageUP += 1;
                }
                if (this.tag == "RevivalPendant")
                {
                    ic.RevivalPendant += 1;
                }
                if (this.tag == "Armor")
                {
                    ic.Armor += 1;
                }
                if (this.tag == "Bomb")
                {
                    ic.Bomb += 1;
                }
                Destroy(gameObject);
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    int hp = psc.playerHp;
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if(this.tag== "HPportion"&&hp<100 )
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
