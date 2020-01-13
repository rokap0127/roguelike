using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSlime : MonoBehaviour
{
    public float moveSpeed; //移動速度
    public int bossHp; //現在のHp
    public int bossMaxHp; //最大のHp
    public GameObject slimeShot;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SlimeShot();
        }

    }

    void SlimeShot()
    {
        var slime = Instantiate(slimeShot, transform.position, Quaternion.identity);
        var rb = slime.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(100, 100));

    }
}
