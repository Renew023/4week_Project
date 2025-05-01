using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    None,
    Home,
    Game,
    GameOver
}

public class MiniGameManager : MonoBehaviour
{
    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;

    private UIState currentState;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>();
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>();
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>();
        gameOverUI.Init(this);

        ChangeState(UIState.None);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    public void ChangeWave(int waveIndex)
    {
        //gameUI.UpdateWaveText(waveIndex);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }
}
