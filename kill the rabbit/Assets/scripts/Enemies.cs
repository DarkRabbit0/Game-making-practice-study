using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int health;//HP
    public int enemyDamage;//怪物伤害
    public float flashTime;//闪烁时间
    private SpriteRenderer sr;//怪物控件
    private Color original_color;//原来颜色
    public GameObject bloodEffect;//血液流逝特效

    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        original_color = sr.color;
        flashTime = 0.3f;
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0)
        {
            Debug.Log("die");//调试信息
            Destroy(gameObject);//怪物消失
        }
    }

    public void TakeDamage(int playerdamage)
    {
        Debug.Log(health);//调试信息
        health -= playerdamage;//HP减少
        FlashColor(Color.red,flashTime);//闪烁颜色
        Instantiate(bloodEffect, transform.position, Quaternion.identity);//创建粒子特效
        GameController.camShake.Shake();
    }

    //控制闪烁颜色和时间
    public void FlashColor(Color injuredcolor, float time)
    {
        sr.color = injuredcolor;
        Invoke("ResetColor",time);
    }

//改变颜色为初始颜色
    public void ResetColor()
    {
        sr.color = original_color;
    }
}
