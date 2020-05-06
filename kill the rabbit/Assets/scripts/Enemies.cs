using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int health;
    public int enemydamage;
    public float flashtime;
    private SpriteRenderer sr;
    private Color originalColor;

    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        flashtime = 0.3f;
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0)
        {
            Debug.Log("die");//调试信息
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int playerdamage)
    {
        Debug.Log(health);//调试信息
        health -= playerdamage;
        FlashColor(Color.red,flashtime);
    }

    public void FlashColor(Color injuredcolor, float time)
    {
        sr.color = injuredcolor;
        Invoke("ResetColor",time);
    }

    public void ResetColor()
    {
        sr.color = originalColor;
    }
}
