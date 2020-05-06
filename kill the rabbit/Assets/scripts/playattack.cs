using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playattack : MonoBehaviour
{
    public int playerDamage = 2;
    public float time = 0.24f;
    public float startTime = 0.01f;

    private Animator my_anim;
    private PolygonCollider2D my_coll2D;

    // Start is called before the first frame update
    void Start()
    {
        my_anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        my_coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetButtonDown("Attack"))
        {
            my_anim.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }
    }


    IEnumerator StartAttack()
    {
        //Debug.Log("1");//调试信息
        yield return new WaitForSeconds(startTime);
        my_coll2D.enabled = true;
        StartCoroutine(DisableHitBox());
    }

    IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(time);
        my_coll2D.enabled = false;
        //Debug.Log(playerDamage);//调试信息
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemie"))
        {
            other.GetComponent<Enemies>().TakeDamage(playerDamage);
        }
    }
}
