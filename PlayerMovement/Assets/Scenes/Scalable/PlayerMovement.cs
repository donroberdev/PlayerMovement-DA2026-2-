using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 5f;

    private Rigidbody playerRigidbody;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 movementInput)
    {
        Vector3 movementDirection = new Vector3(
            movementInput.x,
            0f,
            movementInput.y
        );

        IsMoving = movementDirection.sqrMagnitude > 0.01f;

        Vector3 nextPosition =
            playerRigidbody.position +
            movementDirection * movementSpeed * Time.fixedDeltaTime;

        playerRigidbody.MovePosition(nextPosition);
    }
}