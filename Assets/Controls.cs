using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Controls : MonoBehaviour
{
    public static float maxSpeed = 5f;
    public float jumpHeight = 8f;
    public float gravityScale = 1.5f;

    bool facingRight = true;
    float moveDirection = 0;
    bool onGround = false;
    Rigidbody2D rigid;
    Collider2D mainCollider;
    // Check every collider except Player and Ignore Raycast
    LayerMask layerMask = ~(1 << 2 | 1 << 8);
    Transform t;

    // initialize
    void Start()
    {
        t = transform;
        rigid = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
        rigid.freezeRotation = true;
        rigid.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rigid.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        gameObject.layer = 8;

    }

    // Update is called once per frame
    void Update()
    {
        // movement
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (onGround || rigid.velocity.x > 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            if (onGround || rigid.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
        }

        // direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && onGround)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
        }

        //restart
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        }
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);
        // onGround check
        onGround = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);
        // velocity
        rigid.velocity = new Vector2((moveDirection) * maxSpeed, rigid.velocity.y);
        //Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, 0.23f, 0), onGround ? Color.green : Color.red);
    }
}