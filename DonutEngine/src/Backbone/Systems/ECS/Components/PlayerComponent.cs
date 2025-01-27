namespace DonutEngine.Backbone;
using Box2DX.Common;
using DonutEngine.Backbone.Systems;
using Raylib_cs;

public class PlayerComponent : Component
{
    SpriteComponent? sprite = null;
    Entity? entity = null;
    public override void OnAddedToEntity(Entity entity)
    {
        this.entity = entity;
        sprite = entity.GetComponent<SpriteComponent>();
        ECS.ecsUpdate += Update;
        InputEventSystem.JumpEvent += OnJump;
        InputEventSystem.AttackEvent += OnAttack;
        InputEventSystem.DpadEvent += OnDpad;
    }

    public override void OnRemovedFromEntity(Entity entity)
    {
        ECS.ecsUpdate -= Update;
        InputEventSystem.JumpEvent -= OnJump;
        InputEventSystem.AttackEvent -= OnAttack;
        InputEventSystem.DpadEvent -= OnDpad;
        Dispose();
    }

    public void OnJump(CBool boolean)
    {
        if(boolean)
        {
            boolean = false;
            PlaySFX("confirmation001", 0.9f, 1.1f);
            entity.currentBody.ApplyImpulse(new(0,-20000), this.entity.currentBody.GetPosition());
        }
    }

    public void OnAttack(CBool boolean)
    {

    }

    public void OnDpad(Vec2 vector)
    {
        entity.currentBody.ApplyImpulse(new(Math.Clamp(vector.X * 900, -900, 900),vector.Y), entity.currentBody.GetPosition());
    }

    public void Update(float deltaTime)
    {
        bool PlayerHasHorizonalVelocity = Math.Abs(entity.currentBody.GetLinearVelocity().X) > Math.FLOAT32_EPSILON;
        if(PlayerHasHorizonalVelocity)
        {
            sprite.FlipSprite(PlayerHasHorizonalVelocity);
        }
    }
}