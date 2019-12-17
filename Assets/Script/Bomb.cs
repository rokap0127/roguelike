using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Explotion explosionPrefab; //爆発エフェクト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Invoke("Blast", 5.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(
            explosionPrefab,
            collision.transform.position,
            Quaternion.identity);
        Destroy(gameObject);
    }
        void Blast()
    {
        Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity);
        Destroy(gameObject);
    }
}
