using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MiniGamePlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float MoveSpeed = 5;

    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rigidbody2D.velocity;
        velocity.x = MoveSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            velocity.y += MoveSpeed*6;
        }
        rigidbody2D.velocity = velocity;
        //.velocity = Vector3.Lerp(direction, target.position, Time.deltaTime * 2f);

		float angle = Mathf.Clamp((rigidbody2D.velocity.y * 5f*MoveSpeed), -30, 60);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
