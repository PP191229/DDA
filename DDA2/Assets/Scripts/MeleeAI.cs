using BBUnity.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI : MonoBehaviour
{

    public Transform player;
    public float speed, sight;
    private Rigidbody2D rb;
    private Vector2 movement;

    public int health;

    public bool canSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        Debug.DrawRay(transform.position, Vector2.right, Color.black);

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("Player");

        if (Physics2D.Raycast(transform.position, Vector2.right, sight, mask))
        {
            canSeePlayer = true;
        }
        else canSeePlayer = false;

        if (canSeePlayer == true)
        {
            Move(movement);
        }
        else transform.position = this.transform.position;

    }

    void Move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

}
