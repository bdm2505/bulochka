using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public float damping = 1.5f;
	private Vector2 offset = new Vector2(0, 0);
	public Transform player;
	private BaseCharacter character;
	public BoxCollider2D container;
	private float min_x;
	private float min_y;
	private float max_x;
	private float max_y;

	void Start()
	{
		if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
		character = player.GetComponent<BaseCharacter>();
		min_x = container.bounds.min.x;
		min_y = container.bounds.min.y;
		max_x = container.bounds.max.x;
		max_y = container.bounds.max.y;
	}

	void FixedUpdate()
	{
		if (player)
		{
				print("camera " + character.speed);
			offset = character.CalculateMoveVector() * 5;

			var target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
			if (target.x < min_x)
				target.x = min_x;
			else if (target.x > max_x)
				target.x = max_x;
			if (target.y < min_y)
				target.y = min_y;
			else if (target.y > max_y)
				target.y = max_y;

			Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}