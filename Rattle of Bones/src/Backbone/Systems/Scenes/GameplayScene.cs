namespace DonutEngine;
using DonutEngine.Backbone.Systems;
using DonutEngine.Backbone;
using Raylib_cs;

public class GameplayScene : Scene
{
    public PhysicsWorld? physicsWorld; 
    public GameObjects? gameObjects;

    public override void InitializeScene()
    {
        physicsWorld = new();
        physicsWorld.InitializePhysicsWorld();
        gameObjects = new();
        DonutSystems.Update += this.Update;
        DonutSystems.DrawUpdate += this.DrawUpdate;
        DonutSystems.LateUpdate += this.LateUpdate;
    }

    public override Scene UnloadScene()
    {
        DonutSystems.Update -= this.Update;
        DonutSystems.DrawUpdate -= this.DrawUpdate;
        DonutSystems.LateUpdate -= this.LateUpdate;
        return this;
    }

    public override void DrawUpdate()
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText(Raylib.GetFPS().ToString(), 12, 24, 20, Color.BLACK);
        Raylib.DrawRectangleV(new(0.0f, 100.0f),new(500,30), Raylib_cs.Color.BLACK);
    }
    public override void LateUpdate()
    {
        GameCamera2D.UpdateCameraPlayerBoundsPush(ref Program.donutCamera, gameObjects.player, 1f, Program.settingsVars.screenWidth, Program.settingsVars.screenHeight);
    }

    public override void Update()
    {
        physicsWorld.UpdateStep();
    }

    

    
}