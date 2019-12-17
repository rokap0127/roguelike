using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public GameObject menuUI;
    bool menuflag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)
            && !menuflag)
        {
            menuUI.SetActive(true);
            menuflag = !menuflag;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape)
            && menuflag)
        {
            menuUI.SetActive(false);
            menuflag = !menuflag;
            Time.timeScale = 1f;
        }
        //if (Input.GetKey(KeyCode.Space))
        //    GameEnd();

        //if (Input.GetKeyDown(KeyCode.Escape))
        //    GameEnd();

    }

    public void GameEnd()
    {
        Debug.Log("ゲーム終了");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
#endif
    }

}
