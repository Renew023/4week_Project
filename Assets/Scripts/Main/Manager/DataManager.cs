using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    public Vector3 playerPos;
    public int maxScore = 0;
    public bool isBest = false;

	public static DataManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<DataManager>();
				if (instance == null)
				{
					GameObject go = new GameObject("DataManager");
					instance = go.AddComponent<DataManager>();
					DontDestroyOnLoad(go);
				}
			}
			return instance;
		}
	}

	public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if(PlayerPrefs.HasKey("MaxScore"))
			maxScore = PlayerPrefs.GetInt("MaxScore");
		else
			PlayerPrefs.SetInt("MaxScore", 0);
		playerPos = new Vector3(0, 0, 0);
	}

    public Vector3 LoadData()
    {
            return playerPos;
	}

    public int MGLoadData()
    {
        return maxScore;
	}

    public void SaveData(Vector3 pos)
    {
        playerPos = pos;
    }
    
    public void MGSaveData(int highScore)
	{
        if (highScore > maxScore)
        {
            PlayerPrefs.SetInt("MaxScore", highScore);
			maxScore = highScore;
            isBest = true;
        }
	}
}
