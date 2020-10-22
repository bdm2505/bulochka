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
    public SpriteRenderer sword;

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
        Debug.Log("Move");
        if (moveTo.x > 0)
        {
            SetRotation(1);
            sword.sortingOrder = 0;
        }

        if (moveTo.x < 0)
        {
            SetRotation(0);
            sword.sortingOrder = 4;
        }
            
        var vec = moveTo * (speed * Time.deltaTime);
        _event.Invoke(vec);
        body.MovePosition(body.position + vec);
    }

    private void SetRotation(float vec)
    {
        transform.rotation = Quaternion.Euler(0, 180 * vec, 0);
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
