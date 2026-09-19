using UnityEngine;
using System.Collections;

public class DoorInteractable : MonoBehaviour
{
    [SerializeField] private Transform hinge;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float speed = 2f;

    private bool isOpen = false;
    private bool isAnimating = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (hinge == null) hinge = transform.parent;
        closedRotation = hinge.localRotation;
        openRotation = Quaternion.Euler(0f, openAngle, 0f) * closedRotation;
    }

    void OnMouseDown()
    {
        if (!isAnimating) StartCoroutine(ToggleDoor());
    }

    private IEnumerator ToggleDoor()
    {
        isAnimating = true;
        Quaternion from = hinge.localRotation;
        Quaternion to = isOpen ? closedRotation : openRotation;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            hinge.localRotation = Quaternion.Slerp(from, to, t);
            yield return null;
        }
        hinge.localRotation = to;
        isOpen = !isOpen;
        isAnimating = false;
    }
}
