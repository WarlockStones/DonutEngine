namespace DonutEngine.Backbone;
using System.Numerics;
using static DonutEngine.Backbone.Systems.DonutSystems;
using Box2DX.Dynamics;

public class EntityPhysics 
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public Body.BodyType Type { get; set; }
    public float Density { get; set; }
    public float Friction { get; set; }
    public float Restitution { get; set; }
    public Body? currentBody = null;


    public void InitEntityPhysics(Entity entity)
    {
        if (entity is DynamicEntity dynEnt)
        {
            currentBody = physicsSystem.CreateBody(this);
            ECS.ecsUpdate += Update;
        }
        else if (entity is StaticEntity staEnt)
        {
            currentBody = physicsSystem.CreateStaticBody(this);
        }
        
    }

    public void DestroyEntityPhysics() 
    {
        if(currentBody != null)
        {
            physicsSystem.DestroyBody(currentBody);
            ECS.ecsUpdate -= Update;

        }
    }

    public void Update(float deltaTime)
    {
        X = currentBody.GetPosition().X;
        Y = currentBody.GetPosition().Y;
    }

    public Vector2 GetVector2Pos()
    {
        Vector2 vector2 = new(X,Y);
        return vector2;
    }
}