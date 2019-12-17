using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LegendaryTreasure : MonoBehaviour
{
    GameObject player;
    GameObject checker;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        checker = GameObject.FindGameObjectWithTag("ItemChecker");
    }

    // Update is called once per frame
    void Update()
    {
        float pos = (transform.position - player.transform.position).magnitude;
        if (pos < 0.5f && pos > -0.5f)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(player);
                Destroy(checker);

                SceneManager.LoadScene("TitleScene");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
    }
}
