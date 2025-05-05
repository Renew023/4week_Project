using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Camera camera;
    //[SerializeField] private Rigidbody2D slowCamera;
    private float offsetX;
    private float offsetY;
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    // Start is called before the first frame update

    void Start()
    {
        minBounds.x += camera.orthographicSize * Screen.width / Screen.height; //카메라의 크기만큼의 최소값을 정해준다.
		maxBounds.x += -(camera.orthographicSize * Screen.width / Screen.height) +1; //카메라의 크기만큼의 최대값을 정해준다.

		minBounds.y += camera.orthographicSize; //카메라의 크기만큼의 최소값을 정해준다.
		maxBounds.y += -(camera.orthographicSize) +1 ; //카메라의 크기만큼의 최대값을 정해준다.
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x; //트랜지션 본인 /대상만큼의 거리를 잰다.
        offsetY = transform.position.y - target.position.y; //트랜지션 본인
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;

		pos.x = target.position.x + offsetX; //대상 위치 + 본인 위치
        pos.y = target.position.y + offsetY;

        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x); //최소값과 최대값을 정해준다.
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);   

		transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f); 
        //부드럽게 이동
		//Vector2 direction = (target.position - transform.position);
		//slowCamera.velocity = Vector3.Lerp(direction, target.position, Time.deltaTime * 2f); //부드럽게 이동
		//slowCamera.velocity = direction * 1.5f;
		//slowCamera.velocity = Vector3.Lerp(pos, gameObject.transform.position, Time.deltaTime * 2f); 
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            
            //isEndLine = true;
            //slowCamera.velocity = transform.position - transform.position;
            return;
        }
    }

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //	if (collision.gameObject.CompareTag("wall"))
    //	{
    //		isEndLine = false;
    //		return;
    //	}
    //}
}
