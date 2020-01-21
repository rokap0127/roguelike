using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Operation : MonoBehaviour
{
    //コントロール中か
    public static bool knightFlag; //ナイト
    public static bool archerFlag; //アーチャー
    public static bool mageFlag;   //メイジ
    //生きているか？
    public static bool knightDead; //ナイト
    public static bool archerDead; //アーチャー
    public static bool mageDead;   //メイジ

    // Start is called before the first frame update
    void Start()
    {
        knightFlag = true;  //オン
        archerFlag = false; //オフ
        mageFlag = false;   //オフ
        knightDead = false; //オフ
        archerDead = false; //オフ
        mageDead = false;   //オフ


    }
    private void Awake()
    {
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //1ボタンを押したとき
        if(!knightDead &&
            !knightFlag &&
            Input.GetKeyDown(KeyCode.Alpha1))
        {
            //ナイト オン
            KnightFlagOn();
           
        }
        //2ボタンを押したとき
        if(!archerDead&&
            !archerFlag &&
            Input.GetKeyDown(KeyCode.Alpha2))
        {
            //アーチャー オン
            ArcherFlagOn();
        }
        //3ボタンを押したとき
        if (!mageDead&&
            !mageFlag &&
            Input.GetKeyDown(KeyCode.Alpha3))
        {
            //メイジ オン
            MageFlagOn();
        }

  

    }

    public static void KnightFlagOn()
    {
        //ナイト オン
        knightFlag = true;
        archerFlag = false;
        mageFlag = false;
    }

    public static void ArcherFlagOn()
    {
        //アーチャー オン
        knightFlag = false;
        archerFlag = true;
        mageFlag = false;
    }

    public static void MageFlagOn()
    {
        //メイジ オン
        knightFlag = false;
        archerFlag = false;
        mageFlag = true;
    }

    
}
