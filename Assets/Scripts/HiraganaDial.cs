using UnityEngine;
using UnityEngine.UI;

// ひらがな1文字分のダイヤル。前後ボタンで50音を巡回する
public class HiraganaDial : MonoBehaviour
{
    public static readonly string[] Gojuon =
    {
        "あ","い","う","え","お",
        "か","き","く","け","こ",
        "さ","し","す","せ","そ",
        "た","ち","つ","て","と",
        "な","に","ぬ","ね","の",
        "は","ひ","ふ","へ","ほ",
        "ま","み","む","め","も",
        "や","ゆ","よ",
        "ら","り","る","れ","ろ",
        "わ","を","ん",
    };

    public Text label;

    private int index = 0;

    public string Character => Gojuon[index];

    void Start()
    {
        UpdateLabel();
    }

    public void Next()
    {
        index = (index + 1) % Gojuon.Length;
        UpdateLabel();
    }

    public void Previous()
    {
        index = (index - 1 + Gojuon.Length) % Gojuon.Length;
        UpdateLabel();
    }

    public void ResetDial()
    {
        index = 0;
        UpdateLabel();
    }

    void UpdateLabel()
    {
        if (label != null) label.text = Character;
    }
}
