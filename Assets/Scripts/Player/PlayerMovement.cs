using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 7f;


    [Header("References")]
    [SerializeField] private Transform cameraTransform;


    private Rigidbody rb;
    private Vector3 moveDir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        Move();
    }


    private void HandleInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        moveDir = camForward * vertical + camRight * horizontal;
        moveDir.Normalize();
    }

    private void Move()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed; //กด shift เพื่อวิ่ง

        Vector3 targetposition = rb.position + moveDir * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetposition);
    }
  
}