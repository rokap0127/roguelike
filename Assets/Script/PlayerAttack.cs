using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float stop;
  


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("Destory");
    }

    IEnumerator Destory()
    {
        //停止
        yield return new WaitForSeconds(stop);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
