using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    //문 입력에 대해 반응
    private bool isDoorOpen = false;
    public Transform target;
    public GameObject door;
	public bool isActive = false;
	[SerializeField] private GameObject explain;

    public void DoorController()
    {
        isDoorOpen = !isDoorOpen;
        if (isDoorOpen)
        {
			door.SetActive(false);
		}
        else
        {
			door.SetActive(true);
		}
            
    }

	void Init()
	{
		explain.SetActive(false);
	}

	void Awake()
	{
		
	}

    // Start is called before the first frame update
    void Start()
    {
		Init();
	}

    // Update is called once per frame
    void Update()
    {
		around();
    }

    void around()
    {
		Vector2 origin = transform.position;// 문
		Vector2 direction = (target.position - transform.position).normalized; //플레이어
		Debug.Log(direction);
		RaycastHit2D check = Physics2D.Raycast(
			origin,
			direction,
			1.5f,
			(1 << LayerMask.NameToLayer("Player"))
			);

		int playerMask = 1 << LayerMask.NameToLayer("Player");
		if (check.collider != null && ((1 << check.collider.gameObject.layer) & playerMask) != 0)
		{
			explain.SetActive(true);
			if (Input.GetKeyDown(KeyCode.R))
			{
				DoorController();
			}
			isActive = true;
		}
		else
		{
			if (isActive)
			{
				explain.SetActive(false);
				isActive = false;
			}

		}
	}

    void OnDrawGizmos()
	{
		
		//Debug.Log(check.collider.gameObject.tag);
		//Gizmos.DrawLine(origin, target.position);
		//if (check.collider.gameObject.CompareTag("Player"))
		//{
		//	DoorController(); // 문 열기
		//}
	}
}
