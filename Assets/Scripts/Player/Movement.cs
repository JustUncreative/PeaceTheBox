using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public static Movement instance;
    public float horizontal;
    private bool isJumping;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(PlayerHealthController.instance._isAlive && !StuckCheck.instance._isStuck){
            rb.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime * 50f, rb.velocity.y);

            if(isJumping){
                rb.AddForce(new Vector2(0f, jumpPower));

                isJumping = false;
            }
        }
    }
    public void Move(InputAction.CallbackContext context){
        horizontal = context.ReadValue<Vector2>().x;
    }

    public bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    public void Jump(InputAction.CallbackContext context){
        if(context.performed && IsGrounded()){
            isJumping = true;
        } 
    }
    public void changeSpeed(float value){
        speed = value;
    }
    public void changeJumpPower(float value){
        jumpPower = value;
    }
}
