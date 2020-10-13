using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{

    private void Start()
    {
        GetComponent<Text>().text = Translator.Translate(GetComponent<Text>().text);
    }
}
