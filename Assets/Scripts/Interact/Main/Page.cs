using UnityEngine;

public class Page : Interact_Base
{
    public string textInPage;
    public override void Interact()
    {
        UIMamager.Instance.ShowPage(true, textInPage);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.CompareTag("Player"))
        {
            UIMamager.Instance.ShowPage(false, "");
        }
    }
}
