using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody2D rb;
	[SerializeField] private Camera camera; 

	[SerializeField][Range(5, 20)] private float moveSpeed = 10f;
	[SerializeField] private GameObject particle;
	public Animator playerAnimator;
	public List<GameObject> itemPrefab;
	public GameObject selectItem;
	public Animator itemAnimator;

	private Vector2 rot;

	public void Awake()
	{

	}
	void Start()
	{
		this.transform.position = DataManager.instance.LoadData();
		rb = GetComponent<Rigidbody2D>();

		if (DataManager.instance.isBest)
		{
			StartCoroutine(Particle());
		}
	}

	public void SetItem(GameObject item)
	{
		{
			selectItem = item;

			foreach (var prefab in itemPrefab)
			{
				prefab.SetActive(false);
			}

			foreach (var prefab in itemPrefab)
			{
				if (prefab.name == item.name)
				{
					prefab.SetActive(true);
					itemAnimator = prefab.GetComponent<Animator>();
					return;
				}
			}
			var newItem = Instantiate(item, transform.position + new Vector3(rot.x * 0.8f, 0), quaternion.identity, transform);
			newItem.name = item.name;
			itemPrefab.Add(newItem);
			itemAnimator = itemPrefab[itemPrefab.Count - 1].GetComponent<Animator>();
		}
	}

	IEnumerator Particle()
	{
		particle.SetActive(true);
		DataManager.instance.isBest = false;
		yield return new WaitForSeconds(3f);
		particle.SetActive(false);
	}

	void OnDestroy()
	{
		DataManager.instance.SaveData(gameObject.transform.position);
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Rotate();
		if(itemPrefab.Count != 0) Attack();
	}

	void Move()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Vector2 move = new Vector2(x, y).normalized;

		rb.velocity = (Vector3)move * 10f;
		if (move != Vector2.zero)
		{
			playerAnimator.SetBool("isMove", true);
		}
		else
		{
			playerAnimator.SetBool("isMove", false);
		}
	}

	private void Rotate()
	{
		Vector2 mousePosition = Input.mousePosition;
		Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);

		rot = worldPos.x < transform.position.x ? new Vector3(-1, 1, 1) : new Vector3(1 ,1, 1);

		transform.localScale = rot;

		if (selectItem != null)
		selectItem.transform.localScale = rot;

		transform.GetComponentInChildren<Canvas>().transform.localScale = rot.x > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
	}

	void Attack()
	{
		if (Input.GetMouseButtonDown(0))
		{
			itemAnimator.SetTrigger("isAttack");
		}
	}
}
