
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove_rogerio : MonoBehaviour
{
    [Header("Player Component References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Player Settings")]
    [SerializeField] private float speed = 5f;

    [Header("Animation")]
    [SerializeField] private Animator myAnim;

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

        SetIsWalking();
    }

    private void SetIsWalking()
    {
        if (movementInput != Vector2.zero)
        {
            myAnim.SetBool("Move", true);

            // Prioriza esquerda e direita
            if (movementInput.x != 0)
            {
                myAnim.SetFloat("Horizontal",
                    Mathf.Sign(movementInput.x));

                myAnim.SetBool("Up", false);
            }
            else
            {
                myAnim.SetFloat("Horizontal", 0);

                myAnim.SetBool("Up",
                    movementInput.y > 0);
            }
        }
        else
        {
            myAnim.SetBool("Move", false);
        }
    }
}
