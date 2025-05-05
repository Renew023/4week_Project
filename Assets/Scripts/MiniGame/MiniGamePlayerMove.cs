using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MiniGamePlayerMove : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Transform playerTransform;

    private float MoveSpeed = 5;
    private float JumpPower = 10;
    private	float deathCooldown = 0f;

    public float angle = 0;

    public bool isFlap = false;
	public bool isDead = false;

	// Start is called before the first frame update
	void Start()
    {
		rigidbody2D.gravityScale = 0f;
		rigidbody2D.velocity = Vector2.zero;
	}

    // Update is called once per frame
    void Update()
    {
		if (isDead == false)
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				isFlap = true;
			}
		}
    }

	public void ReStart()
	{
		isDead = false;
	}

    void FixedUpdate()
    {
		if (isDead)
		{
			return;
		}
		rigidbody2D.gravityScale = 1f;
		Vector3 velocity = rigidbody2D.velocity;
		velocity.x = MoveSpeed;
		float curAngle = angle;

		if (isFlap)
		{
			velocity.y += JumpPower;
            isFlap = false;
		}

		rigidbody2D.velocity = velocity;
		angle = Mathf.Clamp((rigidbody2D.velocity.y * 5), -15, 45);
		angle = Mathf.Lerp(curAngle, angle, 0.05f);
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		rigidbody2D.velocity = Vector2.zero;
		deathCooldown = 0.5f;
        isDead = true;
		animator.SetBool("isDead", true);
        MGGameManager.instance.EndScore();
	}
}
