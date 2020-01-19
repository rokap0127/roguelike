using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float moveSpeed; //移動速度
    public int damage; //攻撃力
    public int enemyHp; //現在のHp
    public int enemyMaxHp; //最大のHp
    public Explotion explosionPrefab; //爆発エフェクト
    public Explotion magicPrefab; //メイジスキルエフェクト

    Direction direciton;  //向き
    Animator anim; //アニメーション
    GameObject knight; //ナイト
    GameObject archer; //アーチャー
    GameObject mage; //メイジ
    float angle;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //最大Hpにする
        enemyHp = enemyMaxHp;
        //現在の向き
        direciton = Direction.DOWN;
        anim = GetComponent<Animator>();
        knight = GameObject.FindGameObjectWithTag("Knight");
        archer = GameObject.FindGameObjectWithTag("Archer");
        mage = GameObject.FindGameObjectWithTag("Mage");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //プレイヤーの位置へ向かうベクトルを生成する
        //ナイト
        if (Operation.GetKnightFlag())
        {
           angle = Utils.GetAngle(
           transform.localPosition,
           Knight.instance.transform.localPosition);
           direction = Utils.GetDirection(angle);
        }
        //アーチャー
        else if (Operation.GetArcherFlag())
        {
          angle = Utils.GetAngle(
          transform.localPosition,
          Archer.instance.transform.localPosition);
          direction = Utils.GetDirection(angle);
        }
        //メイジ
        else if (Operation.GetMageFlag())
        {
            angle = Utils.GetAngle(
            transform.localPosition,
            Mage.instance.transform.localPosition);
            direction = Utils.GetDirection(angle);
        }

        //プレイヤーが存在する方向へ移動する
        transform.localPosition += direction * moveSpeed;

        //向き
        PlayerRote(angle);
    }

    void PlayerRote(float angle)
    {

        //上を向く
        if (68 <= angle && angle < 113)
        {
            direciton = Direction.UP;
            anim.SetBool("Move@Up", true);
            anim.SetBool("Move@UpRight", false);
            anim.SetBool("Move@Right", false);
            anim.SetBool("Move@DownRight", false);
            anim.SetBool("Move@Down", false);
            anim.SetBool("Move@DownLeft", false);
            anim.SetBool("Move@Left", false);
            anim.SetBool("Move@UpLeft", false);
        }
        //右上を向く
        if (23 <= angle && angle < 68)
        {
            direciton = Direction.UPRIGHT;
            anim.SetBool("Move@Up", false);
            anim.SetBool("Move@UpRight", true);
            anim.SetBool("Move@Right", false);
            anim.SetBool("Move@DownRight", false);
            anim.SetBool("Move@Down", false);
            anim.SetBool("Move@DownLeft", false);
            anim.SetBool("Move@Left", false);
            anim.SetBool("Move@UpLeft", false);
        }
        //右を向く
        if (-23 <= angle && angle < 23)
        {
            direciton = Direction.RIGHT;
            anim.SetBool("Move@Up", false);
            anim.SetBool("Move@UpRight", false);
            anim.SetBool("Move@Right", true);
            anim.SetBool("Move@DownRight", false);
            anim.SetBool("Move@Down", false);
            anim.SetBool("Move@DownLeft", false);
            anim.SetBool("Move@Left", false);
            anim.SetBool("Move@UpLeft", false);

        }
        //右下を向く
        if (-68 <= angle && angle < -23)
        {
            direciton = Direction.DOWNRIGHT;
            anim.SetBool("Move@Up", false);
            anim.SetBool("Move@UpRight", false);
            anim.SetBool("Move@Right", false);
            anim.SetBool("Move@DownRight", true);
            anim.SetBool("Move@Down", false);
            anim.SetBool("Move@DownLeft", false);
            anim.SetBool("Move@Left", false);
            anim.SetBool("Move@UpLeft", false);
        }
        //下を向く
        if (-113 <= angle && angle < -68)
        {
            direciton = Direction.DOWN;
            anim.SetBool("Move@Up", false);
            anim.SetBool("Move@UpRight", false);
            anim.SetBool("Move@Right", false);
            anim.SetBool("Move@DownRight", false);
            anim.SetBool("Move@Down", true);
            anim.SetBool("Move@DownLeft", false);
            anim.SetBool("Move@Left", false);
            anim.SetBool("Move@UpLeft", false);

        }
        //左下を向く
        if (-158 <= angle && angle < -113)
        {
            direciton = Direction.DOWNLEFT;
            anim.SetBool("Move@Up", false);
            anim.SetBool("Move@UpRight", false);
            anim.SetBool("Move@Right", false);
            anim.SetBool("Move@DownRight", false);
            anim.SetBool("Move@Down", false);
            anim.SetBool("Move@DownLeft", true);
            anim.SetBool("Move@Left", false);
            anim.SetBool("Move@UpLeft", false);
        }
        //左を向く
        if (-158 > angle || angle >= 158)
        {
            direciton = Direction.LEFT;
            anim.SetBool("Move@Up", false);
            anim.SetBool("Move@UpRight", false);
            anim.SetBool("Move@Right", false);
            anim.SetBool("Move@DownRight", false);
            anim.SetBool("Move@Down", false);
            anim.SetBool("Move@DownLeft", false);
            anim.SetBool("Move@Left", true);
            anim.SetBool("Move@UpLeft", false);

        }
        //左上を向く
        if (113 <= angle && angle < 158)
        {
            direciton = Direction.UPLEFT;
            anim.SetBool("Move@Up", false);
            anim.SetBool("Move@UpRight", false);
            anim.SetBool("Move@Right", false);
            anim.SetBool("Move@DownRight", false);
            anim.SetBool("Move@Down", false);
            anim.SetBool("Move@DownLeft", false);
            anim.SetBool("Move@Left", false);
            anim.SetBool("Move@UpLeft", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
            Instantiate(magicPrefab,
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

        if (collision.name.Contains("Guard"))
        {
            moveSpeed = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        moveSpeed = 0.01f;
        if (collision.name.Contains("Guard"))
        {
            moveSpeed = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Guard")
        {
            moveSpeed = 0.01f;
        }
    }
}
