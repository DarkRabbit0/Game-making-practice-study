using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//坐标
    public float smoothing;//使相机行走平滑的因子
    public Vector2 minPosition;//相机范围最小的坐标
    public Vector2 maxPosition;//相机范围最大的坐标

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
                Vector3 targetPos = target.position;//获取玩家现在的坐标
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);//线性差值函数
            }
        }
    }
    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)//设置相机限制
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
