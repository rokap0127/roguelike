using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
{
    public static bool knightFlag; //ナイト
    public static bool archerFlag; //アーチャー
    public static bool mageFlag;   //メイジ

    // Start is called before the first frame update
    void Start()
    {
        knightFlag = true;  //オン
        archerFlag = false; //オフ
        mageFlag = false;   //オフ
       
    }
    private void Awake()
    {
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!knightFlag &
            Input.GetKeyDown(KeyCode.Alpha1))
        {
            knightFlag = true;
            archerFlag = false;
            mageFlag = false;
           
        }
        else if(!archerFlag &
            Input.GetKeyDown(KeyCode.Alpha2))
        {
            knightFlag = false;
            archerFlag = true;
            mageFlag = false;
        }
        else if (!mageFlag &
            Input.GetKeyDown(KeyCode.Alpha3))
        {       
            knightFlag = false;
            archerFlag = false;
            mageFlag = true;
        }
    }

    public static bool GetKnightFlag()
    {
        return knightFlag;
    }


    public static bool GetArcherFlag()
    {
        return archerFlag;
    }

    public static bool GetMageFlag()
    {
        return mageFlag;
    }
}
