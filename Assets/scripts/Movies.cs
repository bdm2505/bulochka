using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movies : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        var dy = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        var dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        body.MovePosition(body.position + new Vector2(dx, dy));
    }
}
