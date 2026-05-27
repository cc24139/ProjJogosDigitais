using UnityEngine;


public class WalkingCharacter : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 movimento;
    private float moveSpeed = 5f;
    private SpriteRenderer personagemSpriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        personagemSpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


 
    void MoveAnimator()
    {
        if (animator == null || rb == null)
        {
            return;
        }
        
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
        rb.linearVelocity = movement;
    }
}
