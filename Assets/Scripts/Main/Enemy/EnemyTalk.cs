using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyTalk : MonoBehaviour
{
    [SerializeField] private GameObject talkText;
    [SerializeField] private TextMeshProUGUI talkData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowTalk(true);
            TalkDataManager.instance.Trigger(true);
        }
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			ShowTalk(false);
			TalkDataManager.instance.Trigger(false);
		}
	}

	public void ShowTalk(bool inColider)
    {
        talkData.text = TalkDataManager.instance.TalkData();
        talkText.SetActive(inColider);
    }
}
