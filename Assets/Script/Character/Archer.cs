using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public static Archer instance; //アーチャーのインスタンス

    public float moveSpeed;  //移動の速さ
    public Arrow arrow;      //矢のプレハブ
    public float arrowSpeed; //矢の移動の速さ

    public int playerHp;    //現在のHP
    public int playerMaxHp; //最大のHP
    public int playerMp;    //現在のMP
    public int playerMaxMp; //最大のMP

    GameObject operation;
    Operation operationScript;

    Direction direciton = Direction.DOWN; //現在の向き
    Animator anim; //アニメーター
    Rigidbody2D playerRigidbody; //プレイヤーRigidbody
    bool isAttack = false; //攻撃中か？
    float playerAngle; //プレイヤーの方向
    new CapsuleCollider2D collider2D;
    float mpCount;　//Mp回復スピード


    void Awake()
    {
        instance = this;
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        operation = GameObject.Find("Operation");
        operationScript = operation.GetComponent<Operation>();
        collider2D = GetComponent<CapsuleCollider2D>();
        playerHp = playerMaxHp; //Hpを最大に設定
        //playerMp = playerMaxMp;
    }
    int count;
    // Update is called once per frame
    void Update()
    {

       
        if (operationScript.GetArcherFlag())
        {
            collider2D.enabled = true;
            //マウスのほうへ向く
            //プレイヤーのスクリーン座標を計算する
            var screenPos = Camera.main.WorldToScreenPoint(transform.position);
            //プレイヤーから見たマウスカーソルの方向を計算する
            var direction = Input.mousePosition - screenPos;
            playerAngle = Utils.GetAngle(Vector3.zero, direction);
            var angles = transform.localEulerAngles;
            angles.z = playerAngle;
            //方向決定
            PlayerRote(playerAngle);

            //メニューが閉じているなら
            if (Time.timeScale > 0)
            {
                //攻撃する
                Attack();
            }
        }
        else if (!operationScript.GetArcherFlag())
        {
            //Mp回復
            mpCount += Time.deltaTime;
            if (mpCount >= 1 && playerMaxMp >= playerMp)
            {
                playerMp += 5;
                mpCount = 0;
            }

            collider2D.enabled = false;
            var direction = Knight.instance.transform.position - transform.position;
            var angle = Utils.GetAngle(Vector3.zero, direction);
            PlayerRote(angle);
            Tracking();

        }
       
    }

    private void FixedUpdate()
    {
        if (operationScript.GetArcherFlag())
        {
            //＊移動＊
            //攻撃してない時
            if (isAttack == false)
            {
                //Playerの移動
                // 右・左
                float x = Input.GetAxisRaw("Horizontal");
                // 上・下
                float y = Input.GetAxisRaw("Vertical");
                //移動する
                Move(x, y);
            }
        }
       
    }

    void Tracking()
    {
        if (Knight.instance.gameObject.transform.localPosition != transform.localPosition)
        {
            playerRigidbody.velocity = Vector2.zero;
            float _range = 0.25f;
            float _speed = 0.033f;
            if (Knight.instance.transform.position.x > transform.position.x + _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position,
                    new Vector3(Knight.instance.transform.position.x
                    - _range, Knight.instance.transform.position.y),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x - _range, Archer.archerInstance.transform.position.y);
            }
            if (Knight.instance.transform.position.x < transform.position.x - _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                    new Vector3(Knight.instance.transform.position.x + _range, Knight.instance.transform.position.y),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x + _range, Archer.archerInstance.transform.position.y);
            }
            if (Knight.instance.transform.position.y > transform.position.y + _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position,
                    new Vector3(Knight.instance.transform.position.x, Knight.instance.transform.position.y - _range),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x, Archer.archerInstance.transform.position.y - _range);
            }
            if (Knight.instance.transform.position.y < transform.position.y - _range)
            {
                transform.position = Vector3.MoveTowards(transform.localPosition,
                    new Vector3(Knight.instance.transform.position.x, Knight.instance.transform.position.y + _range),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x, Archer.archerInstance.transform.position.y + _range);
            }
        }
    }

    //移動
    private void Move(float h, float v)
    {
        Vector2 movement = Vector2.zero;
        movement.Set(h, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + movement);
    }

    void HomingMove()
    {
        Vector2 magePosition = transform.position;
        Vector2 playerPosition = Player.instance.transform.position;
        float vx = playerPosition.x - magePosition.x;
        float vy = playerPosition.y - magePosition.y;
        float dx, dy, radius;

        radius = Mathf.Atan2(vy, vx);
        dx = Mathf.Cos(radius) * moveSpeed;
        dy = Mathf.Sin(radius) * moveSpeed;

        if (Mathf.Abs(vx) < 0.1f)
        {
            dx = 0;
        }
        if (Mathf.Abs(vy) < 0.1f)
        {
            dy = 0;
        }

        magePosition.x += dx;
        magePosition.y += dy;

        gameObject.transform.localPosition = magePosition;

    }

    //マウスのほうへ向く
    void PlayerRote(float playerAngle)
    {
        //上を向く
        if (68 <= playerAngle && playerAngle < 113)
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
        if (23 <= playerAngle && playerAngle < 68)
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
        if (-23 <= playerAngle && playerAngle < 23)
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
        if (-68 <= playerAngle && playerAngle < -23)
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
        if (-113 <= playerAngle && playerAngle < -68)
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
        if (-158 <= playerAngle && playerAngle < -113)
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
        if (-158 > playerAngle || playerAngle >= 158)
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
        if (113 <= playerAngle && playerAngle < 158)
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

    void Attack()
    {
        //攻撃
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            //上
            if (direciton == Direction.UP)
            {
            }
            //右上
            if (direciton == Direction.UPRIGHT)
            {

            }
            //右
            if (direciton == Direction.RIGHT)
            {

            }
            //右下
            if (direciton == Direction.DOWNRIGHT)
            {

            }
            //下
            if (direciton == Direction.DOWN)
            {

            }
            //左下
            if (direciton == Direction.DOWNLEFT)
            {

            }
            //左
            if (direciton == Direction.LEFT)
            {

            }
            //左上
            if (direciton == Direction.UPLEFT)
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //矢を発射する
            ShootNWay( playerAngle, 0, arrowSpeed, 1);
        }
    }

    //弾を発射する
    private void ShootNWay(
        float angleBase, float angleRange, float speed, int count)
    {
        var pos = transform.localPosition; //プレイヤーの位置

        if(1 < count)
        {
            for(int i = 0; i < count; i++)
            {
                //弾の発射角を計算する
                var angle = angleBase +
                    angleRange * ((float)i / (count - 1) - 0.5f);

                //発射する弾を生成する
                var shot = Instantiate(arrow, pos, Quaternion.identity);

                shot.Init(angle, speed);
            }
        }
        else if( count == 1)
        {
            var shot = Instantiate(arrow, pos, Quaternion.identity);

            shot.Init(angleBase, speed);
        }

        
    }

}
