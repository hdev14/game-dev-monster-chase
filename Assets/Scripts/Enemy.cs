using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;

    private Rigidbody2D body;

    public void setSpeed(float value)
    {
        this.speed = value;
    }

    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(this.speed, body.velocity.y);
    }

}
