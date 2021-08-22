using UnityEngine;
using System.Collections;

namespace DefaultNamespace
{
    public class Dash : Ability<Vector2, Rigidbody2D>
    {
        private float cooldown;
        public bool isDashing = false;
        Controller playerController;
        Vector3 nextposition;
       // private Tilemap collisionTilemap;
      

        public Dash(string name, float cooldown, Rigidbody2D player) : base(name, cooldown, player)
        {
            Active = true;
        }


        public void dashForward(Vector2 lastMove)
        {   
            isDashing = true;
            playerController = Player.gameObject.GetComponent<Controller>(); // c'est pour des tests 
           // nextposition = playerController.collisionTilemap.CellToWorld(playerController.collisionTilemap.WorldToCell(Player.position) + Vector3Int.FloorToInt(lastMove.normalized)*2);
            //Debug.Log(playerController.collisionTilemap.GetTile(playerController.collisionTilemap.WorldToCell(Player.position)+Vector3Int.right));
            
            Debug.Log("DASHING");
            this.Player.MovePosition(Player.position + lastMove * 4 );

        }
        public IEnumerator isDashingDeactivator(){
            yield return new WaitForSeconds(0.4f);
            isDashing = false;
        }
    }
}