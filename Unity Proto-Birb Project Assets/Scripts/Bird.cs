using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int velocity;
    public int jumpSpeed;

    public Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(velocity, RB.velocity.y);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
             RB.velocity = new Vector2(velocity, RB.velocity.y + jumpSpeed);
        }
    }
}
