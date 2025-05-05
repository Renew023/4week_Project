using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    //�� �Է¿� ���� ����

	[SerializeField] private GameObject explain;
	[SerializeField] private DoorController doorController;

	public bool isActive = false;

	public void DoorController()
    {
        doorController.isDoor = !doorController.isDoor;
		doorController.door.SetActive(doorController.isDoor);
    }

	void Init()
	{
		explain.SetActive(false);
	}

	void Awake()
	{
		Init();
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.R))
		{
			if(isActive)
			DoorController();
		}
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			explain.SetActive(true);
			isActive = true;
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			explain.SetActive(false);
			isActive = false;
		}
	}



//void around()
//    {
//		Vector2 origin = transform.position;// ��
//		Vector2 direction = (target.position - transform.position).normalized; //�÷��̾�
//		Debug.Log(direction);
//		RaycastHit2D check = Physics2D.Raycast(
//			origin,
//			direction,
//			1.5f,
//			(1 << LayerMask.NameToLayer("Player"))
//			);

//		int playerMask = 1 << LayerMask.NameToLayer("Player");


//		if (check.collider != null && ((1 << check.collider.gameObject.layer) & playerMask) != 0)
//		{
//			explain.SetActive(true);
//			if (Input.GetKeyDown(KeyCode.R))
//			{
//				DoorController();
//			}
//			isActive = true;
//		}
//		else
//		{
//			if (isActive)
//			{
//				explain.SetActive(false);
//				isActive = false;
//			}

//		}
//	}

    void OnDrawGizmos()
	{
		
		//Debug.Log(check.collider.gameObject.tag);
		//Gizmos.DrawLine(origin, target.position);
		//if (check.collider.gameObject.CompareTag("Player"))
		//{
		//	DoorController(); // �� ����
		//}
	}
}
