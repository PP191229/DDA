using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAI : MonoBehaviour
{

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce;

    public float cooldown, timer, sight;

    public bool canSeePlayer;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        timer = cooldown;
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

        timer -= Time.deltaTime;
        if (timer <=0 && canSeePlayer == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        timer = cooldown;
    }

}
