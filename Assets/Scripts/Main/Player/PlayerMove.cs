using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField][Range(5,20)] private float moveSpeed = 10f;
	[SerializeField] private GameObject particle;

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
	}

    void Move()
    {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y).normalized;

        rb.velocity = (Vector3)move * 10f;
	}
}
