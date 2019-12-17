
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spown : MonoBehaviour
{
    public GameObject player; //プレイヤー
    public List<GameObject> enemys; //エネミーリスト
    public Transform player_Spown_Position; //プレイヤーの登場位置
    public List<Transform> enemy_Spown_Position; //エネミーの登場位置
    public Explotion spwanEffectPrefab; //登場エフェクト
    public float spwanInterval; //敵を生成する間隔
    public float time; //時間

    Vector3 pos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, player_Spown_Position.position, Quaternion.identity);
        //Instantiate(enemys[0], enemy_Spown_Position.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (spwanInterval > time) return;

        time = 0;

        StartCoroutine("EnemySpawn");
        
    }

    IEnumerator EnemySpawn()
    {
        pos = enemy_Spown_Position
    [Random.Range(0, enemy_Spown_Position.Count)].
    position;
        Instantiate(spwanEffectPrefab, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemys[0], pos, Quaternion.identity);

    }
}
