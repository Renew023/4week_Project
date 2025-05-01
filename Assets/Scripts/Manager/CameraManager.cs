using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D slowCamera;
    private float offsetX;
    private float offsetY;
    private Vector3 maxVector;
    private Vector3 direction;
    private bool isEndLine = false; 

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;

        //offsetX = transform.position.x - target.position.x; //트랜지션 본인 /대상만큼의 거리를 잰다.
        //offsetY = transform.position.y - target.position.y; //트랜지션 본인
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if (isEndLine == true)
        {
            return;
		}

		//Vector3 pos = transform.position;

  //      pos.x = target.position.x + offsetX; //대상 위치 + 본인 위치
  //      pos.y = target.position.y + offsetY;
        Vector2 direction = (target.position - transform.position);
        slowCamera.velocity = Vector3.Lerp(direction, target.position, Time.deltaTime * 2f); //부드럽게 이동
																										   //slowCamera.velocity = direction * 1.5f;
																										   //slowCamera.velocity = Vector3.Lerp(pos, gameObject.transform.position, Time.deltaTime * 2f); 
	}

	//public void OnTriggerEnter2D(Collider2D collision)
	//{
    //       if(collision.gameObject.CompareTag("wall"))
	//	{
	//		isEndLine = true;
    //           slowCamera.velocity = transform.position - transform.position;
	//		return;
	//	}
	//}

	//public void OnTriggerExit2D(Collider2D collision)
	//{
	//	if (collision.gameObject.CompareTag("wall"))
	//	{
	//		isEndLine = false;
	//		return;
	//	}
	//}
}
