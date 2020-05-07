using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int enemiesHP;//HP
    public int enemyDamage;//怪物伤害
    public float flashTime;//闪烁时间
    public GameObject bloodEffect;//血液流逝特效

    private SpriteRenderer sr;//怪物控件
    private Color original_color;//原来颜色
    private playHP play_hp;//获取玩家的生命控件
    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();//控体
        original_color = sr.color;//颜色
        flashTime = 0.3f;//闪烁时间
        play_hp = GameObject.FindGameObjectWithTag("Player").GetComponent<playHP>();//通过标签绑定玩家生命值脚本
    }

    // Update is called once per frame
    public void Update()
    {
        if(enemiesHP <= 0)
        {
            Debug.Log("die");//调试信息
            Destroy(gameObject);//怪物消失
        }
    }

    public void TakeDamage(int playerdamage)
    {
        Debug.Log(enemiesHP);//调试信息
        enemiesHP -= playerdamage;//HP减少
        FlashColor(Color.red,flashTime);//闪烁颜色
        Instantiate(bloodEffect, transform.position, Quaternion.identity);//创建粒子特效
        
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() ==  "UnityEngine.CapsuleCollider2D")//寻找标签为Enemie的物体
        {
            if(play_hp != null)
            {
                play_hp.HurtPlayer(enemyDamage);
            }
        }
    }


}
