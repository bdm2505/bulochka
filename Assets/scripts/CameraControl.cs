using System;
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
    private float camWidth;
    private float camHeight;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
        character = player.GetComponent<BaseCharacter>();
        min_x = container.bounds.min.x;
        min_y = container.bounds.min.y;
        max_x = container.bounds.max.x;
        max_y = container.bounds.max.y;
        var camera = GetComponent<Camera>();
        camWidth = camera.pixelWidth ;
        camHeight = camera.pixelHeight ;
        var res = camera.ScreenToWorldPoint(new Vector3(camWidth, camHeight)) - transform.position;
        camWidth = res.x;
        camHeight = res.y;
    }

    private float S(float v, float min, float max, float delta)
    {
        return Math.Max(min + delta, Math.Min(v, max - delta));
    }

    void FixedUpdate()
    {
        if (player)
        {
            offset = character.CalculateMoveVector() * 5;

            var target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            target = new Vector3(S(target.x, min_x, max_x, camWidth), S(target.y, min_y, max_y, camHeight), target.z);

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}