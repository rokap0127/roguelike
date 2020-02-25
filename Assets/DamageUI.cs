using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    private float fadeOutSpeed = 1.0f;
    private float moveSpeed = 0.4f;
    Text damageText;

    // Start is called before the first frame update
    void Start()
    {
        damageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        damageText.color = Color.Lerp(damageText.color, new Color(1.0f, 0f, 0f, 0f), fadeOutSpeed * Time.deltaTime);

        if (damageText.color.a <= 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
