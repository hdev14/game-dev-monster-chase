using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    
    [SerializeField]
    private float jumpForce = 11f;

    [SerializeField]
    private float movimentX = 0f;

    private static string WALK_ANIMATION = "IsWalk";

    private Rigidbody2D body;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    public void Awake()
    {
        this.body = this.GetComponent<Rigidbody2D>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.animator = this.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        this.MoveBehavior();
        this.Animation();
    }

    private void MoveBehavior() {
        this.movimentX = Input.GetAxisRaw("Horizontal");

        var newPosition = new Vector3(this.movimentX * this.moveForce * Time.deltaTime, 0f);

        this.transform.position += newPosition;
    }

    private void Animation() {
        if (this.movimentX != 0) {
            this.animator.SetBool(Player.WALK_ANIMATION, true);
            this.spriteRenderer.flipX = this.movimentX < 0;
            return;
        }

        this.animator.SetBool(Player.WALK_ANIMATION, false);
    }
}
