using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
public class Controller : MonoBehaviour
{
    
    public float speed = 10;
    public InputMaster Inputs; 
    public float InventoryRadius = 1f;
    public static Controller playerController;
    [SerializeField]
    public Dictionary<string,bool> Inventory = new Dictionary<string,bool>();
     private Vector2 _lastMove;
    
    //ABILITIES
    private Dash dash;
    private ColoredPillUse coloredPillUse;

    public Rigidbody2D player;
    public Tilemap DestructCollTilemap, DestructGraphicTilemap; // Affichage et collisions du tilemap Des objets destructibles
     
    
    

   /*public static Controller getPlayerInstance(){
        if(!playerController){
            
        }

    }*/


    // Start is called before the first frame update
    void Awake(){
        
        Inventory.Add("BluePill",false);
        Inventory.Add("BlackPill",false);
        Inventory.Add("RedPill",false);
        Inventory.Add("PurplePill",false);
        //GameObject.Find("Image").GetComponent<Rigidbody2D>()
        player = GetComponent<Rigidbody2D>();
        Inputs = new InputMaster();
        _lastMove = new Vector2(1,0);
        dash = new Dash("DASH", 5, player);
        coloredPillUse = new ColoredPillUse("COLOREDPILLUSE",5,this,false);
        

    }
    void Start(){
        DestructGraphicTilemap = GameObject.Find("DisplayTiles").GetComponent<Tilemap>();
        DestructCollTilemap = GameObject.Find("CollideTiles").GetComponent<Tilemap>();
    }

    private void OnDrawGizmosSelected() {
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward,InventoryRadius);
    }



    void Update()
    {
        

        foreach(Collider2D obj in Physics2D.OverlapCircleAll(transform.position, InventoryRadius, 1<<3)){
            
            if(!Inventory.ContainsKey(obj.name)){
                obj.gameObject.SetActive(false);
                Inventory.Add(obj.name,true);
            }else{
                if(!Inventory[obj.name]) obj.gameObject.SetActive(false);
                Inventory[obj.name] = true;
            }
            

        }

        //DisplayInv();

        


    }
    private void OnCollisionStay2D(Collision2D other) {
        
     
        if(dash.isDashing){
            Vector2 position =other.contacts[0].point - other.contacts[0].normal * 0.1f;
            Debug.DrawRay(other.contacts[0].point, other.contacts[0].normal,Color.red,3);
            DestructCollTilemap.SetTile(DestructCollTilemap.WorldToCell(position),null);
            DestructGraphicTilemap.SetTile(DestructGraphicTilemap.WorldToCell(position), null);
        }
        
    }
    void FixedUpdate(){
        player.MovePosition( player.position +Arrows()*speed * Time.fixedDeltaTime); 
        this._lastMove = (Arrows()!=Vector2.zero?Arrows():this._lastMove);
        if (Input.GetKey("space"))
        {
            if (dash.Active)
            {
                dash.dashForward(this._lastMove);
                StartCoroutine(dash.isDashingDeactivator());
                StartCoroutine(dash.CooldownAbility());
                
            }
        }
        if(Input.GetKey(KeyCode.Alpha1)){
            if(CheckInventory("RedPill")){
                Use("RedPill");
                // lance fonction Ability
                coloredPillUse.Effect = "RedPill"; // set le tag des objets correspondants a desactiver.
                StartCoroutine(coloredPillUse.CooldownAbility()); // execute la commande :
                // desactive les murs et rends le joueur plus rapide, puis apres 5 sec, remets tout normal
            }
            
        }
        if(Input.GetKey(KeyCode.Alpha2)){
             if(CheckInventory("BluePill")){
                Use("BluePill");
                coloredPillUse.Effect = "BluePill"; 
                StartCoroutine(coloredPillUse.CooldownAbility());
            }
        }
        if(Input.GetKey(KeyCode.Alpha3)){
             if(CheckInventory("PurplePill")){
                Use("PurplePill");
                coloredPillUse.Effect = "PurplePill"; 
                StartCoroutine(coloredPillUse.CooldownAbility());
            }
        }
        
    }
    void Use(string name){
        Inventory[name] = false;
    }

    bool CheckInventory(string name){
        if(Inventory.ContainsKey(name)){ 
            return Inventory[name];
        }else{
            return false;
        }
    }


    void DisplayInv(){
        foreach(KeyValuePair<string, bool> item in Inventory){
            Debug.Log(item.Key +" : "+item.Value);
        }
    }


    public Vector2 Arrows(){
        return Inputs.Inputsplayer.Directions.ReadValue<Vector2>();
    }
    void OnEnable(){
        Inputs.Enable();
    }
    void OnDisable(){
        Inputs.Disable();
    }

    public Dash Dash
    {
        get => dash;
        set => dash = value;
    }
}
}