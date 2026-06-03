using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;
    private float dashTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartDash();
        }

        if (isDashing)
        {
            ContinueDash();
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTime = Time.time + dashDuration;
    }

    void ContinueDash()
    {
        if (Time.time < dashTime)
        {
            transform.Translate(transform.right * dashSpeed * Time.deltaTime);
        }
        else
        {
            isDashing = false;
        }
    }
}