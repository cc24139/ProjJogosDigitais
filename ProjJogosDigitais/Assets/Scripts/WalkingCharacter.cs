using UnityEngine;

public class WalkingCharacter : MonoBehaviour
{
    [Header("Configuração do Jogador")]
    public int playerID = 1; 

    [Header("Componentes")]
    public Animator animator;
    public Rigidbody2D rb;
    private SpriteRenderer personagemSpriteRenderer;

    [Header("Movimentação")]
    private float moveSpeed = 5f;
    private string inputAxisName;

    [Header("Pulo")]
    public float jumpForce = 300f;
    private string jumpButtonName;
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        personagemSpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (playerID == 1)
        {
            inputAxisName = "HorizontalP1";
            jumpButtonName = "JumpP1";
        }
        else
        {
            inputAxisName = "HorizontalP2";
            jumpButtonName = "JumpP2";
        }
    }
 
    void MoveAnimator()
    {
        if (animator == null || rb == null) return;
        
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis(inputAxisName);
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        if (horizontalInput > 0) personagemSpriteRenderer.flipX = false;
        else if (horizontalInput < 0) personagemSpriteRenderer.flipX = true;

        if (Input.GetButtonDown(jumpButtonName) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; 
        }

        MoveAnimator();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.name.Contains("Platform"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.name.Contains("Platform"))
        {
            isGrounded = false;
        }
    }
}