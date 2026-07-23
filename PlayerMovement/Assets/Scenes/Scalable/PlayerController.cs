using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerView playerView;

    private Vector2 movementInput;

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        playerMovement.Move(movementInput);
        playerView.UpdateMovementState(playerMovement.IsMoving);
    }

    private void ReadInput()
    {
        movementInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }
}