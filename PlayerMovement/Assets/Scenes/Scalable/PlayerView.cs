using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PlayerView : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color idleColor = Color.white;

    [SerializeField] private Color movingColor = Color.red;

    private Renderer playerRenderer;
    private bool previousMovementState;

    private void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        SetColor(idleColor);
    }

    public void UpdateMovementState(bool isMoving)
    {
        if (previousMovementState == isMoving)
        {
            return;
        }

        previousMovementState = isMoving;

        SetColor(isMoving ? movingColor : idleColor);
    }

    private void SetColor(Color color)
    {
        playerRenderer.material.color = color;
    }
}