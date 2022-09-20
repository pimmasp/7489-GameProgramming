using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpPadForce = 13f;
    [SerializeField] private float additionalSleepJumpTime = 0.3f;

    private static readonly int Bounce = Animator.StringToHash("Bounce");

    public float GetJumpPadFprc() => jumpPadForce;
    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;
    
    // private void Start() 
    // {
    //     animator = GetComponent<Animator>();    
    // }
    public void TriggerJumpPad()
    {
        animator.SetTrigger("Bounce");
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        // GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPadForce, ForceMode2D.Impulse);
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPadForce, ForceMode2D.Impulse);
            TriggerJumpPad();
        }
    }

}

