using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTalk : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectAnswer;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    void Init()
    {
		for (int i = 0; i < 4; i++)
		{
			selectAnswer[i].GetComponent<SelectButton>().num = 0;
		}
	}

    public void Hide()
    {
		for (int i = 0; i < 4; i++)
		{
			selectAnswer[i].SetActive(false);
		}
	}

    public void Show(int num, List<string> talk)
    {
        Hide();
        for (int i = 0; i < num; i++)
        {
            selectAnswer[i].SetActive(true);
            selectAnswer[i].GetComponentInChildren<TextMeshProUGUI>().text = talk[i];
        }
    }

    void Click()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
