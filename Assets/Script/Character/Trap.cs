using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite trapOpen;
    public Sprite trapClose;

    public float breakTime;

    new BoxCollider2D collider2D;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            spriteRenderer.sprite = trapClose;
            collider2D.enabled = false;
            Destroy(gameObject, breakTime);
            
        }
    }
}
