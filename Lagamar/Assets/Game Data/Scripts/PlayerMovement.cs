using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    // Chamado automaticamente pelo Player Input.
    // A ação precisa se chamar exatamente "Move".
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        movement = Vector2.ClampMagnitude(movement, 1f);

        Debug.Log("Input recebido: " + movement);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;

        Debug.Log(
            "Velocidade: " + rb.velocity +
            " | Posição: " + rb.position
        );
    }

    private void OnDisable()
    {
        movement = Vector2.zero;

        if (rb != null)
            rb.velocity = Vector2.zero;
    }
}