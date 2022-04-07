using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public bool direction; 
    public bool isGrounded;

    Rigidbody2D RB;
    BoxCollider2D BC;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();

    }

    void Move() {
        
        // RB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, RB.velocity.y);

        if(Input.GetKey(KeyCode.LeftArrow)) {
            RB.velocity = new Vector2(-moveSpeed, RB.velocity.y);
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            RB.velocity = new Vector2(+moveSpeed, RB.velocity.y);
        } else {
            RB.velocity = new Vector2(0, RB.velocity.y);
        }
    }

    void Jump() {
        if(Input.GetKeyDown(KeyCode.Space)) {

            

             RB.AddForce(new Vector2(0f, jumpSpeed));
        }



        // RaycastHit2D down = Physics2D.BoxCast(BC.bounds.center, BC.bounds.size, 0F, Vector2.down, 5F);

        //     if(down.collider != null) {
        //         isGrounded = true;
        //     } else {
        //         isGrounded = false;
        //     }
    }
}
