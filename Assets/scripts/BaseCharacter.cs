using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D body;
    public Joystick joystick;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public virtual void Move(Vector2 moveTo)
    {
        if (moveTo.x > 0)
            transform.rotation = Quaternion.Euler(0,180,0);
        if (moveTo.x < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        body.MovePosition(body.position + moveTo* speed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        if (joystick != null)
        {
            Move(new Vector2(joystick.Horizontal, joystick.Vertical));

        }
        else Debug.Log("Joystick not found");
    }
}
