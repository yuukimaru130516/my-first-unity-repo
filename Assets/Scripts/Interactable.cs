using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    public string id;
    public string displayName;
    public bool investigable = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!investigable) return;
        if (DetailViewController.Instance != null)
        {
            DetailViewController.Instance.Open(this);
        }
    }
}
