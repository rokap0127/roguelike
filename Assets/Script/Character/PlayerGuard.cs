using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuard : MonoBehaviour
{
    public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ////プレイヤーよりｘが1大きい
        //if (playerPosition.position.x > playerPosition.position.x + 1)
        //{
        //    transform.position = new Vector2(playerPosition.position.x + 2, playerPosition.position.y);
        //}
        ////プレイヤーよりｘが1小さい
        //if (playerPosition.position.x < playerPosition.position.x - 1)
        //{
        //    transform.position = new Vector2(playerPosition.position.x - 2, playerPosition.position.y);
        //}
        ////プレイヤーよりｙが1大きい
        //if (playerPosition.position.y > playerPosition.position.y + 1)
        //{
        //    transform.position = new Vector2(playerPosition.position.x, playerPosition.position.y + 2);
        //}
        ////プレイヤーよりｙが1小さい
        //if (playerPosition.position.y < playerPosition.position.y - 1)
        //{
        //    transform.position = new Vector2(playerPosition.position.x, playerPosition.position.y - 2);
        //}
    }


}
