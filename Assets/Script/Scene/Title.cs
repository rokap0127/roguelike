﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("クリック");
            SceneManager.LoadScene("Stage02");
        }
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("Stage02");
    }
}