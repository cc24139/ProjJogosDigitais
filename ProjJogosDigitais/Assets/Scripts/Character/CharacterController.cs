using System.Collections;
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

    private bool isAttacking = false;
    private bool isDead = false;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        combat = GetComponent<CharacterCombat>();
        hitBoxs = GetComponent<CharacterHitBoxs>();
        animator = GetComponent<CharacterAnimator>();

        Configure();
    }

    private void Configure(){
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

        if (Input.GetKeyDown(inputConfig.attack1))
            StartAttack(0);
        else if (Input.GetKeyDown(inputConfig.attack2))
            StartAttack(1);
        else if (Input.GetKeyDown(inputConfig.attack3))
            StartAttack(2);
    }

    public void StartAttack(int attackIndex)
    {
        isAttacking = true;
        hitBoxs.Attack();
        combat.Attack(attackIndex);
        StartCoroutine(EndAttackAfterDelay(1.3f));
    }

    IEnumerator EndAttackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        EndAttack();
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

        hitBoxs.Invulnerable();
        animator.PlayTakeHit();
        StartCoroutine(EndHitAfterDelay(0.5f));
    }

    IEnumerator EndHitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        EndHit();
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