using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIMamager : MonoBehaviour
{
    public static UIMamager Instance;

    [Header("Default Setting")]
    [SerializeField] private TextMeshProUGUI interactText;



    [Header("Page Setting")]
    [SerializeField] private GameObject pageUI;
    [SerializeField] private TextMeshProUGUI pageText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void Start()
    {
        if(interactText != null) interactText.enabled = false;
        if(pageUI != null) pageUI.SetActive(false);
    }

    public void ShowInteractText(bool show)
    {
        if(interactText == null) return;
        interactText.enabled = show;

    }
    public void ShowPage(bool show, string text)
    {
        if(pageUI == null) return;
        pageUI.SetActive(show);
        if (pageText != null) pageText.text = text;
    }

}
