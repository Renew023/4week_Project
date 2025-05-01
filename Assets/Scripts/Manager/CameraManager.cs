using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D slowCamera;
    private float offsetX;
    private float offsetY;
    private float MaxX;
    private float MaxY;
    private bool isEndLine = false; 

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x; //Ʈ������ ���� /���ŭ�� �Ÿ��� ���.
        offsetY = transform.position.y - target.position.y; //Ʈ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

		Vector3 pos = transform.position;

        pos.x = target.position.x + offsetX; //��� ��ġ + ���� ��ġ
        pos.y = target.position.y + offsetY;
        //transform.position = pos;
        //slowCamera.velocity = pos;
		slowCamera.velocity = Vector3.Lerp(pos, gameObject.transform.position, Time.deltaTime * 2f); 
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
        MaxX = transform.position.x;
        MaxY = transform.position.y;
		//isEndLine = true;
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
        //isEndLine = false;
	}
}
