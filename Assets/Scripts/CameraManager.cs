using UnityEngine;
using CameraHandler = System.EventHandler<UnityEngine.Camera>;

public interface ICameraManager
{
    public event CameraHandler CameraEvent;
}

public class CameraManager : ICameraManager
{
    public event CameraHandler CameraEvent;

    public CameraManager()
    {
        
    }
}
