using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LegendaryTreasure : MonoBehaviour
{
    GameObject knight;
    GameObject archer;
    GameObject mage;
    GameObject checker;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Knight");
        archer = GameObject.FindGameObjectWithTag("Archer");
        mage = GameObject.FindGameObjectWithTag("Mage");
        checker = GameObject.FindGameObjectWithTag("ItemChecker");
    }

    // Update is called once per frame
    void Update()
    {
        float pos = (transform.position - knight.transform.position).magnitude;
        float mage_pos = (transform.position - mage.transform.position).magnitude;
        float archer_pos = (transform.position - archer.transform.position).magnitude;

        if (pos < 0.5f && pos > -0.5f
            || mage_pos < 0.5f && mage_pos > -0.5f
            || mage_pos < 0.5f && mage_pos > -0.5f)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(knight);
                Destroy(checker);
                Destroy(mage);
                Destroy(archer);

                SceneManager.LoadScene("GameClear");
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
