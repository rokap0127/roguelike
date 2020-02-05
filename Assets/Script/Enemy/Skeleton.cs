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
    public List<Sprite> sprites; //スプライトリスト
    public float attackDistance; //近づく距離

    //ガードに触れているか
    bool guardFlag = false;
    //トラップにかかったか？
    bool trapFlag = false;

    Direction direciton = Direction.DOWN;  //向き
    //Animator anim; //アニメーション
    SpriteRenderer spriteRenderer; //スプライトレンダラー

    float distance;
    float angle;
    Vector3 direction;
    float trapCount;

    // Start is called before the first frame update
    void Start()
    {
        //最大Hpにする
        enemyHp = enemyMaxHp;

        //anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //プレイヤーの位置へ向かうベクトルを生成する
        //ナイト
        if (Operation.knightFlag)
        {
           angle = Utils.GetAngle(
           transform.localPosition,
           Knight.instance.transform.localPosition);
           direction = Utils.GetDirection(angle);

           //プレイヤーとの距離の絶対値
           distance = Mathf.Abs(Vector2.Distance(transform.localPosition,
               Knight.instance.transform.localPosition));
        }
        //アーチャー
        if (Operation.archerFlag)
        {
              angle = Utils.GetAngle(
              transform.localPosition,
              Archer.instance.transform.localPosition);
              direction = Utils.GetDirection(angle);

            //プレイヤーとの距離の絶対値
             distance = Mathf.Abs(Vector2.Distance(transform.localPosition,
                Archer.instance.transform.localPosition));
        }
        //メイジ
        if (Operation.mageFlag)
        {
            angle = Utils.GetAngle(
            transform.localPosition,
            Mage.instance.transform.localPosition);
            direction = Utils.GetDirection(angle);

            //プレイヤーとの距離の絶対値
            distance = Mathf.Abs(Vector2.Distance(transform.localPosition,
              Mage.instance.transform.localPosition));
        }

        if(!guardFlag && !trapFlag)
        {
            //プレイヤーとの距離が
            if(distance >= attackDistance)
            {
                //プレイヤーが存在する方向へ移動する
                transform.localPosition += direction * moveSpeed;
            }          
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
        

        //向き
        PlayerRote(angle);
    }

    void PlayerRote(float angle)
    {

        //上を向く
        if (68 <= angle && angle < 113)
        {
            direciton = Direction.UP;
            spriteRenderer.sprite = sprites[(int)direciton];
            //anim.SetBool("Move@Up", true);
            //anim.SetBool("Move@UpRight", false);
            //anim.SetBool("Move@Right", false);
            //anim.SetBool("Move@DownRight", false);
            //anim.SetBool("Move@Down", false);
            //anim.SetBool("Move@DownLeft", false);
            //anim.SetBool("Move@Left", false);
            //anim.SetBool("Move@UpLeft", false);
        }
        //右上を向く
        if (23 <= angle && angle < 68)
        {
            direciton = Direction.UPRIGHT;
            spriteRenderer.sprite = sprites[(int)direciton];
            //anim.SetBool("Move@Up", false);
            //anim.SetBool("Move@UpRight", true);
            //anim.SetBool("Move@Right", false);
            //anim.SetBool("Move@DownRight", false);
            //anim.SetBool("Move@Down", false);
            //anim.SetBool("Move@DownLeft", false);
            //anim.SetBool("Move@Left", false);
            //anim.SetBool("Move@UpLeft", false);
        }
        //右を向く
        if (-23 <= angle && angle < 23)
        {
            direciton = Direction.RIGHT;
            spriteRenderer.sprite = sprites[(int)direciton];
            //anim.SetBool("Move@Up", false);
            //anim.SetBool("Move@UpRight", false);
            //anim.SetBool("Move@Right", true);
            //anim.SetBool("Move@DownRight", false);
            //anim.SetBool("Move@Down", false);
            //anim.SetBool("Move@DownLeft", false);
            //anim.SetBool("Move@Left", false);
            //anim.SetBool("Move@UpLeft", false);

        }
        //右下を向く
        if (-68 <= angle && angle < -23)
        {
            direciton = Direction.DOWNRIGHT;
            spriteRenderer.sprite = sprites[(int)direciton];
            //anim.SetBool("Move@Up", false);
            //anim.SetBool("Move@UpRight", false);
            //anim.SetBool("Move@Right", false);
            //anim.SetBool("Move@DownRight", true);
            //anim.SetBool("Move@Down", false);
            //anim.SetBool("Move@DownLeft", false);
            //anim.SetBool("Move@Left", false);
            //anim.SetBool("Move@UpLeft", false);
        }
        //下を向く
        if (-113 <= angle && angle < -68)
        {
            direciton = Direction.DOWN;
            spriteRenderer.sprite = sprites[(int)direciton];
            //anim.SetBool("Move@Up", false);
            //anim.SetBool("Move@UpRight", false);
            //anim.SetBool("Move@Right", false);
            //anim.SetBool("Move@DownRight", false);
            //anim.SetBool("Move@Down", true);
            //anim.SetBool("Move@DownLeft", false);
            //anim.SetBool("Move@Left", false);
            //anim.SetBool("Move@UpLeft", false);

        }
        //左下を向く
        if (-158 <= angle && angle < -113)
        {
            direciton = Direction.DOWNLEFT;
            spriteRenderer.sprite = sprites[(int)direciton];
            //anim.SetBool("Move@Up", false);
            //anim.SetBool("Move@UpRight", false);
            //anim.SetBool("Move@Right", false);
            //anim.SetBool("Move@DownRight", false);
            //anim.SetBool("Move@Down", false);
            //anim.SetBool("Move@DownLeft", true);
            //anim.SetBool("Move@Left", false);
            //anim.SetBool("Move@UpLeft", false);
        }
        //左を向く
        if (-158 > angle || angle >= 158)
        {
            direciton = Direction.LEFT;
            spriteRenderer.sprite = sprites[(int)direciton];
            //anim.SetBool("Move@Up", false);
            //anim.SetBool("Move@UpRight", false);
            //anim.SetBool("Move@Right", false);
            //anim.SetBool("Move@DownRight", false);
            //anim.SetBool("Move@Down", false);
            //anim.SetBool("Move@DownLeft", false);
            //anim.SetBool("Move@Left", true);
            //anim.SetBool("Move@UpLeft", false);

        }
        //左上を向く
        if (113 <= angle && angle < 158)
        {
            direciton = Direction.UPLEFT;
            spriteRenderer.sprite = sprites[(int)direciton];
            //anim.SetBool("Move@Up", false);
            //anim.SetBool("Move@UpRight", false);
            //anim.SetBool("Move@Right", false);
            //anim.SetBool("Move@DownRight", false);
            //anim.SetBool("Move@Down", false);
            //anim.SetBool("Move@DownLeft", false);
            //anim.SetBool("Move@Left", false);
            //anim.SetBool("Move@UpLeft", true);
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
