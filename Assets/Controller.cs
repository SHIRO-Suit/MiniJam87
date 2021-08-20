using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Controller : MonoBehaviour
{
    
    
    public InputMaster Inputs; 
    public float InventoryRadius = 1f;
    public static Controller playerController;
    [SerializeField]
    public Dictionary<string,bool> Inventory = new Dictionary<string,bool>();

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
        player.MovePosition(player.position + Arrows() * 2f* Time.deltaTime);   
        foreach(Collider2D obj in Physics2D.OverlapCircleAll(transform.position, InventoryRadius, 1<<5)){
            if(!Inventory.ContainsKey(obj.name)){
            Inventory.Add(obj.name,true);
            }else{
                Inventory[obj.name] = true;
            }

        }
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
