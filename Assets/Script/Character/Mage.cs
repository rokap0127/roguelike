using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public static Mage instance; //メイジのインスタンス
    public float moveSpeed; //移動の速さ
    public Magic magic; //魔法のプレハブ
    public float magicSpeed; //魔法の速度
    public float teleportRange; //テレポートの距離
    public float slopeRange; //テレオート時間

    public int playerHp;    //現在のHP
    public int playerMaxHp; //最大のHP
    public int playerMp;    //現在のMP
    public int playerMaxMp; //最大のMP

    public int shootMp;


    GameObject operation;
    Operation operationScript;

    Direction direciton = Direction.DOWN; //現在の向き
    Animator anim; //アニメーター
    Rigidbody2D playerRigidbody; //プレイヤーRigidbody
    bool isAttack = false; //攻撃中か？
    float magicAngle; //魔法の角度
    new CapsuleCollider2D collider2D;
    float mpCount;　//Mp回復スピード

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        operation = GameObject.Find("Operation");
        operationScript = operation.GetComponent<Operation>();
        collider2D = GetComponent<CapsuleCollider2D>();
        playerHp = playerMaxHp;　//Hpを最大に設定する
        //playerMp = playerMaxMp;
    }

    void Awake()
    {
        instance = this;
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (operationScript.GetMageFlag() == true)
        {
            collider2D.enabled = true;
            //マウスのほうへ向く
            //プレイヤーのスクリーン座標を計算する
            var screenPos = Camera.main.WorldToScreenPoint(transform.position);
            //プレイヤーから見たマウスカーソルの方向を計算する
            var direction = Input.mousePosition - screenPos;
            magicAngle = Utils.GetAngle(Vector3.zero, direction);
            var angles = transform.localEulerAngles;
            angles.z = magicAngle;
            //方向指定
            PlayerRote(magicAngle);

            //メニューが閉じているなら
            if (Time.timeScale > 0)
            {
                //攻撃する
                Attack();
            }

            Teleport(teleportRange, slopeRange);

        }
        else if (operationScript.GetMageFlag() == false)
        {
            //Mp回復
            mpCount += Time.deltaTime;
            if (mpCount >= 1 && playerMaxMp >= playerMp)
            {
                playerMp += 5;
                mpCount = 0;
            }

            collider2D.enabled = false;
            var direction = Archer.instance.transform.position - transform.position;
            var angle = Utils.GetAngle(Vector3.zero, direction);
            //向き指定
            PlayerRote(angle);
            Tracking();


        }      
    }

    private void FixedUpdate()
    {
        if (operationScript.GetMageFlag() == true)
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

    //追尾する
    void Tracking()
    {
        if (Archer.instance.gameObject.transform.localPosition != transform.localPosition)
        {
            playerRigidbody.velocity = Vector2.zero;
            float _range = 0.3f;
            float _speed = 0.03f;
            if (Archer.instance.transform.position.x > transform.position.x + _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position,
                    new Vector3(Archer.instance.transform.position.x
                    - _range, Archer.instance.transform.position.y),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x - _range, Archer.archerInstance.transform.position.y);
            }
            if (Archer.instance.transform.position.x < transform.position.x - _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                    new Vector3(Archer.instance.transform.position.x + _range, Archer.instance.transform.position.y),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x + _range, Archer.archerInstance.transform.position.y);
            }
            if (Archer.instance.transform.position.y > transform.position.y + _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position,
                    new Vector3(Archer.instance.transform.position.x, Archer.instance.transform.position.y - _range),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x, Archer.archerInstance.transform.position.y - _range);
            }
            if (Archer.instance.transform.position.y < transform.position.y - _range)
            {
                transform.position = Vector3.MoveTowards(transform.localPosition,
                    new Vector3(Archer.instance.transform.position.x, Archer.instance.transform.position.y + _range),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x, Archer.archerInstance.transform.position.y + _range);
            }
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="h">x方向</param>
    /// <param name="v">ｙ方向</param>
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

        if(Mathf.Abs(vx) < 0.1f)
        {
            dx = 0;
        }
        if(Mathf.Abs(vy) < 0.1f)
        {
            dy = 0;
        }

        magePosition.x += dx;
        magePosition.y += dy;

        gameObject.transform.localPosition = magePosition;

    }

    //マウスのほうへ向く
    void PlayerRote(float magicAngle)
    {

        //上を向く
        if (68 <= magicAngle && magicAngle < 113)
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
        if (23 <= magicAngle && magicAngle < 68)
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
        if (-23 <= magicAngle && magicAngle < 23)
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
        if (-68 <= magicAngle && magicAngle < -23)
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
        if (-113 <= magicAngle && magicAngle < -68)
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
        if (-158 <= magicAngle && magicAngle < -113)
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
        if (-158 > magicAngle || magicAngle >= 158)
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
        if (113 <= magicAngle && magicAngle < 158)
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(playerMp > shootMp)
            {
                //1発撃つ
                ShootNWay(magicAngle, 0, magicSpeed, 1);

                playerMp -= shootMp;
            }
           
        }
    }

    /// <summary>
    /// 弾を発射する
    /// </summary>
    /// <param name="angleBase">発射角</param>
    /// <param name="angleRange">複数発射する時の角度</param>
    /// <param name="speed">速さ</param>
    /// <param name="count">発射数</param>
    private void ShootNWay(
       float angleBase, float angleRange, float speed, int count)
    {
        var pos = transform.localPosition; //プレイヤーの位置

        if (1 < count)
        {
            for (int i = 0; i < count; i++)
            {
                //弾の発射角を計算する
                var angle = angleBase +
                    angleRange * ((float)i / (count - 1) - 0.5f);

                //発射する弾を生成する
                var shot = Instantiate(magic, pos, Quaternion.identity);

                shot.Init(angle, speed);
            }
        }
        else if (count == 1)
        {
            var shot = Instantiate(magic, pos, Quaternion.identity);

            shot.Init(angleBase, speed);
        }
    }

    private void Teleport(float range, float slopeRange)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //上
            if (direciton == Direction.UP)
            {
                transform.position += new Vector3(0, range);
            }
            //右上
            if (direciton == Direction.UPRIGHT)
            {
                transform.position += new Vector3(slopeRange, slopeRange);
            }
            //右
            if (direciton == Direction.RIGHT)
            {
                transform.position += new Vector3(range, 0);
            }
            //右下
            if (direciton == Direction.DOWNRIGHT)
            {
                transform.position += new Vector3(slopeRange, -slopeRange);
            }
            //下
            if (direciton == Direction.DOWN)
            {
                transform.position += new Vector3(0, -range);
            }
            //左下
            if (direciton == Direction.DOWNLEFT)
            {
                transform.position += new Vector3(-slopeRange, -slopeRange);
            }
            //左
            if (direciton == Direction.LEFT)
            {
                transform.position += new Vector3(-range, 0);
            }
            //左上
            if (direciton == Direction.UPLEFT)
            {
                transform.position += new Vector3(-slopeRange, slopeRange);
            }
        }
    }
}
