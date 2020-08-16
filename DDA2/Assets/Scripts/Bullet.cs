using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DDA dda;
    private float timer = 5;

    private void Awake()
    {
        dda = GameObject.FindGameObjectWithTag("DDA").GetComponent<DDA>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<MeleeAI>().health--;
            dda.enemiesRanged++;
        }

        if (collision.gameObject.tag == "RangeEnemy")
        {
            collision.gameObject.GetComponent<RangeEnemie>().health--;
            collision.gameObject.GetComponent<RangeAI>().health--;


            dda.enemiesRanged++;
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer<0)
        {
            Destroy(gameObject);
        }
    }

}
