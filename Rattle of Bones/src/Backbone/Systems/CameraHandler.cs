namespace DonutEngine.Backbone;
using System.Numerics;
using Raylib_cs;
using DonutEngine.Backbone.Systems;

public class CameraHandler
{
    public Camera2D donutcam;
    public void InitializeCamera(Vector2 target)
    {
        donutcam = new();
        donutcam.zoom = 1.0f;
        donutcam.offset = new Vector2(Program.settingsVars.screenWidth / 2, Program.settingsVars.screenHeight / 2);
        donutcam.target = target;
        DonutSystems.Update += UpdateCamera;
    }

    public void UpdateCamera()
    {

    }

    public void ChangeCameraTarget(Vector2 target)
    {
        donutcam.target = target;
    }
}
