using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHUD : MonoBehaviour
{
    public Text TextHud;

    public GameObject Key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == Key)
        {
            TextHud.text = "鍵を取りました！";
        }
    }
}
