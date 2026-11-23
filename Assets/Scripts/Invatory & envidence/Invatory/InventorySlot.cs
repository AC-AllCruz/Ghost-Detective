using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image evidenceIMG;

    private InventoryEvidence currentEvidence;

    public void Setup(InventoryEvidence evidence)
    {
        currentEvidence = evidence;

        evidenceIMG.sprite = evidence.evidenceData.previewImage;
    }
    public void OnClick()
    {
        EvidenceInspectUI.instance.ShowEvidence(currentEvidence);
    }
}
