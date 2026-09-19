using UnityEngine;

public class RoomViewSwitcher : MonoBehaviour
{
    public float[] yawAngles = new float[] { 180f, 90f, 270f, 0f };

    private int currentIndex = 0;

    void Start()
    {
        Apply();
    }

    public void Next()
    {
        currentIndex = (currentIndex + 1) % yawAngles.Length;
        Apply();
    }

    public void Previous()
    {
        currentIndex = (currentIndex - 1 + yawAngles.Length) % yawAngles.Length;
        Apply();
    }

    private void Apply()
    {
        transform.rotation = Quaternion.Euler(0f, yawAngles[currentIndex], 0f);
    }
}
