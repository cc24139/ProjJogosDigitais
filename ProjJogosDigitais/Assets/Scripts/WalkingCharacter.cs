using UnityEngine;

public class WalkingCharacter : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Component characterController;
    private float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
