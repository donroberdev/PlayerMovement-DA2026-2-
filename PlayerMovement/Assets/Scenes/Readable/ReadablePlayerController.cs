using UnityEngine;

public class ReadablePlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 5f;

    [Header("Visual Feedback")]
    [SerializeField] private Color idleColor = Color.white;
    [SerializeField] private Color movingColor = Color.red;

    private Rigidbody playerRigidbody;
    private Renderer playerRenderer;

    private Vector3 movementDirection;
    private bool isMoving;

    private void Awake()
    {
        GetRequiredComponents();
    }

    private void Start()
    {
        SetPlayerColor(idleColor);
    }

    private void Update()
    {
        ReadMovementInput();
        UpdateMovementState();
        UpdatePlayerColor();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetRequiredComponents()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRenderer = GetComponent<Renderer>();

        if (playerRigidbody == null)
        {
            Debug.LogError("ReadablePlayerController requires a Rigidbody.");
        }

        if (playerRenderer == null)
        {
            Debug.LogError("ReadablePlayerController requires a Renderer.");
        }
    }

    private void ReadMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector3(
            horizontalInput,
            0f,
            verticalInput
        ).normalized;
    }

    private void UpdateMovementState()
    {
        isMoving = movementDirection.sqrMagnitude > 0f;
    }

    private void MovePlayer()
    {
        if (playerRigidbody == null)
        {
            return;
        }

        Vector3 nextPosition =
            playerRigidbody.position +
            movementDirection * movementSpeed * Time.fixedDeltaTime;

        playerRigidbody.MovePosition(nextPosition);
    }

    private void UpdatePlayerColor()
    {
        if (playerRenderer == null)
        {
            return;
        }

        Color targetColor = isMoving
            ? movingColor
            : idleColor;

        SetPlayerColor(targetColor);
    }

    private void SetPlayerColor(Color newColor)
    {
        if (playerRenderer == null)
        {
            return;
        }

        playerRenderer.material.color = newColor;
    }
}