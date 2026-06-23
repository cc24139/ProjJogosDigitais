using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterHitBoxs))]
[RequireComponent(typeof(CharacterAnimator))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerInputManager p1;
    [SerializeField] private PlayerInputManager p2;

    private PlayerInputManager inputConfig;
    private CharacterMovement movement;
    private CharacterCombat combat;
    private CharacterHitBoxs hitBoxs;
    private CharacterAnimator animator;
    private CharacterStatus status;
    private bool isAttacking = false;
    private bool isDead = false;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        combat = GetComponent<CharacterCombat>();
        hitBoxs = GetComponent<CharacterHitBoxs>();
        animator = GetComponent<CharacterAnimator>();
        status = GetComponent<CharacterStatus>();
        Configure();
    }

    private void Configure()
    {
        inputConfig = hitBoxs.playerSide == PlayerSide.P1 ? p1 : p2;
    }

    private void Update()
    {
        if (isDead)
            return;

        HandleMovementInput();
        HandleAttackInput();
    }

    private void HandleMovementInput()
    {
        if (isAttacking)
            return;

        float horizontal = 0f;
        if (Input.GetKey(inputConfig.moveLeft))
            horizontal = -1f;
        if (Input.GetKey(inputConfig.moveRight))
            horizontal = 1f;

        movement.Move(horizontal);

        if (Input.GetKeyDown(inputConfig.jump))
            movement.Jump();
    }

    private void HandleAttackInput()
    {
        if (isAttacking)
            return;

        if (Input.GetKeyDown(inputConfig.attack1) && combat.AttackCount > 0)
            animator.PlayAttack(0);
        else if (Input.GetKeyDown(inputConfig.attack2) && combat.AttackCount > 1)
            animator.PlayAttack(1);
        else if (Input.GetKeyDown(inputConfig.attack3) && combat.AttackCount > 2)
            animator.PlayAttack(2);
    }

    public void StartAttack(int attackIndex)
    {
        if (!status.CanAffordMana(10))
        {
            EndAttack();
            return;
        }
        isAttacking = true;
        hitBoxs.Attack();
        combat.Attack(attackIndex);
        movement.Move(0);
        status.UseMana(10);
    }

    public void EndAttack()
    {
        isAttacking = false;
        hitBoxs.Normal();
    }

    public void OnHit(int damage)
    {
        if (isDead)
            return;

        status.TakeDamage(damage);

        if (status.CurrentHealth <= 0)
        {
            Die();
            return;
        }

        hitBoxs.Invulnerable();
        animator.PlayTakeHit();
    }

    public void EndHit()
    {
        if (isDead)
            return;

        hitBoxs.Normal();
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;

        if (hitBoxs != null)
        {
            MatchData.winnerName = hitBoxs.playerSide == PlayerSide.P1
                ? MatchData.p2CharacterName
                : MatchData.p1CharacterName;
        }

        hitBoxs.Invulnerable();
        animator.PlayDeath();
        movement.Move(0);

        StartCoroutine(GameOverSequenceRoutine());
    }

    private IEnumerator GameOverSequenceRoutine()
    {
        yield return new WaitForSeconds(1.5f);

        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(1.0f);

        Time.timeScale = 1f;
        SceneManager.LoadScene("GameEndScene");
    }
}