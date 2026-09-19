using UnityEngine;

// 調べるとメッセージを表示し、必要ならフラグを立てるだけの汎用ビュー(アイテム入手など)
public class ItemPickupView : MonoBehaviour, ICustomDetailView
{
    public string message;
    public string itemFlag;

    public void Show()
    {
        if (!string.IsNullOrEmpty(itemFlag)) GameFlags.Set(itemFlag, true);
        if (DetailViewController.Instance != null) DetailViewController.Instance.ShowMessage(message);
    }
}
