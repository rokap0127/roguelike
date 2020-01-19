using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    public Player player_Script;
    //public GameObject hit;
    GameObject guard;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Knight");
        player_Script = player.GetComponent<Player>();
        guard = GameObject.Find("Guard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Knight")
        {
            if(collision.gameObject != guard)
            player_Script.Damage(10);
        }

    }

    //画面外に出たら消える
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
