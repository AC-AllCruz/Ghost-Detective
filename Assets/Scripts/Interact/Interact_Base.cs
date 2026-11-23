using TMPro;
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

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            UIMamager.Instance.ShowInteractText(true);
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            UIMamager.Instance.ShowInteractText(false);
        }
    }

}
