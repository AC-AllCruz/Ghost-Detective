using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Door : MonoBehaviour
{
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;

    [SerializeField] private float doorMoveSpeed = 2f; // Speed at which the doors move
    [SerializeField] private float doorMoveDistance = -0.3f; // Distance the doors will move when opening
    private bool isMoving = false;


    private Vector3 leftDoorClosedPosition;
    private Vector3 rightDoorClosedPosition;

    private Vector3 leftDoorOpenPosition;
    private Vector3 rightDoorOpenPosition;

    private void Start()
    {
        leftDoorClosedPosition = leftDoor.localPosition;
        rightDoorClosedPosition = rightDoor.localPosition;


        leftDoorOpenPosition = leftDoorClosedPosition + Vector3.left * doorMoveDistance;
        rightDoorOpenPosition = rightDoorClosedPosition + Vector3.right * doorMoveDistance;
    }
    public void OpenDoor()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveDoor(leftDoorOpenPosition, rightDoorOpenPosition));
        }
    }

    public void CloseDoor()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveDoor(leftDoorClosedPosition, rightDoorClosedPosition));
        }
    }

    private IEnumerator MoveDoor(Vector3 leftTarget, Vector3 rightTarget)
    {
        isMoving = true;
        Vector3 leftStart = leftDoor.localPosition;
        Vector3 rightStart = rightDoor.localPosition;

        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * doorMoveSpeed;
            leftDoor.localPosition = Vector3.Lerp(leftStart, leftTarget, time);
            rightDoor.localPosition = Vector3.Lerp(rightStart, rightTarget, time);
            yield return null;
        }
        isMoving = false;
    }
}
