using System;
using System.Collections.Generic;
using UnityEngine;

// ひらがな3〜4文字を入力する汎用UI。謎①③④⑤で使い回す
public class HiraganaInputPanel : MonoBehaviour
{
    public List<HiraganaDial> dials = new List<HiraganaDial>();

    public event Action<string> OnSubmit;

    public string CurrentInput
    {
        get
        {
            string s = "";
            foreach (HiraganaDial d in dials) s += d.Character;
            return s;
        }
    }

    public void Submit()
    {
        OnSubmit?.Invoke(CurrentInput);
    }

    public void ResetDials()
    {
        foreach (HiraganaDial d in dials) d.ResetDial();
    }

    public static bool Judge(string input, string answer)
    {
        return input == answer;
    }
}
