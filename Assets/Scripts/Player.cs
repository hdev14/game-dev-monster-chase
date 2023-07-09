using UnityEngine;

public class Player : MonoBehaviour
{
    private const string WALK_ANIMATION = "IsWalk";

    private const string GROUND_TAG = "Ground";

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    [SerializeField]
    private float movimentX = 0f;

    [SerializeField]
    private bool isGrounded = true;

    private Rigidbody2D body;

    private SpriteRenderer spriteRenderer;

    private Animator animator;


    public void Awake()
    {
        this.body = this.GetComponent<Rigidbody2D>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.animator = this.GetComponent<Animator>();
    }

    public void Update()
    {
        this.Animation();
        this.MoveBehaviour();
        this.JumpBehaviour();
    }

    private void MoveBehaviour()
    {
        this.movimentX = Input.GetAxisRaw("Horizontal");

        var newPosition = new Vector3(this.movimentX * this.moveForce * Time.deltaTime, 0f);

        this.transform.position += newPosition;
    }

    private void Animation()
    {
        if (this.movimentX != 0)
        {
            this.animator.SetBool(Player.WALK_ANIMATION, true);
            this.spriteRenderer.flipX = this.movimentX < 0;
            return;
        }

        this.animator.SetBool(Player.WALK_ANIMATION, false);
    }

    private void JumpBehaviour()
    {
        if (Input.GetButtonDown("Jump") && this.isGrounded)
        {
            this.body.AddForce(new Vector2(0f, this.jumpForce), ForceMode2D.Impulse);
            this.isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.isGrounded = collision.gameObject.CompareTag(Player.GROUND_TAG);

        if (collision.gameObject.CompareTag(Enemy.TAG))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Enemy.TAG))
        {
            Destroy(this.gameObject);
        }
    }
}
