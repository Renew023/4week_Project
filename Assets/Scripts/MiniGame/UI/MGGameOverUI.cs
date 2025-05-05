using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MGGameOverUI : MGBaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI bestScoreText;

	public override void Init(MGUIManager uiManager)
	{
		base.Init(uiManager);
		restartButton.onClick.AddListener(OnClickRestartButton);
		exitButton.onClick.AddListener(OnClickExitButton);
	}

	public void SetUI(int score, int bestScore)
	{
		scoreText.text = score.ToString();
		bestScoreText.text = bestScore.ToString();
	}

	public void OnClickRestartButton()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void OnClickExitButton()
	{
		SceneManager.LoadScene("MainScene");
	}

	protected override MGUIState GetUIState()
	{
		return MGUIState.GameOver;
	}
}
