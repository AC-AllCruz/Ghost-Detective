using System.Collections;
using UnityEngine;

public class Elevator_Button : Interact_Base
{
    [SerializeField] private Elevator_Door elevatorDoor;
    [SerializeField] private float openDuration = 3f;

    public override void Interact()
    {
        StartCoroutine(OpenElevator(openDuration));
    }

    IEnumerator OpenElevator(float delay)
    {
        Debug.Log("Elevator button pressed. Opening doors...");
        elevatorDoor.OpenDoor();
        yield return new WaitForSeconds(delay);
        elevatorDoor.CloseDoor();
    }
}
