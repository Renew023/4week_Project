using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MGUIState
{
    Home,
    Game,
    GameOver
}

public class MGUIManager : MonoBehaviour
{
    public static MGUIManager instance;

    public static MGUIManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<MGUIManager>();
			}
			return instance;
		}
	}

	[SerializeField] private MGHomeUI mgHomeUI;
	[SerializeField] private MGGameUI mgGameUI;
	[SerializeField] private MGGameOverUI mgGameOverUI;

    public MGUIState currentState;

    [SerializeField] MiniGamePlayerMove mgPlayer;

	private void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}

		mgHomeUI.Init(this);
        mgGameUI.Init(this);
        mgGameOverUI.Init(this);

        ChangeState(MGUIState.Home);
    }

    public void ChangeState(MGUIState state)
    {
        currentState = state;
        mgHomeUI.SetActive(currentState);
        mgGameUI.SetActive(currentState);
        mgGameOverUI.SetActive(currentState);
    }

    public void OnClickStart()
    {
        ChangeState(MGUIState.Game);
        mgPlayer.ReStart();
	}

    public void OnClickExit()
    {
        
	}

    public void UpdateScore(int score)
    {
        mgGameUI.SetUI(score);
    }

    public void EndScore(int curScore, int highScore)
    {
		ChangeState(MGUIState.GameOver);
        mgGameOverUI.SetUI(curScore, highScore);
	}
}
