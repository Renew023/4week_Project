using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MGGameUI : MGBaseUI
{
	[SerializeField] private TextMeshProUGUI scoreText;

	protected override MGUIState GetUIState()
	{
		return MGUIState.Game;
	}

	public void SetUI(int score)
	{
		scoreText.text = score.ToString();
	}
}