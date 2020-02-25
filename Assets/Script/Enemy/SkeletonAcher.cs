using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonAcher : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    public int enemyHp;
    public int enemyMaxHp;
    public Shot shotPrefab; //弾のプレハブ
    public float shotSpeed; //弾の移動の速さ
    public float shotAngleRange; //複数の弾を発射する時の角度
    public float shotTimer; //弾の発射タイミングを管理するタイマー
    public int shotCount; //弾の発射数
    public float shotInterval; //弾の発射間隔(秒)
    public Explotion explosionPrefab; //爆発エフェクト
    public Explotion magicPrefab; //メイジスキルエフェクト
    public List<Sprite> sprites;//スプライトリスト
    public float attackDistance; //近づく距離
    public Image hpGauge; //HPゲージ

    bool guardFlag = false;
    bool trapFlag = false;
    Direction direciton = Direction.DOWN; //向き
    //Animator anim; //アニメージョン
    SpriteRenderer spriteRenderer; //スプライトレンダラー
    Rigidbody2D enemyRigid;


    float distance = 0;
    float angle = 0;
    Vector3 _direction = Vector3.zero;
    float trapCount = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        //Hpを最大にする
        enemyHp = enemyMaxHp;
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigid = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

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
            _direction = Utils.GetDirection(angle);

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

            //プレイヤーとの距離の絶対値
            distance = Mathf.Abs(Vector2.Distance(transform.localPosition,
               Archer.instance.transform.localPosition));
            _direction = Utils.GetDirection(angle);
        }
        //メイジ
        if (Operation.mageFlag)
        {
            angle = Utils.GetAngle(
            transform.localPosition,
            Mage.instance.transform.localPosition);
            _direction = Utils.GetDirection(angle);

            //プレイヤーとの距離の絶対値
            distance = Mathf.Abs(Vector2.Distance(transform.localPosition,
              Mage.instance.transform.localPosition));
        }

        if(!guardFlag && !trapFlag)
        {
            if (distance > attackDistance)
            {
                //プレイヤーが存在する方向へ移動する

                Vector3 movement = Vector2.zero;
                movement = _direction * moveSpeed;
                enemyRigid.MovePosition(transform.localPosition + movement );



            }
            else if(distance < attackDistance - 0.01f)
            {
                //プレイヤーが存在する方向の逆へ移動する
                Vector3 movement = Vector2.zero;
                movement = _direction * moveSpeed * -1;
                enemyRigid.MovePosition(transform.localPosition + movement);
            }
            PlayerRote(angle);

            //弾の発射を管理するタイマーを更新する
            shotTimer += Time.deltaTime;

            //まだ弾を発射するタイミングではない場合ここで処理を終える
            if (shotTimer < shotInterval) return;

            //弾を発射するタイマーをリセットする
            shotTimer = 0;

            //弾を発射する
            ShootNWay(angle, shotAngleRange, shotSpeed, shotCount);
        }

        //トラップにかかる
        if (trapFlag)
        {
            trapCount++;
            if (trapCount == 240)
            {
                trapFlag = false;
                trapCount = 0;
            }


        }

        //Hpがを表示
        hpGauge.fillAmount = (float)enemyHp / enemyMaxHp;
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


    private void ShootNWay(
        float angleBase, float angleRange, float speed, int count)
    {
        var pos = transform.localPosition; //プレイヤーの位置       
        transform.localEulerAngles = _direction;
        var rot = transform.localRotation;

        //弾を複数発射する場合
        if(1 < count)
        {
            //発射する回数分ループする
            for(int i= 0; i< count; i++)
            {
                //弾の発射角度を計算する
                var angle = angleBase +
                    angleRange * ((float)i / (count - 1) - 0.5f);

                //発射する弾を生成する
                var shot = Instantiate(shotPrefab, pos, Quaternion.identity);


                //弾を発射する方向と速さを設定する
                shot.Init(angle, speed);
            }
        }
        else if(count == 1)
        {
            //発射する弾を生成する
            var shot = Instantiate(shotPrefab, pos, Quaternion.identity);

            //弾を発射する方向と速さを設定する
            shot.Init(angleBase, speed);
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ナイト
        int knightAttack = 80;
        if (collision.gameObject.tag == "PlayerAttack")
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction * -0.22f, 1.0f);

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

        //if (collision.name.Contains("Guard"))
        //{
        //    moveSpeed = 0;
        //}

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
        moveSpeed = 0.01f;
        if (collision.name.Contains("Guard"))
        {
            guardFlag = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Guard")
        {
            guardFlag = false;
        }
    }
}
