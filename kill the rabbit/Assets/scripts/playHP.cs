using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playHP : MonoBehaviour
{
    public int playerHitPoint;
    public int blinks;

    public float playerBlinkTime;

    private Renderer myRender;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        playerHitPoint = 20;
        blinks = 3;
        playerBlinkTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //伤害函数
    public void HurtPlayer(int damage)
    {
        playerHitPoint -= damage;
        GameController._camShake.Shake();//震动
        if(playerHitPoint <= 0)
        {
            Destroy(gameObject);
        }
        BlinkPlayer(blinks, playerBlinkTime);
    }

    void BlinkPlayer(int numBlinks,float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks,seconds));//闪烁
    }

    IEnumerator DoBlinks(int numBlinks,float seconds)
    {
        for(int i = 0; i < numBlinks * 2; i ++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);//等待时间后
        }

        myRender.enabled = true;//关闭攻击的碰撞体
    }
}
