using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ObjectPool BulletsPool;

    public Transform player;

    public Inventory PlayerInventory;

    private GameState currentState;

    public GameObject LoreLetter;

    public CheckpointController Checkpoints;

    public UIManager UIManager;

    public AudioManager AudioManager;

    public static event Action<GameState> OnGameStateChanged;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private IEnumerator LoadData(GameState finalState)
    {

        ChangeState(GameState.Loading);
        while (SaveSystem.Load() == null)
        {
            yield return null;
        }
        ChangeState(GameState.Started);
        yield return null;
        ChangeState(finalState);

    }

    private void Start()
    {
        StartCoroutine(LoadData(GameState.UI));
    }
    private void Update()
    {
        if(currentState == GameState.Lore)
        {
            if (Input.GetKeyDown(KeyCode.E))
                ChangeState(GameState.Playing);
        }
    }
    #region GameState
    public void ChangeState(GameState newState)
    {
        Debug.LogError("State change requested" + newState.ToString());
        currentState = newState;
        switch (newState)
        {
            case GameState.UI:
                HandleUI();
                break;
            case GameState.Lore:
                HandleLore();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.Paused:
                HandlePaused();
                break;
            case GameState.Loading:
                HandleLoading();
                break;
            case GameState.Started:
                HandleStarted();
                break;
            case GameState.Cutscene:
                HandleCutscene();
                break;
            case GameState.Lost:
                HandleLost();
                break;
            case GameState.PlayAgain:
                HandlePlayAgain();
                break;
        }
        OnGameStateChanged?.Invoke(currentState);
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }
    public void HandleLoading()
    {

    }

    public void HandleStarted()
    {

    }

    public void HandleCutscene()
    {

    }

    public void HandleLost()
    {
        UIManager.OpenScreen(UIScreenID.Lost);
        SaveSystem.Save();
    }

    public void HandleUI()
    {
        UIManager.OpenScreen(UIScreenID.MainMenu);
    }

    public void HandleLore()
    {
        UIManager.OpenScreen(UIScreenID.Lore);
        //LoreLetter.SetActive(true);
    }

    public void HandlePlaying()
    {
        UIManager.OpenScreen(UIScreenID.InGame);
    }

    public void HandlePaused()
    {

    }

    public void HandlePlayAgain()
    {
        StartCoroutine(LoadData(GameState.Playing));
    }
    #endregion
}
public enum GameState
{
    UI,
    Lore,
    Playing,
    Paused,
    Loading,
    Started,
    Cutscene,
    Lost,
    PlayAgain,
}