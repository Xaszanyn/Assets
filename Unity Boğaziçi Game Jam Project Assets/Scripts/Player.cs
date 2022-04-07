using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    public bool direction = true;
    public bool jumpable = false;

    Rigidbody2D RB;
    Animator AN;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AN = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Direction();
        Jump();

        if(!jumpable) AN.Play("Player Jump");
    }

    void Move() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            RB.velocity = new Vector2(-speed, RB.velocity.y);
            if(jumpable) AN.Play("Player Run");
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            RB.velocity = new Vector2(speed, RB.velocity.y);
            if(jumpable) AN.Play("Player Run");
        } else {
            RB.velocity = new Vector2(0, RB.velocity.y);
        }
    }

    void Direction() {
        if((RB.velocity.x  < 0 && direction) || (RB.velocity.x > 0 && !direction)) {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;

            direction = !direction;
        }
    }

    void Jump() {
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && jumpable) {
            RB.AddForce(new Vector2(RB.velocity.x, RB.velocity.y + jumpSpeed));
            jumpable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collided) {
        jumpable = true;
    }

    private void OnTriggerEnter2D(Collider2D collided) {
        if(collided.gameObject.CompareTag("Floor")) {
            jumpable = true;
        }
    }
}
