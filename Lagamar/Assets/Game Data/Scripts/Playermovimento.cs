
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovimento : MonoBehaviour
{
    [Header("Player Component References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Player Settings")]
    [SerializeField] private float speed = 5f;

    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(movementInput, 1f) * speed;
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
