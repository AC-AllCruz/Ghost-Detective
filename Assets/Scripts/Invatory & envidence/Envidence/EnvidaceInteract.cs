using UnityEngine;

public class EnvidaceInteract : Interact_Base
{
    [SerializeField] private EvidenceDataSO evidenceData;

    public override void Interact()
    {
        InvatoryManager.instance.AddEnvidednces(evidenceData);

        Destroy(gameObject);
    }
}
