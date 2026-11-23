using UnityEngine;

[CreateAssetMenu(fileName = "EvidenceDataSO", menuName = "Evidence/Evidence Data")]
public class EvidenceDataSO : ScriptableObject
{
    public string evidenceName;

    [TextArea]
    public string description;
    public Sprite previewImage;

    public bool isReal;
    public int codeFragment;
}
