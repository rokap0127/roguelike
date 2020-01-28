using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,0,3));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Playerにダメージ
        if (collision.name.Contains("Knight"))
        {
            //プレイヤーにダメージを与える
            var knight = collision.GetComponent<Knight>();
            if (knight == null) return;
            knight.Damage(damage);
        }
        if (collision.name.Contains("Archer"))
        {
            //プレイヤーにダメージを与える
            var archer = collision.GetComponent<Archer>();
            if (archer == null) return;
            archer.Damage(damage);
        }
        if (collision.name.Contains("Mage"))
        {
            //プレイヤーにダメージを与える
            var mage = collision.GetComponent<Mage>();
            if (mage == null) return;
            mage.Damage(damage);
        }
    }
}
