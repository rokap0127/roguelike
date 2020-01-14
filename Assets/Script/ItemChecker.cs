using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChecker : MonoBehaviour
{
    GameObject knight;
    GameObject archer;
    GameObject mage;
    Knight kt;
    Archer ac;
    Mage mg;
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
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Knight");
        archer = GameObject.FindGameObjectWithTag("Archer");
        mage = GameObject.FindGameObjectWithTag("Mage");
        kt = knight.GetComponent<Knight>();
        ac = archer.GetComponent<Archer>();
        mg = mage.GetComponent<Mage>();

    }

    // Update is called once per frame
    void Update()
    {
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
                Instantiate(bombActive, new Vector3(knight.transform.position.x, knight.transform.position.y+0.3f, 0), transform.rotation);
                BombFlag = false;
            }
        }
    }
}
