using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float moveSpeed;
    public int hpMax;
    public int damage;
    public Shot shotPrefab; //弾のプレハブ
    public float shotSpeed; //弾の移動の速さ
    public float shotAngleRange; //複数の弾を発射する時の角度
    public float shotTimer; //弾の発射タイミングを管理するタイマー
    public int shotCount; //弾の発射数
    public float shotInterval; //弾の発射間隔(秒)
    public Explotion explosionPrefab; //爆発エフェクト

    int Hp;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject knight = GameObject.FindGameObjectWithTag("Knight");
        float pos = (transform.position - knight.transform.position).magnitude;
        //プレイヤーの位置へ向かうベクトルを生成する
        var angle = Utils.GetAngle(
            transform.localPosition,
            Knight.knightInstance.transform.localPosition);
        direction = Utils.GetDirection(angle);
        if (pos < 7 && pos > -7)
        {
            //プレイヤーが存在する方向へ移動する
            transform.localPosition += direction * moveSpeed;
        }

        //弾の発射を管理するタイマーを更新する
        shotTimer += Time.deltaTime;

        //まだ弾を発射するタイミングではない場合ここで処理を終える
        if (shotTimer < shotInterval) return;

        //弾を発射するタイマーをリセットする
        shotTimer = 0;

        //弾を発射する
        if (pos < 5 && pos > -5)
            ShootNWay(angle, shotAngleRange, shotSpeed, shotCount);
    }

    private void ShootNWay(
        float angleBase, float angleRange, float speed, int count)
    {
        var pos = transform.localPosition; //プレイヤーの位置       
        transform.localEulerAngles = direction;
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
                var shot = Instantiate(shotPrefab, pos, rot);

                //弾を発射する方向と速さを設定する
                shot.Init(angle, speed);
            }
        }
        else if(count == 1)
        {
            //発射する弾を生成する
            var shot = Instantiate(shotPrefab, pos, rot);

            //弾を発射する方向と速さを設定する
            shot.Init(angleBase, speed);
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            Instantiate(
                explosionPrefab,
                collision.transform.position,
                Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.name.Contains("Knight"))
        {
            //プレイヤーにダメージを与える
            var knight = collision.GetComponent<Knight>();
            if (knight == null) return;
            knight.Damage(damage);
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
