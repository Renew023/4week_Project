using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI speedText;

	public int AddScore(int value, int speed)
	{
		value += speed;
		scoreText.text = value.ToString();
		return value;
	}

	public int AddSpeed(int score, int speed)
	{
		if ((speed+1)*(5*speed) - score <= 0)
		{
			speed++;
			speedText.text = speed.ToString();
		}
		return speed;
	}

	protected override UIState GetUIstate()
	{
		return UIState.Game;
	}
}
