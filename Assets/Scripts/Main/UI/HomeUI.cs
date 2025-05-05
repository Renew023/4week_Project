using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI maxScore;

    public Vector3 playerPosition;

    public void Awake()
    {
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
        
	}

    void Start()
    {
		maxScore.text = DataManager.instance.MGLoadData().ToString();
	}

	public void OnClickStartButton()
    {
		SceneManager.LoadScene("GameScene");
	}

    public void OnClickExitButton()
    {
        gameObject.SetActive(false);
	}
}
