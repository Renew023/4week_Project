using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameZone : MonoBehaviour
{
	[SerializeField] private GameObject miniGameUI;
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			miniGameUI.SetActive(true);
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if(miniGameUI != null)
				miniGameUI.SetActive(false);
			//UI Off;
		}
	}
}
