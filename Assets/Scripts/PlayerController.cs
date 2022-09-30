using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [Header("Component References")] 
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private PlayerAnimatorController animatorController;
    [SerializeField] private PlayerAudioController audioController;
   
   
    // [SerializeField] private float startingHealth = 3f;
    [Header("Player Values")] 
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float timeBetweenJumps = 0.1f;
    [SerializeField] private float coyoteTimeDuration = 0.5f;
    // [SerializeField] private float damage = 1f;

    [Header("Ground Checks")] 
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float extraGroundCheckDistance = 0.5f;
    // public float currentHealth { get; private set; }
    // private Health _health;

    // Input Values
    private float _moveInput;
    
    // Boolean flags. Booleans for checking conditions.
    private bool _isGrounded;
    private bool _canJump;
    private bool _canDoubleJump;

    // Private variables
    private float _coyoteTimeTimer;
    private float _lastJumpTimer;

    // Stored References
    private GameManager _gameManager;

    private void Start()
    {

        _gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        CheckGround();
        CheckCanJump();
        SetAnimatorParameters();

        // if (Input.GetKeyDown(KeyCode.E))
        //     TakeDamage2(1);
    }
    // public void TakeDamage2(float damage)
    // {
    //     currentHealth = currentHealth - damage;

    //     if (currentHealth > 0)
    //     {
    //         Debug.Log(startingHealth);
    //         Debug.Log(currentHealth);
    //         _gameManager.ProcessPlayerDeath();
    //     }
    //     else
    //     {
    //         Debug.Log(startingHealth);
    //         Debug.Log(currentHealth);
    //         _gameManager.ProcessPlayerDeath();
    //     }
    // }

    private void FixedUpdate()
    {
        Move();
    }

    #region Actions

    private void Move()
    {
        rb.velocity = new Vector2(_moveInput * movementSpeed, rb.velocity.y);
    }

    private void FlipPlayerSprite()
    {
        player.localScale = _moveInput switch
        {
            > 0f => new Vector3(1, 1, 1),
            < 0f => new Vector3(-1, 1, 1),
            _ => player.localScale
        };
    }
    
    private void TryJumping()
    {
        if (_lastJumpTimer <= timeBetweenJumps) return; // If the player just jumped or use a jump pad, ignore the first timeBetweenJumps seconds.
        
        if (!_canJump) // If the player can't jump, check these conditions. Else jump.
        {
            if (!_canDoubleJump) return; // If the player cannot double jump, return void. (Stop here)
            _canDoubleJump = false; // Else set double jump to false, then jump.
        }

        Jump(jumpForce);
        audioController.PlayJumpSound();
    }

    public void Jump(float force, float additionalTimeWait = 0f)
    {
        _canJump = false; // Flag bool canJump is here is to prevent double jumping on jump pads since the code is shared.
        _lastJumpTimer = 0f - additionalTimeWait;
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the y-force to prevent player stacking up jump momentum.
        rb.AddForce(force * transform.up, ForceMode2D.Impulse);    
    }

    private void CheckGround()
    {
        var playerColliderBounds = playerCollider.bounds;
        
        var raycastHit = Physics2D.BoxCast(
            playerColliderBounds.center, 
            playerColliderBounds.size, 
            0f,
            Vector2.down, 
            extraGroundCheckDistance, 
            groundLayers);

        _isGrounded = raycastHit.collider != null;
    }

    private void CheckCanJump()
    {
        _lastJumpTimer = Mathf.Min(_lastJumpTimer, timeBetweenJumps) + Time.deltaTime; // Increment the time since the last jump. See line 73.

        if (_isGrounded)
        {
            _canJump = true;
            _coyoteTimeTimer = 0f;
            return;
        }

        _coyoteTimeTimer = Mathf.Min(_coyoteTimeTimer, coyoteTimeDuration) + Time.deltaTime;

        if (_coyoteTimeTimer <= coyoteTimeDuration) return; // If the coyote time timer does not hit the threshold yet, the player can still jump.

        _canJump = false; // If the coyote time timer goes beyond the threshold, the player can no longer jump.
    }

    private void SetAnimatorParameters()
    {
        animatorController.SetAnimatorParameters(rb.velocity, _isGrounded);
    }

    public void EnableDoubleJump()
    {
        _canDoubleJump = true;
    }
    
    public void TakeDamage()
    {
        // _health.TakeDamage2(1);

        _gameManager.ProcessPlayerDeath();
    }


    
    #endregion
    
    #region Input
    
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
        
        FlipPlayerSprite();
    }

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;

        TryJumping();
    }

    #endregion

}
