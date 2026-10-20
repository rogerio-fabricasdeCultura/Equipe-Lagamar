using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove_rogerio : MonoBehaviour
{
    [Header("Player Component References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Player Settings")]
    [SerializeField] private float speed = 5f;

    [Header("Animation")]
    [SerializeField] Animator myAnim;

    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(movementInput, 1f) * speed;
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        
        // Verificar se existe input
        if (movementInput != Vector2.zero)
        {
            //Debug.Log("Input de movimento");
            myAnim.SetBool("Move", true);
        }
        else
        {
            myAnim.SetBool("Move", false);
        }
    }

    private void SetIsWalking( ) {
       
    }
}
