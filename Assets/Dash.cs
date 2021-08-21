using UnityEngine;

namespace DefaultNamespace
{
    public class Dash : Ability<Vector2, Rigidbody2D>
    {
        private float cooldown;

        public Dash(string name, float cooldown, Rigidbody2D player) : base(name, cooldown, player)
        {
        }
        

        public void dashForward(Vector2 lastMove)
        {
            Debug.Log("DASHING");
            this.Player.MovePosition(this.Player.position + lastMove * 4);
        }
    }
}