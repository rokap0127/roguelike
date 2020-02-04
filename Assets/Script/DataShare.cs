using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataShare : MonoBehaviour
{
    public static int knightHp;
    public static int knightMp;
    public static int archerHp;
    public static int archerMp;
    public static int mageHp;
    public static int mageMp;
    private void Awake()
    {
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Operation.knightDead)
        {
            knightHp = 0;
            knightMp = 0;
        }
        if(Operation.archerDead)
        {
            archerHp = 0;
            archerMp = 0;
        }
        if(Operation.mageDead)
        {
            mageHp = 0;
            mageMp = 0;
        }
    }
}
