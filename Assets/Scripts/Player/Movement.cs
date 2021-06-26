using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime * 50f, rb.velocity.y);
    }
    public void Move(InputAction.CallbackContext context){
        horizontal = context.ReadValue<Vector2>().x;
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }
}
