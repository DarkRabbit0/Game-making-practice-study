using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//坐标
    public float smoothing;//使相机行走平滑的因子
    // Start is called before the first frame update
    void Start()
    {
        smoothing = 0.1f;//设定平滑移动参数
        GameController.camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();//通过标签绑定相机
    }

    void LateUpdate()
    {
        if(target != null)//如果玩家还存在着
        {
            if(transform.position != target.position)//如果相机坐标和玩家坐标不同
            {
                Vector3 targetPos = target.position;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);//线性差值函数
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
