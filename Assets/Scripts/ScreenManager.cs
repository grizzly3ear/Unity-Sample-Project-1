using System;
using UnityEngine;

public interface IScreenManager
{
    public Rect GetScreenRect();
}

public class ScreenManager : IScreenManager
{
    private Rect currentRect;

    public ScreenManager(ICameraManager cameraManager)
    {
        cameraManager.CameraEvent += UpdateCamera;
        UpdateCamera(this, Camera.main);
    }

    private void UpdateCamera(object sender, Camera camera)
    {
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        currentRect = new Rect(bottomLeft.x, bottomLeft.y, topRight.x * 2f, topRight.y * 2f);
    }

    public Rect GetScreenRect()
    {
        return currentRect;
    }
}
