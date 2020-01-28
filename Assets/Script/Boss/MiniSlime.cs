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

    bool guardFlag;
    bool trapFlag;
    float angle;
    Vector3 direction;
    float trapCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemyMaxHp; //最大Hpにする
        guardFlag = false;
        trapFlag = false;
    }

    private void FixedUpdate()
    {
        //プレイヤーの位置へ向かうベクトルを生成する
        //ナイト
        if (Operation.knightFlag)
        {
            angle = Utils.GetAngle(
            transform.localPosition,
            Knight.instance.transform.localPosition);
            direction = Utils.GetDirection(angle);
        }
        //アーチャー
        if (Operation.archerFlag)
        {
            angle = Utils.GetAngle(
            transform.localPosition,
            Archer.instance.transform.localPosition);
            direction = Utils.GetDirection(angle);
        }
        //メイジ
        if (Operation.mageFlag)
        {
            angle = Utils.GetAngle(
            transform.localPosition,
            Mage.instance.transform.localPosition);
            direction = Utils.GetDirection(angle);
        }


        if (!guardFlag && !trapFlag)
        {
            //プレイヤーが存在する方向へ移動する
            transform.localPosition += direction * moveSpeed;
        }

        if (trapFlag)
        {
            trapCount++;
            if (trapCount == 240)
            {
                trapFlag = false;
                trapCount = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ナイト
        int knightAttack = 80;
        if (collision.gameObject.tag == "PlayerAttack")
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction * -1 * 0.5f, 1.0f);

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
        int trap = 30;
        //トラップ
        if (collision.name.Contains("Trap"))
        {
            trapFlag = true;
            // 敵のHPを減らす
            enemyHp -= trap;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < enemyHp) { return; }

            //敵を削除する
            Destroy(gameObject);
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Contains("Guard"))
        {
            //moveSpeed = 0;
            guardFlag = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Guard")
        {
            //moveSpeed = 0.01f;
            guardFlag = false;
        }
    }
}
