﻿using DonutEngine;
using DonutEngine.Backbone;
using DonutEngine.Backbone.Systems;
using Raylib_cs;
using static DonutEngine.Backbone.Systems.DonutSystems;
using static Raylib_cs.Raylib;

static class Program
{
    public static int framesCounter = 0;
    public static SettingsVars settingsVars = new();
    public static AudioSystem audioSystem = new();
    public static WindowSystem windowSystem = new();
    public static InputEventSystem inputEventSystem = new();
    public static ScreenManager screenManager = new();
    public static void Main()
    {
        windowSystem.InitializeWindow();
        audioSystem.InitializeAudioSystem();
        screenManager.InitializeScreenManager();
        inputEventSystem.InitializeInputSystem();
        GameContainer.current.InitializeGameContainer();
        ECS.ProcessStart();
        MainLoopUpdate();
        Shutdown();
    }

    static void Shutdown()
    {
        ShutdownSystems();
        CloseWindow();
    }
    static void MainLoopUpdate()
    {
        while (!WindowShouldClose())
        {
            Time.RunDeltaTime();
            UpdateLoop();
            UpdateDraw();
            UpdateLate();
            
        }

        static void UpdateLoop()
        {
            UpdateSystems();
            screenManager.CurrentScreen();
        }

        static void UpdateDraw()
        {
            BeginDrawing();
            ClearBackground(Color.BLACK);
            screenManager.DrawCurrentScreen(Program.settingsVars.screenWidth, Program.settingsVars.screenHeight);
            EndDrawing();
        }

        static void UpdateLate()
        {
            screenManager.LateCurrentScreen();
        }
    }
}