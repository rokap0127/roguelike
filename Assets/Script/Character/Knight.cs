using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//向き
enum Direction
{
    UP, //上
    UPRIGHT, //右上
    RIGHT, //右
    DOWNRIGHT, //右下
    DOWN, //下
    DOWNLEFT, //左下
    LEFT, //左
    UPLEFT, //左上
};

//Knight専用Script
public class Knight : MonoBehaviour
{
    public float moveSpeed; //移動速度
    public float guard_MoveSpeed; //ガード中の移動速度
    public int playerHp; //HP
    public GameObject playerAttack; //攻撃オブジェクト
    public GameObject guard; //ガードオブジェクト
    public static Knight knightInstance;
    public int MaxHp;

    GameObject operation;
    Operation operationScript;
    CapsuleCollider2D collider2D;


    float speed; //スピードを一時的に保存する
    GameObject guard_Prefab; //ガードのプレハブ
    Direction direciton = Direction.DOWN; //現在の向き
    Rigidbody2D playerRigidbody; //プレイヤーRigidbody
    Animator anim; //アニメーター
    SpriteRenderer spriteRenderer; //スプライトレンダラー
    bool isAttack = false; //攻撃中か？

    ItemChecker ic;
    float defaultMoveSpeed;

    void Awake()
    {
        knightInstance = this;
        //シーンが変わっても削除されない
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHp = MaxHp;
        operation = GameObject.Find("Operation");
        operationScript = operation.GetComponent<Operation>();
        collider2D = GetComponent<CapsuleCollider2D>();
        defaultMoveSpeed = moveSpeed;
        ic = GetComponent<ItemChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (operationScript.GetKnightFlag())
        {
            collider2D.enabled = true;
            //マウスを向けた方向を向く
            //プレイヤーのスクリーン座標を計算する
            var screenPos = Camera.main.WorldToScreenPoint(transform.position);
            //プレイヤーから見たマウスカーソルの方向を計算する
            var direction = Input.mousePosition - screenPos;
            var angle = Utils.GetAngle(Vector3.zero, direction);
            var angles = transform.localEulerAngles;
            angles.z = angle;
            PlayerRote(angle);

            //ガードする
            Guard();

            //攻撃する
            Attack();


            if (playerHp >= MaxHp)
            {
                playerHp = MaxHp;
            }
            if (playerHp <= 0 && !ic.RevivalFlag)
            {
                gameObject.SetActive(false);
                Invoke("ChangeScene", 0.5f);
                Invoke("Death", 0.51f);
            }
            if (!ic.SpeedFlag)
            {
                moveSpeed = defaultMoveSpeed;
            }
        }
        else if (!operationScript.GetKnightFlag())
        {
            collider2D.enabled = false;
            Tracking();

            var direction = Mage.mageInstance.transform.position - transform.position;
            var angle = Utils.GetAngle(Vector3.zero, direction);
            //向き指定
            PlayerRote(angle);

        }
    }

