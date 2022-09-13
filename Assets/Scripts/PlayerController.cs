using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float _moveInput;
    [SerializeField] private float moveSpeed = 3f;
     

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
        rb.velocity = transform.right * (_moveInput * moveSpeed);

    }

    private void OnJump(InputValue value)
    {
            if (value.isPressed)
            {
                rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
            }
    }

}

    

    
