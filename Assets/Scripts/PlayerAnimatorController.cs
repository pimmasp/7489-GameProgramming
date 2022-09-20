using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetAnimatorParameter(Vector2 playerVelcoty, bool groundState)
    {
        animator.SetFloat("xVelocity", Mathf.Abs(playerVelcoty.x));
        animator.SetFloat("yVelocity", playerVelcoty.y);
        animator.SetBool("IsGrounded", groundState);
    }
}
