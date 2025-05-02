using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(MGUIManager miniGame)
    {
        base.Init(miniGame);

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    	}

    public void OnClickStartButton()
    {
		SetActive(UIState.Game);
	}

    public void OnClickExitButton()
    {
		SetActive(UIState.None);
	}

    protected override UIState GetUIstate()
    {
        return UIState.Home;
    }
}
