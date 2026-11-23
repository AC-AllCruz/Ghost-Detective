using UnityEngine;

public class EvidenceManager : MonoBehaviour
{
    public static EvidenceManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    public void EvaluateEvidence(InventoryEvidence evidence, bool believe)
    {
        if (evidence.isResolved) return;

        evidence.isResolved = true;

        bool answerCorrect = evidence.evidenceData.isReal == believe;

        if (answerCorrect)
        {
            Debug.Log(
                "Correct : " + evidence.evidenceData.evidenceName);

            Debug.Log(
                "Code Fragment : " + evidence.evidenceData.codeFragment);
        }
        else
        {
            Debug.Log("Wrong Evidence!");

            // TODO
            // GhostManager.instance.StartHunt();
        }
    }
}
