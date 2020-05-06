using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playattack : MonoBehaviour
{
    public int playerDamage = 2;//玩家伤害
    public float time = 0.24f;//攻击持续时间
    public float startTime = 0.01f;//伤害计算开始时间

    private Animator my_anim;//玩家动画
    private PolygonCollider2D my_coll2D;//玩家攻击的碰撞体

    // Start is called before the first frame update
    void Start()
    {
        my_anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();//获取玩家标签的动画
        my_coll2D = GetComponent<PolygonCollider2D>();//获取攻击的碰撞体
    }

    // Update is called once per frame
    void Update()
    {
        Attack();//攻击
    }

    void Attack()
    {
        if(Input.GetButtonDown("Attack"))//如果按键点击了攻击键
        {
            my_anim.SetTrigger("Attack");//Attack参数被激活
            StartCoroutine(StartAttack());//伤害判定
        }
    }


    IEnumerator StartAttack()
    {
        //Debug.Log("1");//调试信息
        yield return new WaitForSeconds(startTime);//等待时间后
        my_coll2D.enabled = true;//打开攻击的碰撞体范围
        StartCoroutine(DisableHitBox());
    }

    IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(time);//等待时间后
        my_coll2D.enabled = false;//关闭攻击的碰撞体
    }

    //当触发器被触发时，执行下面代码
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemie"))//寻找标签为Enemie的物体
        {
            other.GetComponent<Enemies>().TakeDamage(playerDamage);//运行Enemies脚本的TakeDamage函数
        }
    }
}
