using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
public class Controller : MonoBehaviour
{
    
    
    public InputMaster Inputs; 
    public float InventoryRadius = 1f;
    public static Controller playerController;
    [SerializeField]
    public Dictionary<string,bool> Inventory = new Dictionary<string,bool>();
     private Vector2 _lastMove;
    
    //ABILITIES
    private Dash dash;

    public Rigidbody2D player;
    

   /*public static Controller getPlayerInstance(){
        if(!playerController){
            
        }

    }*/


    // Start is called before the first frame update
    void Awake(){
        Inventory.Add("Itefdgdfm1",false);
        Inventory.Add("Itedfgm2",false);
        Inventory.Add("Itdfgem3",false);
        //GameObject.Find("Image").GetComponent<Rigidbody2D>()
        player = GetComponent<Rigidbody2D>();
        Inputs = new InputMaster();
        _lastMove = new Vector2(1,0);
        dash = new Dash("DASH", 5, player);
        

    }
    void Start()
    {
        
        //GetComponent<Rigidbody2D>();
    }
    private void OnDrawGizmosSelected() {
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward,InventoryRadius);
    }
    // Update is called once per frame
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

        DisplayInv();

        


    }
    void FixedUpdate(){
        player.MovePosition( player.position +Arrows()*10 * Time.fixedDeltaTime); 
        this._lastMove = (Arrows()!=Vector2.zero?Arrows():this._lastMove);
        if (Input.GetKey("space"))
        {
            if (dash.Active)
            {
                dash.dashForward(this._lastMove);
                StartCoroutine(dash.CooldownAbility());
            }
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
}
}