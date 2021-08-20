using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Controller : MonoBehaviour
{
    
    
    public InputMaster Inputs; 
    public Rigidbody2D player;
    
    // Start is called before the first frame update
    void Awake(){
        //GameObject.Find("Image").GetComponent<Rigidbody2D>()
        player = GetComponent<Rigidbody2D>();
        Inputs = new InputMaster();
        

    }
    void Start()
    {
        
        //GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     player.MovePosition(player.position + Arrows() * Time.deltaTime);   
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
