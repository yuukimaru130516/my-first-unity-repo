using UnityEngine;
using UnityEngine.UI;

// 謎①(本棚)専用のコントローラ。共通のHiraganaInputPanelを使って判定する
public class PuzzleBookshelfView : MonoBehaviour, ICustomDetailView
{
    public GameObject panel;
    public HiraganaInputPanel inputPanel;
    public Text resultText;
    public string answer = "マクラ";
    public string solvedFlag = "puzzle01_solved";

    void Awake()
    {
        if (inputPanel != null) inputPanel.OnSubmit += HandleSubmit;
    }

    public void Show()
    {
        if (resultText != null) resultText.text = "";
        if (panel != null) panel.SetActive(true);
    }

    public void Hide()
    {
        if (panel != null) panel.SetActive(false);
    }

    void HandleSubmit(string input)
    {
        if (resultText == null) return;

        if (HiraganaInputPanel.Judge(input, answer))
        {
            GameFlags.Set(solvedFlag, true);
            resultText.text = "正解！ 何かが変わった気がする。";
        }
        else
        {
            resultText.text = "ちがうようだ…";
        }
    }
}
