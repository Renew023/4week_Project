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

        offsetX = transform.position.x - target.position.x; //트랜지션 본인 /대상만큼의 거리를 잰다.
        offsetY = transform.position.y - target.position.y; //트랜지션 본인
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

		Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX; //대상 위치 + 본인 위치
        pos.y = target.position.y + offsetY;
		transform.position = pos;

	}
}
