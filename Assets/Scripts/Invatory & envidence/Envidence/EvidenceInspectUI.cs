using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceInspectUI : MonoBehaviour
{
    public static EvidenceInspectUI instance;

    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI evidenceName;
    [SerializeField] private TextMeshProUGUI evidenceDescription;
    [SerializeField] private Image evidenceIMG;

    private InventoryEvidence currentEvidence;

    private void Awake()
    {
        instance = this;
    }
    public void ShowEvidence(InventoryEvidence evidence)
    {
        panel.SetActive(true);

        currentEvidence = evidence;

        evidenceName.text = evidence.evidenceData.evidenceName;

        evidenceDescription.text = evidence.evidenceData.description;

        evidenceIMG.sprite = evidence.evidenceData.previewImage;
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
    public void Believe()
    {
        EvidenceManager.instance.EvaluateEvidence(currentEvidence, true);
        panel.SetActive(false);
    }
    public void Reject()
    {
        EvidenceManager.instance.EvaluateEvidence(currentEvidence, false);
        panel.SetActive(false);
    }
}
