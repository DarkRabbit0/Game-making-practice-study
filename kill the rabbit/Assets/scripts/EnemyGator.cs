using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGator : Enemies
{
    public float speed;//移动速度
    public float startWaitTime;//等待时间

    private float wait_time;//等待时间


    public Transform movePos;//当前坐标
    public Transform leftDownPos;//左下角范围
    public Transform rightUpPos;//右上角范围

    // Start is called before the first frame update
    public new void Start()
    {
        enemiesHP = 10;
        enemyDamage = 2;
        speed = 2;
        startWaitTime = 1;
        wait_time = startWaitTime;
        movePos.position = GetRandomPos();
        base.Start();
    }

    // Update is called once per frame
    public new void Update()
    {
        //调用父类的Update
        base.Update();
        //从当前位置移动到目标位置    Time.deltaTime是变化的时间量，和帧率相关
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        //判断是否到达指定位置
        if(Vector2.Distance(transform.position, movePos.position) < 0.1f)//返回A点到B点距离看是否小于0.1
        {
            if(wait_time <= 0)
            {
                movePos.position = GetRandomPos();
                wait_time = startWaitTime;
            }
            else
            {
                wait_time -=Time.deltaTime; 
            }
        }
    }

    //得到一个随机的目标位置
    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

}
