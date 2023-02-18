using static Raylib_cs.Raylib;
using Raylib_cs;
using DonutEngine.Backbone.Systems;


namespace DonutEngine
{
    public class Player : PlayerBehaviour
    {
        public bool canJump;
        public float speed;
        public const float playerJumpSpd = 350.0f;
		public const float playerHorSpd = 200.0f;
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            Tasks();
        }

        public void Tasks()
        {   
           MovePlayer();
        }

        public void MovePlayer()
        {
        }


    }
}