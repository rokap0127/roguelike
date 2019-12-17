using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChecker : MonoBehaviour
{
    Knight psc;
    public int HpPortion = 0;
    public int MpPortion = 0;
    public int SpeedUP = 0;
    public int DamageUP = 0;
    public int RevivalPendant = 0;
    public int Armor = 0;
    public int Bomb = 0;
    public bool DamageFlag = false;
    public bool SpeedFlag = false;
    public bool ArmorFlag = false;
    public bool RevivalFlag = false;
    public bool BombFlag = false;
    public GameObject bombActive;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        psc = GetComponent<Knight>();
    }

    // Update is called once per frame
    void Update()
    {
        int hp = psc.playerHp;
        if (HpPortion>0&&hp<100)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                psc.playerHp += 10;
                HpPortion -= 1;
            }
        }
    }
    private void FixedUpdate()
    {
        if(ArmorFlag &&Time.timeScale == 1f)
        {
            Invoke("AFlagOff", 10.0f);
        }
        if(DamageFlag && Time.timeScale == 1f)
        {
            Invoke("DFlagOff", 10.0f);
        }
        if(SpeedFlag && Time.timeScale == 1f)
        {
            Invoke("SFlagOff", 10.0f);
        }
        SetBomb();
    }
    void AFlagOff()
    {
        ArmorFlag = false;
    }
    void DFlagOff()
    {
        DamageFlag = false;
    }
    void SFlagOff()
    {
        SpeedFlag = false;
    }
    void SetBomb()
    {
        if(BombFlag)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                Instantiate(bombActive, new Vector3(transform.position.x, transform.position.y+0.3f, 0), transform.rotation);
                BombFlag = false;
            }
        }
    }
}
