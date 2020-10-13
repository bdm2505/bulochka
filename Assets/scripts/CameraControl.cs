using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public float damping = 1.5f;
	private Vector2 offset = new Vector2(0, 0);
	public Transform player;
	private int lastX;
	public Joystick joystick;

	void Start()
	{
		if (player == null) FindPlayer();
		if (joystick == null) joystick = player.GetComponent<BaseCharacter>().joystick;
	}
	public void FindPlayer()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		lastX = Mathf.RoundToInt(player.position.x);
	}
	void FixedUpdate()
	{
		if (player)
		{
			offset = new Vector2(joystick.Horizontal*5, joystick.Vertical*5);
			int currentX = Mathf.RoundToInt(player.position.x);
			lastX = Mathf.RoundToInt(player.position.x);

			Vector3 target;

			target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

			Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}