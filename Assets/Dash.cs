using UnityEngine;

namespace DefaultNamespace
{
    public class Dash : Ability<Vector2, Rigidbody2D>
    {
        private float cooldown;
        Controller playerController;
        Vector3 nextposition;
       // private Tilemap collisionTilemap;
      

        public Dash(string name, float cooldown, Rigidbody2D player) : base(name, cooldown, player)
        {
            Active = true;
        }


        public void dashForward(Vector2 lastMove)
        {   
            playerController = Player.gameObject.GetComponent<Controller>(); // c'est pour des tests 
           // nextposition = playerController.collisionTilemap.CellToWorld(playerController.collisionTilemap.WorldToCell(Player.position) + Vector3Int.FloorToInt(lastMove.normalized)*2);
            //Debug.Log(playerController.collisionTilemap.GetTile(playerController.collisionTilemap.WorldToCell(Player.position)+Vector3Int.right));
            
            Debug.Log("DASHING");
            this.Player.MovePosition(Player.position + lastMove * 4 );
        }
    }
}