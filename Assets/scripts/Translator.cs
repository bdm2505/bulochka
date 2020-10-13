using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator 
{
    public const int EN = 1;
    public const int RU = 0;
    public static int LANG = RU;

    private static Dictionary<string, string> en = new Dictionary<string, string>()
    {
        {"play", "play"},
        {"setting", "setting"}
    };
    private static Dictionary<string, string> ru = new Dictionary<string, string>()
    {
        {"play", "играть"},
        {"setting", "настройки"}
    };

    public static string Translate(string s)
    {
        var dic = LANG == RU ? ru : en;
        if (dic.ContainsKey(s))
            return dic[s];
        
        Debug.Log("no translate for '" + s + "'");
        return s;
    }
}
