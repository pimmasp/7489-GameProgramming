using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D playerCollider; 
    [SerializeField] private PlayerAnimatorController animatorController;


    [Header("Player Values")] 
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    [Header("Ground Check")] 
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckDisance = 0.01f;
    private bool _isGrounded;
    private float _moveInput;
    private float coyoTime = 0.15f;
    private float coyoTimeCounter;
    private GameManager _gameManager;
    // private void Start() 
    // {
    //     playerCollider = GetComponent<Collider2D>();
    // }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        // else if (col.TryGetComponent(out Collectibles collectibles))
        // {
        
        // }

        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard","Water"))) 
        {
              TakeDamage();
        }
    }

    private void TakeDamage()
    {
        _gameManager.ProcessPlayerDeath();
    }
    private void Update() 
    {
        CheckGround();
        SetAnimatorParameter();
    }

    private void SetAnimatorParameter()
    {
        animatorController.SetAnimatorParameter(rb.velocity, _isGrounded);
    }
    // void Awake() 
    // {
    //     animator=GetComponent<Animator>();
    // }
    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        rb.velocity = new Vector2(_moveInput * movementSpeed, rb.velocity.y);
    }
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();

        FlipPlayerSprite();
    }

    private void TryJumping()
    {
        if (! _isGrounded) return;

        Jump(jumpForce);
    }
    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;

        TryJumping();
    }
    private void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the y-force to prevent player stacking up jump momentum.
        rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
    }

    private void FlipPlayerSprite()
    {
        if (_moveInput < 0)
        {
            player.localScale = new Vector3(-1,1,1);
        }
        else if (_moveInput > 0)
        {
            player.localScale = Vector3.one;
        }
    }

    private void CheckGround()
    {
        var playerBounds = playerCollider.bounds;

        RaycastHit2D raycastHit = Physics2D.BoxCast(
            playerCollider.bounds.center, 
            playerCollider.bounds.size, 
            0f, 
            Vector2.down, 
            groundCheckDisance, 
            groundLayers);

        _isGrounded = raycastHit.collider != null;

        if (_isGrounded)
        {
            coyoTimeCounter = coyoTime;
        }
        else
        {
            coyoTimeCounter  -= Time.deltaTime;
        }

        /*Color rayColor;

        if (_isGrounded)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(playerCollider.bounds.center, Vector2.down * (playerCollider.bounds.extents.y + groundCheckDisance), rayColor);
        Debug.Log(_isGrounded);*/
    }
}

