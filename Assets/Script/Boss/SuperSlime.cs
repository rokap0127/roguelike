using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSlime : MonoBehaviour
{
    public float moveSpeed; //移動速度
    public float shotSpeed; //ショットスピード
    public int damage;
    public int bossHp; //現在のHp
    public int bossMaxHp; //最大のHp
    public SlimeShot slimeShot; //スライムショット

    public float shotInterval; //ショットの間隔
   float shotCount; //shotカウント
   

    public Explotion explosionPrefab; //爆発エフェクト


    // Start is called before the first frame update
    void Start()
    {
        bossHp = bossMaxHp; //Hpを最大にする
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

        shotCount ++;

        if (shotCount == shotInterval)
        {
            shotCount = 0;
            SlimeShot(direction);
        }

    }

    //スライムショット
    void SlimeShot(Vector3 direction)
    {
        var slime = Instantiate(slimeShot, transform.position, Quaternion.identity);
        var rb = slime.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * shotSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            //エフェクト生成
            Instantiate(
    explosionPrefab,
    collision.transform.position,
    Quaternion.identity);
            //敵のHPを減らす
            bossHp--;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < bossHp) { return; }

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
            bossHp -= knightAttack;

            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < bossHp) { return; }

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
            bossHp -= arrow;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < bossHp) { return; }

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
            bossHp -= m_shot;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < bossHp) { return; }

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
            bossHp -= magic;
            //敵のHPがまだ残っている場合はここで処理を終える
            if (0 < bossHp) { return; }

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
