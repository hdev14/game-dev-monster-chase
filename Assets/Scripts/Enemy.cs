using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed = 7f;

    private Rigidbody2D body;


    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(this.speed, body.velocity.y);   
    }

}
