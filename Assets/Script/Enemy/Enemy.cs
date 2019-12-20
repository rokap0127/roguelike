﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RESPAWN_TYPE
{
    UP,     //上
    RIGHT,  //右
    DOWN,   //下
    LEFT,   //左
    SIZEOF, //敵の出現位置の数
}

public class Enemy : MonoBehaviour
{
    public Vector2 m_respawnPosInside; //敵の出現位置（内側）
    public Vector2 m_respawnPosOutside; //敵の出現位置（外側）
    public float m_speed; //移動する速さ
    public int m_hpMax; //HPの最大値
    public int m_exp; //この敵を倒したときに獲得できる経験値
    public int m_damage; //この敵がプレイヤーに与えるダメージ
    public Explotion explosionPrefab; //爆発エフェクト

    private int m_hp; //HP
    private Vector3 m_direction; //進行方向

    //敵が生成したときに呼び出される関数
    void Start()
    {
        //HPを初期化する
        m_hp = m_hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        //まっすぐ移動する
        transform.localPosition += m_direction * m_speed;
    }

    //敵が出現するときに初期化する関数
    public void Init(RESPAWN_TYPE respwanType)
    {
        var pos = Vector3.zero;

        //指定された出現位置の種類に応じて
        //出現位置と進行方向を決定する
        switch (respwanType)
        {
            //出現位置が上の場合
            case RESPAWN_TYPE.UP:
                pos.x = Random.Range(
                    -m_respawnPosInside.x, m_respawnPosInside.x);
                pos.y = m_respawnPosOutside.y;
                m_direction = Vector2.down;
                break;

            //出現位置が右の場合
            case RESPAWN_TYPE.RIGHT:
                pos.x = m_respawnPosOutside.x;
                pos.y = Random.Range(
                    -m_respawnPosInside.y, m_respawnPosInside.y);
                m_direction = Vector2.left;
                break;

            //出現位置が下の場合
            case RESPAWN_TYPE.DOWN:
                pos.x = Random.Range(
                    -m_respawnPosInside.x, m_respawnPosInside.x);
                pos.y = -m_respawnPosOutside.y;
                m_direction = Vector2.up;
                break;

            //出現位置が左の場合
            case RESPAWN_TYPE.LEFT:
                pos.x = -m_respawnPosOutside.x;
                pos.y = Random.Range(
                    -m_respawnPosInside.y, m_respawnPosInside.y);
                m_direction = Vector2.right;
                break;
        }
        //位置を反映する
        transform.localPosition = pos;
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
            m_hp--;

            //敵のHPがまだ残っている場合はここで処理を終える
            if(0 < m_hp) { return; }

            //敵を削除する
            Destroy(gameObject);
        }
    }
}
