using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int AttackIndex = Animator.StringToHash("AttackIndex");
    private static readonly int TakeHit = Animator.StringToHash("TakeHit");
    private static readonly int Death = Animator.StringToHash("Death");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSpeed(float speed)
    {
        animator.SetFloat(Speed, Mathf.Abs(speed));
    }

    public void SetVerticalVelocity(float verticalVelocity)
    {
        animator.SetFloat(VerticalVelocity, verticalVelocity);
    }

    public void SetGrounded(bool isGrounded)
    {
        animator.SetBool(IsGrounded, isGrounded);
    }

    public void PlayAttack(int attackIndex)
    {
        animator.SetInteger(AttackIndex, attackIndex);
        animator.SetTrigger(Attack);
    }

    public void PlayTakeHit()
    {
        animator.SetTrigger(TakeHit);
    }

    public void PlayDeath()
    {
        animator.SetTrigger(Death);
    }

    public void Flip(float direction)
    {
        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}