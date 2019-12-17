using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject camera0;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject entrance1;
    public GameObject entrance2;
    public GameObject entrance3;
    public GameObject[] enemy;
    public GameObject item;
    bool callEnemy;
    public GameObject[] entrance;
    int enemynum;
    public int enemylim;
    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = player.transform.position;
        if(pos.y<-2)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }
        if (pos.x< entrance1.transform.position.x && pos.y> entrance1.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }
        if (pos.x > entrance1.transform.position.x && pos.y > entrance1.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(true);
            camera4.SetActive(false);
        }
        if (pos.y > entrance2.transform.position.y)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(true);
            if (!callEnemy)
            {
                int e = 0;
                enemynum = Random.Range(0, 2);
                enemylim = Random.Range(2, 4);
                while (e < enemylim)
                {
                    Instantiate(enemy[enemynum], new Vector3(Random.Range(-3.7f, 5.2f), Random.Range(2.7f, 5.2f), 0), transform.rotation);
                    enemynum = Random.Range(0, 2);
                    e++;
                }
                callEnemy = true;
            }

        }
        if (pos.y > entrance3.transform.position.y)
        {
            SceneManager.LoadScene("Stage02");
        }
        if (Input.GetKey(KeyCode.RightControl)|| Input.GetKey(KeyCode.LeftControl))
        {
            camera0.SetActive(true);
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            camera0.SetActive(false);
        }
    }
}
