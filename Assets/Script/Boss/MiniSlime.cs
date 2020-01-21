using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSlime : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
   
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
        //ナイト
        int knightAttack = 80;
        if (collision.gameObject.tag == "PlayerAttack")
        {
            Instantiate(explosionPrefab,
                collision.transform.position,
                Quaternion.identity);
            //敵のHPを減らす
            enemyHp -= knightAttack;

            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < enemyHp) { return; }

            //敵を削除する
            Destroy(gameObject);
        }
        //アーチャー
        int arrow = 50;
        if (collision.name.Contains("Arrow"))
        {
            Instantiate(explosionPrefab,
                collision.transform.position,
                Quaternion.identity);
            //敵のHPを減らす
            enemyHp -= arrow;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < enemyHp) { return; }

            //敵を削除する
            Destroy(gameObject);
        }

        //メイジ
        int m_shot = 25;
        if (collision.name.Contains("Shot_M"))
        {
            Instantiate(explosionPrefab,
                collision.transform.position,
                Quaternion.identity);
            //敵のHPを減らす
            enemyHp -= m_shot;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < enemyHp) { return; }

            //敵を削除する
            Destroy(gameObject);
        }
        int magic = 100;
        if (collision.name.Contains("Magic"))
        {
            Instantiate(explosionPrefab,
                collision.transform.position,
                Quaternion.identity);
            //敵のHPを減らす
            enemyHp -= magic;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < enemyHp) { return; }

            //敵を削除する
            Destroy(gameObject);
        }

        //Playerにダメージ
        if (collision.name.Contains("Knight"))
        {
            //プレイヤーにダメージを与える
            var knight = collision.GetComponent<Knight>();
            if (knight == null) return;
            knight.Damage(damage);
        }
        if (collision.name.Contains("Archer"))
        {
            //プレイヤーにダメージを与える
            var archer = collision.GetComponent<Archer>();
            if (archer == null) return;
            archer.Damage(damage);
        }
        if (collision.name.Contains("Mage"))
        {
            //プレイヤーにダメージを与える
            var mage = collision.GetComponent<Mage>();
            if (mage == null) return;
            mage.Damage(damage);
        }
    }
}
