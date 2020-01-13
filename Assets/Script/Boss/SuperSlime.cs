using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSlime : MonoBehaviour
{
    public float moveSpeed; //移動速度
    public float shotSpeed; //ショットスピード
    public int bossHp; //現在のHp
    public int bossMaxHp; //最大のHp
    public GameObject slimeShot; //スライムショット

    public float shotInterval; //ショットの間隔
   float shotCount; //shotカウント
   

    public Explotion explosionPrefab; //爆発エフェクト


    // Start is called before the first frame update
    void Start()
    {
        //スタート位置を設定
        transform.position = new Vector3(-8, -3);
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
}
