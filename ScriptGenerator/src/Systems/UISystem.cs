using DonutEngine.Backbone.Systems.UI;
using Raylib_cs;
using ImGuiNET;
using System.Numerics;
namespace DonutEngine.Backbone.Systems;

public class UISystem : SystemsClass
{
    static bool Open = true;
    static bool ImGuiDemoOpen = false;
    static RenderTexture2D UIRenderTexture;
    static Rectangle rect = new(0,0,Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

    static SceneViewWindow sceneViewWindow = new();
    static ImageViewerWindow imageViewerWindow = new();
    

    public override void Update()
    {
        if (!Open)
                return;
        if (Raylib.IsWindowResized())
            {
                Raylib.UnloadRenderTexture(UIRenderTexture);
                UIRenderTexture = Raylib.LoadRenderTexture(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
            }
    }
    public override void DrawUpdate()
    {
        if (!Open)
        {
            return;
        }
        else
        {
            Raylib.BeginTextureMode(UIRenderTexture);
            rlImGui.Begin();
            DoMainMenu();
            //ImGui.ShowDemoWindow();
            if (ImGuiDemoOpen)
            {
                ImGui.ShowDemoWindow(ref ImGuiDemoOpen);
            }
            rlImGui.End();
            Raylib.EndTextureMode();
            
            //Raylib.DrawTexture(UIRenderTexture.texture, 0, 0, Color.WHITE);
            Raylib.DrawTextureQuad(UIRenderTexture.texture, new(1,-1), Vector2.Zero, rect, Color.WHITE);
        }
    }

    public override void LateUpdate()
    {
        
    }

    public override void Shutdown()
    {
        rlImGui.Shutdown();
        Raylib.UnloadRenderTexture(UIRenderTexture);
    }

    public override void Start()
    {
        UIRenderTexture = Raylib.LoadRenderTexture(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        rlImGui.Setup(true);
        System.Console.WriteLine("Started UI sys");
    }

    private static void DoMainMenu()
    {
        if (ImGui.BeginMainMenuBar())
        {
            if (ImGui.BeginMenu("File"))
            {
                if (ImGui.MenuItem("Entity Factory"))
                {
                    
                }
                if (ImGui.MenuItem("Exit"))
                {
                    Raylib.CloseWindow();
                }

                ImGui.EndMenu();

            }

            if (ImGui.BeginMenu("Window"))
            {
                //ImGui.MenuItem("Reload Entities", string.Empty, )
                ImGui.MenuItem("ImGui Demo", string.Empty, ref ImGuiDemoOpen);

                ImGui.EndMenu();
            }
            ImGui.EndMainMenuBar();
        }
    }
}

