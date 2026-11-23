using UnityEngine;


public enum EvidenceDecision
{
    None,
    Believe,
    Reject
}

[System.Serializable]
public class InventoryEvidence
{
    public EvidenceDataSO evidenceData;
    public EvidenceDecision EvidenceDecision;
    public bool isResolved;
}
