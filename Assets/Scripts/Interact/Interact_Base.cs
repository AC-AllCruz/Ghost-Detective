using UnityEngine;

public abstract class Interact_Base : MonoBehaviour
{
    protected bool canInteract;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacting with " + gameObject.name);
            Interact();
        }
    }

    public abstract void Interact();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

}
