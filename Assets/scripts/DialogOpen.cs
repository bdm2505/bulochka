using System;
using System.Collections;
using System.Collections.Generic;
using localization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogOpen : MonoBehaviour
{
    public Dialog dialog;
    public string [] keys;
    public GameObject player;
    public Sprite icon;

    void Start()
    {
        if (!player)
            player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == player)
            dialog.OpenDialog(icon, keys);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == player)
            dialog.CloseDialog();
    }
}