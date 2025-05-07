using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGGameManager : MonoBehaviour
{
	public static MGGameManager instance;

	public static MGGameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<MGGameManager>();
			}
			return instance;
		}
	}


	public int curScore;
	public int highScore;
	public MiniGamePlayerMove mgPlayer;
	public MGBlock mgBlock;
	// Start is called before the first frame update
	public void Awake()
	{
		if (instance == null)
			instance = this;


		//datamanager = DataManager.instance;
		curScore = 0;
		highScore = DataManager.instance.MGLoadData();

		//var uiManager = MGUIManager.instance;
	}

	public void Restart()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void UpdataScore()
	{
		if (mgPlayer.isDead)
			return;
		Debug.Log("гоюл");
		MGUIManager.instance.UpdateScore(++curScore);
	}

	public void EndScore()
	{
		DataManager.instance.MGSaveData(curScore);
		highScore = DataManager.instance.MGLoadData();
		MGUIManager.instance.EndScore(curScore, highScore);
	}
}