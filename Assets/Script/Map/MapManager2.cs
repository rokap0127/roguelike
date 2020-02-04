using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager2 : MonoBehaviour
{
    public GameObject knight;
    public GameObject mage;
    public GameObject archer;
    public GameObject shutter;

    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        Instantiate(knight, new Vector3(-8.8f, -4, 0), transform.rotation);
        Instantiate(archer, new Vector3(-8.8f, -3.8f), transform.rotation);
        Instantiate(mage, new Vector3(-8.8f, -3.6f), transform.rotation);
        Invoke("Shut", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Shut()
    {
        shutter.SetActive(true);
    }
}
