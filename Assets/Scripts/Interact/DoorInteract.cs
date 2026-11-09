using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorInteract : Interact_Base
{
    [SerializeField] private Transform doorPrivot;
    [SerializeField] private float OpenAngle = 90f;
    [SerializeField] private float rotateSpeed = 1f;

    private bool isOpen = false;
    private bool isRotating = false;

    private Quaternion closeRotation;
    private Quaternion openRotation;

    private void Start()
    {
        closeRotation = doorPrivot.localRotation;
        openRotation = closeRotation * Quaternion.Euler(0, 0, -OpenAngle);
    }
    public override void Interact()
    {
        if (isRotating) return;
        if (isOpen)
        {
            Debug.Log("Closing the door");
            StartCoroutine(RotateDoor(closeRotation));
        }
        else
        {
            Debug.Log("Opening the door");
            StartCoroutine(RotateDoor(openRotation));
        }
        isOpen = !isOpen;
    }

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        Quaternion startRotation = doorPrivot.localRotation;

        float time = 0f;

        isRotating = true;
        while (time < 1f)
        {
            time += Time.deltaTime * rotateSpeed;
            doorPrivot.localRotation = Quaternion.Slerp(startRotation, targetRotation, time);
            yield return null;
        }

        doorPrivot.localRotation = targetRotation;
        isRotating = false;
    }
}
