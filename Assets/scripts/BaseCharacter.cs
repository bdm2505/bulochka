using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D body;
    private MoveController[] controllers;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        controllers = GetComponents<MoveController>();
    }
    public void Move(Vector2 moveTo)
    {
        if (moveTo.x > 0)
            transform.rotation = Quaternion.Euler(0,180,0);
        if (moveTo.x < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        body.MovePosition(body.position + moveTo * (speed * Time.deltaTime));
    }

    public Vector2 CalculateMoveVector()
    {
        var vector = Vector2.zero;
        foreach (var controller in controllers)
        {
            vector += controller.Movies();
        }

        return vector;
    }
    void FixedUpdate()
    {
        Move(CalculateMoveVector());
    }
}
