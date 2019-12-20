using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += velocity;
    }

    public void Init(float angle, float speed)
    {
        //弾の発射角度をベクトルに変換する
        var direction = Utils.GetDirection(angle);

        //発射角度と速さから速度を求める
        velocity = direction * speed;

        //弾が進行方向を向くようにする
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        //10秒後削除する
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.Contains("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
