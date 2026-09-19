using UnityEngine;
using UnityEngine.UI;

public class DetailViewController : MonoBehaviour
{
    public static DetailViewController Instance { get; private set; }

    public GameObject panel;
    public Text titleText;

    void Awake()
    {
        Instance = this;
        if (panel != null) panel.SetActive(false);
    }

    public void Open(Interactable target)
    {
        ICustomDetailView custom = target.GetComponent<ICustomDetailView>();
        if (custom != null)
        {
            custom.Show();
            return;
        }
        ShowMessage(target.displayName);
    }

    public void ShowMessage(string message)
    {
        if (titleText != null) titleText.text = message;
        if (panel != null) panel.SetActive(true);
    }

    public void Close()
    {
        if (panel != null) panel.SetActive(false);
    }
}
