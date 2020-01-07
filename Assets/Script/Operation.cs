using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
{
    public bool archerFlag;
    public bool knightFlag;
    public bool mageFlag;

    // Start is called before the first frame update
    void Start()
    {
        archerFlag = false;
        knightFlag = true;
        mageFlag = false;
       
    }
    private void Awake()
    {
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!archerFlag &
            Input.GetKeyDown(KeyCode.Alpha1))
        {
            archerFlag = false;
            mageFlag = false;
            knightFlag = true;
        }
        else if(!knightFlag &
            Input.GetKeyDown(KeyCode.Alpha2))
        {
            knightFlag = false;
            archerFlag = true;
            mageFlag = false;
        }
        else if (!mageFlag &
            Input.GetKeyDown(KeyCode.Alpha3))
        {
            mageFlag = true;
            knightFlag = false;
            archerFlag = false;      
        }
    }

    public bool GetArcherFlag()
    {
        return archerFlag;
    }

    public bool GetKnightFlag()
    {
        return knightFlag;
    }

    public bool GetMageFlag()
    {
        return mageFlag;
    }
}
