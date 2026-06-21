using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterAnimator))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;

    private Rigidbody2D rb;
    private CharacterAnimator characterAnimator;

    private float horizontalInput;
    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

   /* private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        characterAnimator.SetSpeed(horizontalInput);
        characterAnimator.SetVerticalVelocity(rb.linearVelocity.y);
        characterAnimator.SetGrounded(isGrounded);
        characterAnimator.Flip(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }*/

    public void Move(float horizontalInput)
    {
        this.horizontalInput = horizontalInput;
        characterAnimator.SetSpeed(horizontalInput);
        characterAnimator.SetVerticalVelocity(rb.linearVelocity.y);
        characterAnimator.SetGrounded(isGrounded);
        characterAnimator.Flip(horizontalInput);
    }

    public void Jump()
    {
        if (!isGrounded)
            return;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
        characterAnimator.SetGrounded(false);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}