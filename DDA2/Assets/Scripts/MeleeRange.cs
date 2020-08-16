using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRange : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    public DDA dda;

    void Start()
    {
        dda = GameObject.FindGameObjectWithTag("DDA").GetComponent<DDA>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[]  hitEnemies  = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,  enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<RangeAI>().health--;
            enemy.GetComponent<RangeEnemie>().health--;
            enemy.GetComponent<MeleeAI>().health--;

            dda.enemiesMeleed++;
        }
    }
}
