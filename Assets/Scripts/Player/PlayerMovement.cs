using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Walk Animation Frames (facing up)")]
    [SerializeField] private Sprite[] walkFrames;
    [SerializeField] private float   frameRate = 8f;

    private Rigidbody2D   rb;
    private SpriteRenderer sr;

    private PlayerControls controls;
    private Vector2        moveInput = Vector2.zero;

    private float frameTimer;
    private int   frameIndex;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled  += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable()  => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void Update()
    {
        if (moveInput.sqrMagnitude > 0.01f)
        {
            frameTimer += Time.deltaTime;
            if (frameTimer >= 1f / frameRate)
            {
                frameTimer = 0f;
                frameIndex = (frameIndex + 1) % walkFrames.Length;
                sr.sprite  = walkFrames[frameIndex];
            }
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            frameIndex = 0;
            sr.sprite  = walkFrames[0];
        }
    }

    private void FixedUpdate()
    {
        Vector2 normalized = moveInput.normalized;
        Vector2 newPos     = rb.position + normalized * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
