using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject bullet;
    public int SlimeHp = 10;
    public float moveSpeed;
    public float bulletSpeed;
    public float attenuation;

    public Transform player_position;
    public Player player;

    Rigidbody2D enemyRigi;
    Vector2 diff;
    float time;
    Vector3 verocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        enemyRigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SlimeHp == 0)
        {
            Destroy(gameObject);
        }

        time += Time.deltaTime;

        Attack();

        //追尾移動
        verocity += (player_position.position - transform.position);
        verocity *= attenuation;
        transform.position += verocity *= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            StartCoroutine(Blinl());
            SlimeHp -= 5;
        }
    }

    void Attack()
    {
        time += Time.deltaTime;
        float timeOut = 1;
        if (time > timeOut)
        {
            GameObject bulletScript = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigi = bulletScript.GetComponent<Rigidbody2D>();
            bulletRigi.AddForce(verocity.normalized * bulletSpeed);
            time = 0;
        }
     }


    //点滅
    IEnumerator Blinl()
    {
        var renderComponent = GetComponent<Renderer>();
        renderComponent.enabled = !renderComponent.enabled;
        //yield return new WaitForSeconds(0.2f);
        yield return null;
        renderComponent.enabled = !renderComponent.enabled;
    }

    private void OnTriggrtEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.Damage(10);
        }
    }
}
