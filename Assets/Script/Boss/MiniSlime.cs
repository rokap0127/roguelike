using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSlime : MonoBehaviour
{
    public float moveSpeed;
   
    public int enemyMaxHp; //最大Hp
    public int enemyHp; //現在のHp

    public Explotion explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyMaxHp; //最大Hpにする
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //プレイヤーの位置へ向かうベクトルを生成する
        var angle = Utils.GetAngle(
            transform.localPosition,
            Knight.instance.transform.localPosition);
        var direction = Utils.GetDirection(angle);

        //プレイヤーが存在する方向へ移動する
        transform.localPosition += direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerAttack")
        {
            //エフェクト生成
            Instantiate(
    explosionPrefab,
    collision.transform.position,
    Quaternion.identity);
            //敵のHPを減らす
            enemyHp--;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < enemyHp) { return; }

            //敵を削除する
            Destroy(gameObject);
        }
    }
}
