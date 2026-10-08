using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovimento : MonoBehaviour
{
    [Header("Player Component References")]
    [SerializeField] Rigidbody2D rb;
    
    [Header("Player Settings")]
    [SerializeField] float speed;
    
    [Header(Grounding)]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck; 

    private float horizontal;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new vector2(1f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
