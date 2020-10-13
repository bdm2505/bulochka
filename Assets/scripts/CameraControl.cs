using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public float damping = 1.5f;
	private Vector2 offset = new Vector2(0, 0);
	public Transform player;
	private BaseCharacter character;

	void Start()
	{
		if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
		character = player.GetComponent<BaseCharacter>();
	}

	void FixedUpdate()
	{
		if (player)
		{
			offset = character.CalculateMoveVector() * 5;

			var target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

			Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}