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
        minBounds.x += camera.orthographicSize * Screen.width / Screen.height; //ī�޶��� ũ�⸸ŭ�� �ּҰ��� �����ش�.
		maxBounds.x += -(camera.orthographicSize * Screen.width / Screen.height) +1; //ī�޶��� ũ�⸸ŭ�� �ִ밪�� �����ش�.

		minBounds.y += camera.orthographicSize; //ī�޶��� ũ�⸸ŭ�� �ּҰ��� �����ش�.
		maxBounds.y += -(camera.orthographicSize) +1 ; //ī�޶��� ũ�⸸ŭ�� �ִ밪�� �����ش�.
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x; //Ʈ������ ���� /���ŭ�� �Ÿ��� ���.
        offsetY = transform.position.y - target.position.y; //Ʈ������ ����
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;

		pos.x = target.position.x + offsetX; //��� ��ġ + ���� ��ġ
        pos.y = target.position.y + offsetY;

        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x); //�ּҰ��� �ִ밪�� �����ش�.
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);   

		transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f); 
        //�ε巴�� �̵�
		//Vector2 direction = (target.position - transform.position);
		//slowCamera.velocity = Vector3.Lerp(direction, target.position, Time.deltaTime * 2f); //�ε巴�� �̵�
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
