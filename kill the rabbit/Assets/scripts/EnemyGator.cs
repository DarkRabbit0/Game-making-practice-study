using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGator : Enemies
{
    public float speed;
    public float startWaitTime;

    // Start is called before the first frame update
    public new void Start()
    {
        health = 10;
        enemydamage = 2;
        base.Start();
    }

    // Update is called once per frame
    public new void Update()
    {
        //调用父类的Update
        base.Update();
    }


}
