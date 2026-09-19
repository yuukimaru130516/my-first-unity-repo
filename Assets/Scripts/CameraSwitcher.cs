using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;

    private int currentIndex = 0;

    void Start()
    {
        currentIndex = 0;
        UpdateActive();
    }

    public void Next()
    {
        if (cameras == null || cameras.Length == 0) return;
        currentIndex = (currentIndex + 1) % cameras.Length;
        UpdateActive();
    }

    public void Previous()
    {
        if (cameras == null || cameras.Length == 0) return;
        currentIndex = (currentIndex - 1 + cameras.Length) % cameras.Length;
        UpdateActive();
    }

    private void UpdateActive()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != null) cameras[i].enabled = (i == currentIndex);
        }
    }
}
