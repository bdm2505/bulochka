using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{
    private Image button;
    private bool mouseOnElement = false;
    public float speed = 3;

    private void Start()
    {
        button = gameObject.GetComponent<Image>();
    }
    public void OnMouseEnter()
    {
        mouseOnElement = true;
    }
    public void OnMouseExit()
    {
        mouseOnElement = false;
    }
    void Update()
    {
        if (mouseOnElement)
            button.color = Color.Lerp(button.color, Color.gray, Time.deltaTime * speed);
        else
            button.color = Color.Lerp(button.color, Color.black, Time.deltaTime * speed);
    }
}
