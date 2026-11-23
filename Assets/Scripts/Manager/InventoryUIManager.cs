using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager Instance;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Transform slotParent;
    [SerializeField] private InventorySlot slotPrefab;

    private bool isInventoryOpen = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameManager.instance.CurrentState == GameState.Playing)
            {
                GameManager.instance.ChangeState(GameState.Inventory);
            }
            else if (GameManager.instance.CurrentState == GameState.Inventory)
            {
                GameManager.instance.ChangeState(GameState.Playing);
            }
        }
    }

    public void RefreshInventory()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }
        foreach (InventoryEvidence evidence in InvatoryManager.instance.evidences)
        {
            InventorySlot slot = Instantiate(slotPrefab, slotParent);

            slot.Setup(evidence);
        }
    }
    public void ShowInventory(bool show)
    {
        inventoryPanel.SetActive(show);

        if (show)
        {
            RefreshInventory();
        }
    }

}
