using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] menu; 
    public Button[] button;
    public GameObject mapCamera;
    public bool menuflag = false;
    public bool cameraFlag=false;
    public bool itemFlag = false;
    public bool endFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        ButtonDown();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !menuflag||
            Input.GetKeyDown(KeyCode.RightControl) && !menuflag)
        {
            menu[0].SetActive(true);
            Time.timeScale = 0f;
            menuflag = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && menuflag&&!cameraFlag&&!itemFlag&&!endFlag ||
                 Input.GetKeyDown(KeyCode.RightControl) && menuflag && !cameraFlag && !itemFlag && !endFlag ||
                 Input.GetMouseButtonDown(1) && menuflag && !cameraFlag && !itemFlag && !endFlag)
        {
            menu[0].SetActive(false);
            Time.timeScale = 1f;
            menuflag = false;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) && cameraFlag ||
           Input.GetKeyDown(KeyCode.RightControl) && cameraFlag ||
           Input.GetMouseButtonDown(1) && cameraFlag)
        {

            mapCamera.SetActive(false);
            menu[0].SetActive(true);
            cameraFlag = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && itemFlag ||
            Input.GetKeyDown(KeyCode.RightControl) && itemFlag ||
            Input.GetMouseButtonDown(1) && itemFlag)
        {
            menu[1].SetActive(false);
            menu[0].SetActive(true);
            itemFlag = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && endFlag ||
            Input.GetKeyDown(KeyCode.RightControl) && endFlag ||
            Input.GetMouseButtonDown(1) && endFlag)
        {
            menu[2].SetActive(false);
            endFlag = false;
        }
    }

    void ButtonDown()
    {
        button[0].onClick.AddListener(StartItem);
        button[1].onClick.AddListener(StartMap);
        button[2].onClick.AddListener(End);
        button[3].onClick.AddListener(Return);
    }
    void StartItem()
    {
        menu[1].SetActive(true);
        menu[0].SetActive(false);
        itemFlag = true;
        menuflag = false;
    }
    void StartMap()
    {
        mapCamera.SetActive(true);
        cameraFlag = true;
        menu[0].SetActive(false);
    }
    void End()
    {
        menu[2].SetActive(true);
        endFlag = true;
    }
    void Return()
    {
        menu[0].SetActive(false);
        menuflag = false;
        Time.timeScale = 1f;
    }
}