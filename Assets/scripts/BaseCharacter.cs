using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseCharacter : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D body;
    private MoveController[] controllers;

    public MoveEvent _event;
    

    void Start()
    {
        if (_event == null)
            _event = new MoveEvent();
        
        body = GetComponent<Rigidbody2D>();
        controllers = GetComponents<MoveController>();
    }
    public void Move(Vector2 moveTo)
    {
        if (moveTo.x >= 0)
            SetRotation(-1f);

        if (moveTo.x < 0)
            SetRotation(1f);
        var vec = moveTo * (speed * Time.deltaTime);
        _event.Invoke(vec);
        body.MovePosition(body.position + vec);
    }

    private void SetRotation(float vec)
    {
        var s = transform.localScale;
        transform.localScale = new Vector3(vec * Math.Abs(s.x), s.y, s.z);
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
