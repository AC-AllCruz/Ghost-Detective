using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InvatoryManager : MonoBehaviour
{
    public static InvatoryManager instance;

    public List<InventoryEvidence> evidences = new List<InventoryEvidence>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    public void AddEnvidednces(EvidenceDataSO evidence)
    {
        InventoryEvidence newEvidence = new InventoryEvidence();

        newEvidence.evidenceData = evidence;

        evidences.Add(newEvidence);
    }
}
