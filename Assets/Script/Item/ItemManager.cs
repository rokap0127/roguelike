using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    GameObject iChecker;
    ItemChecker ic;
    // Start is called before the first frame update
    void Start()
    {
        iChecker = GameObject.FindGameObjectWithTag("ItemChecker");
        ic = iChecker.GetComponent<ItemChecker>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Knight" ||
            collision.gameObject.tag == "Archer" ||
            collision.gameObject.tag == "Mage")
        {
            if (this.tag == "HPportion")
            {
                ic.HpPortion += 1;
                Destroy(gameObject);
            }
            if (this.tag == "MPportion")
            {
                ic.MpPortion += 1;
                Destroy(gameObject);
            }
            if (this.tag == "SpeedUP")
            {
                ic.SpeedUP += 1;
                Destroy(gameObject);
            }
            if (this.tag == "DamageUP")
            {
                ic.DamageUP += 1;
                Destroy(gameObject);
            }
            if (this.tag == "RevivalPendant")
            {
                ic.RevivalPendant += 1;
                Destroy(gameObject);
            }
            if (this.tag == "Armor")
            {
                ic.Armor += 1;
                Destroy(gameObject);
            }
            if (this.tag == "Bomb")
            {
                ic.Bomb += 1;
                Destroy(gameObject);
            }
            if (this.tag == "Key")
            {
                ic.KeyFlag = true;
                Destroy(gameObject);
            }
            if (this.tag == "Treasure")
            {
                int rnd = Random.Range(0, 3);
                switch (rnd)
                {
                    case 0:
                        ic.HpPortion += 2;
                        ic.MpPortion += 1;
                        ic.SpeedUP += 1;
                        break;
                    case 1:
                        ic.HpPortion += 1;
                        ic.MpPortion += 2;
                        ic.Bomb += 1;
                        break;
                    default:
                        ic.HpPortion += 1;
                        ic.MpPortion += 1;
                        ic.SpeedUP += 1;
                        //ic.DamageUP += 1;
                        //ic.RevivalPendant += 1;
                        //ic.Armor += 1;
                        ic.Bomb += 1;
                        break;
                }
                Destroy(gameObject);
            }

            if (this.tag == "Untagged")
            {
                Destroy(gameObject);
            }
        }
    }
}
