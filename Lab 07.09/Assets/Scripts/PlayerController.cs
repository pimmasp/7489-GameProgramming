using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    // [SerializeField] private Vector2 _moveInput;
    [SerializeField] private float _moveInput;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private CollectibleType collectibleType;

    
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        // arrayString = new string[];
        // var sprite = sprites[index];
        // arrayString[0] = ""    
    }
    // private void Update() 
    // {
    //     Move();

    // }
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
        rb.velocity = transform.right * (_moveInput * moveSpeed);

    }
    // private void Move()
    // {
    //     rb.velocity = transform.right * (_moveInput * moveSpeed);
    // }



    private void OnJump(InputValue value)
    {
            if (value.isPressed)
            {
                rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
            }
    }

    // private void ChangeColour;
    //         switch (CollectibleType)
    //         {
    //             case CollectibleType.Red:
    //                 DoSomething();
    //                 break;
    //             case CollectibleType.Green:
    //                 DoThatthing();
    //                 break;
    //             case CollectibleType.Blue:
    //                 DoOtherthing();
    //                 break;
    //             defalt:
    //                 DoNothing();
    //                 break;
    //         }

    
}