using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float defaultSpeed;
    public bool canMove = true;
    public float health;
    public float stunTime;
    public float knockbackForce;
    public Rigidbody2D rb;
    public Collider2D enemyCollider;
    public int pointValue;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();
        gm = GameObject.FindObjectOfType<GameManager>();
        defaultSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        Move();
    }

    public void LookAtPlayer()
    {
        GameObject player = GameObject.Find("Player");
        transform.right = player.transform.position - transform.position;
    }

    public void Move()
    {
        if (canMove)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        if(health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Knockback());
        }
    }

    public IEnumerator Knockback()
    {
        canMove = false;
        enemyCollider.enabled = false;
        rb.AddRelativeForce(Vector2.left * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        canMove = true;
        enemyCollider.enabled = true;
    }

    public void Die()
    {
        gm.AddScore(pointValue);
        Destroy(gameObject);
    }
    

}
