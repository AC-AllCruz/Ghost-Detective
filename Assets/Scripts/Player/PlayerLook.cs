using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform cameraPivot;

    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = Camera.main;
    }
    private void Update()
    {
        if (GameManager.instance.CurrentState != GameState.Playing) return;
        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);
        LookAtMouse();
    }
    private void LookAtMouse()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, groundLayer))
        {
            Vector3 targetPosition = hitInfo.point;
            targetPosition.y = transform.position.y;

            Vector3 dir = (targetPosition - transform.position).normalized;
            if(dir.sqrMagnitude < 0.01f) return; // Prevents jittering when the mouse is very close to the player

            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = targetRotation;
            cameraPivot.rotation = targetRotation;
        }
    }
}
