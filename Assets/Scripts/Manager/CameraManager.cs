using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float offsetX;
    private float offsetY;

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
		transform.position = pos;

	}
}
