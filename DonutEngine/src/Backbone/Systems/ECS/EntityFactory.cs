namespace DonutEngine.Backbone.Factory;
using DonutEngine.Backbone.Systems;
using Newtonsoft.Json;

public class EntityFactory 
{
    private int nextEntityId = 1;

    public Entity CreateEntity(string jsonPath) 
    {
        System.Console.WriteLine(jsonPath);
        string json = File.ReadAllText(jsonPath);
        dynamic data = JsonConvert.DeserializeObject(json);

        Entity? currentEntity = null;
        currentEntity = new Entity(nextEntityId++, data);
        CreateComponents(data, currentEntity);
        return currentEntity;
    }

    public void CreateComponents(dynamic data, Entity entity)
    {
        Component? component = null;
        foreach (dynamic componentData in data.Components) 
        {
            if(component != null)
            {
                component = null;
            }
            switch (componentData.Type.ToString()) 
            {
                /*case "Tags":
                {
                    foreach(string s in componentType.)
                    {
                        entity.Tags.Add(s.Length.ToString());
                    }
                }
                break;*/
                case "SpriteComponent":
                    component = new SpriteComponent
                    {
                        Sprite = Raylib_cs.Raylib.LoadTexture(DonutFilePaths.app+DonutSystems.settingsVars.spritesPath + componentData.Sprite.ToString()),
                        Width = int.Parse(componentData.Width.ToString()),
                        Height = int.Parse(componentData.Height.ToString()),
                        AnimatorName = componentData.AnimatorName.ToString(),
                        FramesPerRow = int.Parse(componentData.FramesPerRow.ToString()),
                        Rows = int.Parse(componentData.Rows.ToString()),
                        FrameRate = int.Parse(componentData.FrameRate.ToString()),
                        PlayInReverse = bool.Parse(componentData.PlayInReverse.ToString()),
                        Continuous = bool.Parse(componentData.Continuous.ToString()),
                        Looping = bool.Parse(componentData.Looping.ToString())
                    };
                    break;
                case "GameCamera2D":
                    component = new GameCamera2D
                    {
                        IsActive = bool.Parse(componentData.IsActive.ToString())
                    };
                    break;
                case "PlayerComponent":
                    component = new PlayerComponent
                    {

                    };
                    break;
                case "ParticleSystem":
                    component = new ParticleSystem
                    {
                        maxParticles = int.Parse(componentData.maxParticles.ToString()),
                        emitRate = float.Parse(componentData.emitRate.ToString()),
                        textureName = componentData.textureName.ToString()
                    };
                    break;
                // add support for additional components as needed
            }
            if (component != null) 
            {
                entity.AddComponent(component, entity);
            }; 
        }
    }
}   