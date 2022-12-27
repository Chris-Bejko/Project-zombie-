using System;
using System.Collections;
using System.Collections.Generic;
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

    private IEnumerator LoadData()
    {

        ChangeState(GameState.Loading);
        while (SaveSystem.Load() == null)
        {
            yield return null;
        }
        ChangeState(GameState.Started);
        yield return null;
        ChangeState(GameState.Playing);

    }

    private void Start()
    {
        StartCoroutine(LoadData());
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
        }
        OnGameStateChanged?.Invoke(currentState);
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }

    public void HandleUI()
    {

    }

    public void HandleLore()
    {
        LoreLetter.SetActive(true);
    }

    public void HandlePlaying()
    {
        LoreLetter.SetActive(false);
    }

    public void HandlePaused()
    {

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
    Started
}