using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    public override void Init(MiniGameManager minigame)
    {
        base.Init(minigame);

        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickRestartButton()
    {
        SetActive(UIState.Game);
    }

    public void OnClickExitButton()
    {
        SetActive(UIState.None);
    }
	protected override UIState GetUIstate()
	{
		return UIState.GameOver;
	}
}
