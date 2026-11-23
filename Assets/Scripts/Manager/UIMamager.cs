using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIMamager : MonoBehaviour
{
    public static UIMamager Instance;

    [Header("Default Setting")]
    [SerializeField] private TextMeshProUGUI interactText;



    [Header("Page Setting")]
    [SerializeField] private GameObject pageUI;
    [SerializeField] private TextMeshProUGUI pageText;

    [Header("other UI Setting")]
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject gameOverUI;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else Destroy(gameObject);

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

    public void OpenOption(bool open)
    {
        if(optionPanel != null) optionPanel.SetActive(open);
    }
    public void ShowGameover(bool open)
    {
        if(gameOverUI != null) gameOverUI.SetActive(open);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetUI();
    }

    private void ResetUI()
    {
        if (interactText != null) interactText.enabled = false;
        if (pageUI != null) pageUI.SetActive(false);
        if (optionPanel != null) optionPanel.SetActive(false);
        if (gameOverUI != null) gameOverUI.SetActive(false);
    }

}
