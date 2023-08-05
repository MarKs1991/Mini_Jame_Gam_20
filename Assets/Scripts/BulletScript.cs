using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float secondsBeforeDestruction = 5f;
    public float speed = 5f;
    private Rigidbody2D rb;
    private int directionMulitplicator;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (GameObject.FindWithTag("Player").transform.localScale.x > 0)
        {
            directionMulitplicator = 1;
        }
        else
        {
            speed = -speed;
            directionMulitplicator = -1;
        }

        Destroy(this.gameObject, secondsBeforeDestruction);
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
        transform.localScale = new Vector2(1 * directionMulitplicator, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