    private void FixedUpdate()
    {

        //＊移動＊
        if (operationScript.GetKnightFlag())
        {
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
        if (Mage.mageInstance.gameObject.transform.localPosition != transform.localPosition)
        {
            playerRigidbody.velocity = Vector2.zero;
            float _range = 0.3f;
            float _speed = 0.05f;
            if (Mage.mageInstance.transform.position.x > transform.position.x + _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position,
                    new Vector3(Mage.mageInstance.transform.position.x
                    - _range, Mage.mageInstance.transform.position.y),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x - _range, Archer.archerInstance.transform.position.y);
            }
            if (Mage.mageInstance.transform.position.x < transform.position.x - _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                    new Vector3(Mage.mageInstance.transform.position.x + _range, Mage.mageInstance.transform.position.y),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x + _range, Archer.archerInstance.transform.position.y);
            }
            if (Mage.mageInstance.transform.position.y > transform.position.y + _range)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position,
                    new Vector3(Mage.mageInstance.transform.position.x, Mage.mageInstance.transform.position.y - _range),
                    _speed);
                //transform.position = new Vector2(Archer.archerInstance.transform.position.x, Archer.archerInstance.transform.position.y - _range);
            }
            if (Mage.mageInstance.transform.position.y < transform.position.y - _range)
            {
                transform.position = Vector3.MoveTowards(transform.localPosition,
                    new Vector3(Mage.mageInstance.transform.position.x, Mage.mageInstance.transform.position.y + _range),
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

    void Attack()
    {
        //攻撃
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            //上
            if (direciton == Direction.UP)
            {
                //攻撃オブジェクトを生成する
                GameObject attack_object = Instantiate(playerAttack,
                    transform.localPosition + new Vector3(0, 0.2f),
                    Quaternion.identity);
                attack_object.transform.parent = transform;
                //anim.Play("Attack_Up");
                isAttack = true;
                StartCoroutine("WaitForAttack");
                //up_Attack.SetActive(true);
            }
            //右上
            if (direciton == Direction.UPRIGHT)
            {
                //攻撃オブジェクトを生成する
                GameObject attack_object = Instantiate(playerAttack,
                    transform.localPosition + new Vector3(0.1f, 0.1f),
                    Quaternion.Euler(0, 0, -45));
                attack_object.transform.parent = transform;
                isAttack = true;
                StartCoroutine("WaitForAttack");

            }
            //右
            if (direciton == Direction.RIGHT)
            {
                //攻撃オブジェクトを生成する
                GameObject attack_object = Instantiate(playerAttack,
                    transform.localPosition + new Vector3(0.2f, 0),
                    Quaternion.Euler(0, 0, 90));
                attack_object.transform.parent = transform;
                //anim.Play("Attack_Right");
                isAttack = true;
                StartCoroutine("WaitForAttack");
                //right_Attack.SetActive(true);
            }
            //右下
            if (direciton == Direction.DOWNRIGHT)
            {
                //攻撃オブジェクトを生成する
                GameObject attack_object = Instantiate(playerAttack,
                    transform.localPosition + new Vector3(0.1f, -0.1f),
                      Quaternion.Euler(0, 0, 45));
                attack_object.transform.parent = transform;
                isAttack = true;
                StartCoroutine("WaitForAttack");
            }
            //下
            if (direciton == Direction.DOWN)
            {
                //攻撃オブジェクトを生成する
                GameObject attack_object = Instantiate(playerAttack,
                    transform.localPosition + new Vector3(0, -0.2f),
                    Quaternion.identity);
                attack_object.transform.parent = transform;
                //anim.Play("Attack_Down");
                isAttack = true;
                StartCoroutine("WaitForAttack");
                //down_Attack.SetActive(true);
            }
            //左下
            if (direciton == Direction.DOWNLEFT)
            {
                //攻撃オブジェクトを生成する
                GameObject attack_object = Instantiate(playerAttack,
                    transform.localPosition + new Vector3(-0.1f, -0.1f),
                     Quaternion.Euler(0, 0, -45));
                attack_object.transform.parent = transform;
                isAttack = true;
                StartCoroutine("WaitForAttack");
            }
            //左
            if (direciton == Direction.LEFT)
            {
                //攻撃オブジェクトを生成する
                GameObject attack_object = Instantiate(playerAttack,
                    transform.localPosition + new Vector3(-0.2f, 0),
                    Quaternion.Euler(0, 0, 90));
                attack_object.transform.parent = transform;
                //anim.Play("Attack_Left");
                isAttack = true;
                StartCoroutine("WaitForAttack");
                //left_Attack.SetActive(true);
            }
            //左上
            if (direciton == Direction.UPLEFT)
            {
                //攻撃オブジェクトを生成する
                GameObject attack_object = Instantiate(playerAttack,
                    transform.localPosition + new Vector3(-0.1f, 0.1f),
                   Quaternion.Euler(0, 0, 45));
                attack_object.transform.parent = transform;
                isAttack = true;
                StartCoroutine("WaitForAttack");
            }
        }
    }

    //ガード
    void Guard()
    {
        //スペース押したとき
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //数値を取っておく
            speed = moveSpeed;
            //ガード中のスピードにする
            moveSpeed = guard_MoveSpeed;

            //上
            if (direciton == Direction.UP)
            {
                //ガード生成
                guard_Prefab = Instantiate(guard,
                    transform.localPosition + new Vector3(0, 0.2f),
                    Quaternion.identity);
                guard_Prefab.transform.parent = transform;
                anim.SetBool("Guard@Up", true);
            }
            //右上
            if (direciton == Direction.UPRIGHT)
            {
                //ガード生成
                guard_Prefab = Instantiate(guard,
                    transform.localPosition + new Vector3(0.1f, 0.1f),
                   Quaternion.Euler(0, 0, -45));
                guard_Prefab.transform.parent = transform;
            }
            //右
            if (direciton == Direction.RIGHT)
            {
                //ガード生成
                guard_Prefab = Instantiate(guard,
                    transform.localPosition + new Vector3(0.2f, 0),
                    Quaternion.Euler(0, 0, 90));
                guard_Prefab.transform.parent = transform;
                anim.SetBool("Guard@Right", true);
            }
            //右下
            if (direciton == Direction.DOWNRIGHT)
            {
                //ガード生成
                guard_Prefab = Instantiate(guard,
                    transform.localPosition + new Vector3(0.1f, -0.1f),
                    Quaternion.Euler(0, 0, 45));
                guard_Prefab.transform.parent = transform;
            }
            //下
            if (direciton == Direction.DOWN)
            {
                //ガード生成
                guard_Prefab = Instantiate(guard, transform.
                    localPosition + new Vector3(0, -0.2f),
                    Quaternion.identity);
                guard_Prefab.transform.parent = transform;
                anim.SetBool("Guard@Down", true);
            }
            //左下
            if (direciton == Direction.DOWNLEFT)
            {
                //ガード生成
                guard_Prefab = Instantiate(guard,
                    transform.localPosition + new Vector3(-0.1f, -0.1f),
                    Quaternion.Euler(0, 0, -45));
                guard_Prefab.transform.parent = transform;
            }
            //左
            if (direciton == Direction.LEFT)
            {
                //ガード生成
                guard_Prefab = Instantiate(guard,
                    transform.localPosition + new Vector3(-0.2f, 0),
                    Quaternion.Euler(0, 0, 90));
                guard_Prefab.transform.parent = transform;
                anim.SetBool("Guard@Left", true);
            }
            //左上
            if (direciton == Direction.UPLEFT)
            {
                //ガード生成
                guard_Prefab = Instantiate(guard,
                    transform.localPosition + new Vector3(-0.1f, 0.1f),
                    Quaternion.Euler(0, 0, 45));
                guard_Prefab.transform.parent = transform;
            }
        }

        //キーを離したとき
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //速さをもとに戻す
            moveSpeed = speed;
            //オブジェクトを削除する
            Destroy(guard_Prefab);
            //アニメーションオフ
            anim.SetBool("Guard@Down", false);
            anim.SetBool("Guard@Up", false);
            anim.SetBool("Guard@Right", false);
            anim.SetBool("Guard@Left", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //    if(collision.gameObject.tag == "Enemy" &&
        //        gameObject.tag != "Guard")
        //    {
        //        StartCoroutine(Blinl());
        //        playerHp -= 10;
        //    }
        if (collision.gameObject.tag == "HPportion")
        {
            playerHp += 10;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy" &&
    //        gameObject.tag != "Guard")
    //    {

    //            StartCoroutine(Blinl());
    //            playerHp -= 10;

    //    }
    //}


    //攻撃してるとき1時停止する
    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
    }

    //点滅
    IEnumerator Blinl()
    {
        var renderComponent = GetComponent<Renderer>();
        renderComponent.enabled = !renderComponent.enabled;
        //yield return new WaitForSeconds(0.2f);
        yield return null;
        renderComponent.enabled = !renderComponent.enabled;
    }

    //ダメージを与える
    public void Damage(int damage)
    {
        playerHp -= damage;

        //HPがまだある場合、ここで処理を終える
        if (0 < playerHp) { return; }

        gameObject.SetActive(false);
    }
}
