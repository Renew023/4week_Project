using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameratest : MonoBehaviour
{
	public Transform target;
	public Collider2D wallCollider; // TilemapCollider2D or CompositeCollider2D
	public float smoothSpeed = 0.1f;
	private Camera cam;
	void Start()
	{
		cam = Camera.main;
	}
	void LateUpdate()
	{
		if (target == null || wallCollider == null) return;
		Vector3 desiredPos = new Vector3(target.position.x, target.position.y, transform.position.z);
		if (!IsCameraTouchingWall(desiredPos))
		{
			transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
		}
	}
	bool IsCameraTouchingWall(Vector3 camPos)
	{
		float vertExtent = cam.orthographicSize;
		float horzExtent = vertExtent * cam.aspect;
		Vector2[] corners = new Vector2[4];
		corners[0] = new Vector2(camPos.x - horzExtent, camPos.y - vertExtent); // Bottom-left
		corners[1] = new Vector2(camPos.x - horzExtent, camPos.y + vertExtent); // Top-left
		corners[2] = new Vector2(camPos.x + horzExtent, camPos.y + vertExtent); // Top-right
		corners[3] = new Vector2(camPos.x + horzExtent, camPos.y - vertExtent); // Bottom-right
		foreach (var corner in corners)
		{
			if (wallCollider.OverlapPoint(corner))
				return true; // 시야가 벽에 닿음
		}
		return false; // 시야 전체가 벽에 안 닿음
	}










}

