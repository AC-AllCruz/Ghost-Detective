using UnityEngine;


public enum GameState
{
    Playing,
    Inventory,
    Pause,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState CurrentState { get; private set; }

    public bool IsGamePaused => CurrentState == GameState.Pause || CurrentState == GameState.Inventory;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

    }
    private void Start()
    {
        ChangeState(GameState.Playing);       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (CurrentState)
            {
                case GameState.Playing:
                    ChangeState(GameState.Pause);
                    break;

                case GameState.Pause:
                    ChangeState(GameState.Playing);
                    break;

                case GameState.Inventory:
                    ChangeState(GameState.Playing);
                    break;
            }
        }
    }
    public void ChangeState(GameState newState)
    {
        CurrentState = newState;


        switch (CurrentState)
        {
            case GameState.Playing:
                Time.timeScale = 1f;
                UIMamager.Instance.OpenOption(false);

                if (InventoryUIManager.Instance != null) InventoryUIManager.Instance.ShowInventory(false);
                break;

            case GameState.Pause:
                Time.timeScale = 0f;
                UIMamager.Instance.OpenOption(true);
                break;

            case GameState.GameOver:
                Time.timeScale = 0f;
                UIMamager.Instance.ShowGameover(true);
                break;

            case GameState.Inventory:
                Time.timeScale = 0f;
                if (InventoryUIManager.Instance != null) InventoryUIManager.Instance.ShowInventory(true);
                break;
        }
    }

}
