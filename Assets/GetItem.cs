using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    GameObject iChecker;
    ItemChecker ic;
    public bool GetFlag = false;
    public GameObject item;
    public int THpPortion;
    public int TMpPortion;
    public int TSpeedUP;
    public int TDamageUP;
    public int TRevivalPendant;
    public int TArmor;
    public int TBomb;
    // Start is called before the first frame update
    void Start()
    {
        iChecker = GameObject.FindGameObjectWithTag("ItemChecker");
        ic = iChecker.GetComponent<ItemChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GetFlag)
        {

            if (item.tag == "HPportion")
            {
                ic.HpPortion += 1;
            }
            if (item.tag == "MPportion")
            {
                ic.MpPortion += 1;
            }
            if (item.tag == "SpeedUP")
            {
                ic.SpeedUP += 1;
            }
            if (item.tag == "DamageUP")
            {
                ic.DamageUP += 1;
            }
            if (item.tag == "RevivalPendant")
            {
                ic.RevivalPendant += 1;
            }
            if (item.tag == "Armor")
            {
                ic.Armor += 1;
            }
            if (item.tag == "Bomb")
            {
                ic.Bomb += 1;
            }
            if (item.tag == "Key")
            {
                ic.KeyFlag = true;
            }
            if (item.tag == "Treasure")
            {
                ic.HpPortion += THpPortion;
                ic.MpPortion += TMpPortion;
                ic.SpeedUP += TSpeedUP;
                ic.DamageUP += TDamageUP;
                ic.RevivalPendant += TRevivalPendant;
                ic.Armor += TArmor;
                ic.Bomb += TBomb;
                Destroy(gameObject);
            }

            if (item.tag == "Untagged")
            {
            }
            Destroy(item);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Knight" ||
               col.gameObject.tag == "Archer" ||
               col.gameObject.tag == "Mage")
        {
            GetFlag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight" ||
            collision.gameObject.tag == "Archer" ||
            collision.gameObject.tag == "Mage")
        {
            GetFlag = false;
        }
    }
}
