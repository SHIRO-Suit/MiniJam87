using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UIElements;

public class DebugUtilities : MonoBehaviour
{

    public bool showDebug;
    public Vector2 scrollPosition = Vector2.zero;
    float inputX = 0;
    float inputY =  0;
    Boolean toggleCollision = true;

    public bool ToggleCollision
    {
        get => toggleCollision;
        set
        {
            updateCollision();
            toggleCollision = value;
        } 
    }

    private void updateCollision()
    {
        print($"Collisioons are set to {ToggleCollision}");
        GameObject.FindObjectOfType<Controller>().player.bodyType = ToggleCollision
            ? RigidbodyType2D.Dynamic
            : RigidbodyType2D.Kinematic;
    }


    // Start is called before the first frame update
    void Start()
    {
        print("DEBUG GUI LOADED");
        showDebug = false;
        windowRect = new Rect(20, 20, 400, 400);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(";"))
        {
            this.showDebug = true;
        }
        if (Input.GetKey("escape"))
        {
            this.showDebug = false;
        }

    }
    
    public Rect windowRect;

    void OnGUI()
    {
        // Register the window.
        if (showDebug)
        {
            windowRect = GUI.ModalWindow(0, windowRect, DoMyWindow, "Debug tools");
        }
    }

    // Make the contents of the window
    void DoMyWindow(int windowID)
    {
        // Make a very long rect that is 20 pixels tall.
        // This will make the window be resizable by the top
        // title bar - no matter how wide it gets.
        GUI.DragWindow(new Rect(0, 0, 10000, 20));
        scrollPosition = GUI.BeginScrollView(new Rect(0, 20, 400, 400), scrollPosition, new Rect(0, 0, 400, 800));
        
        //<editor-fold desc="Player">
        GUI.Label(new Rect(10, 20, 400, 20),"Player");
        var position = GameObject.FindObjectOfType<Controller>().player.position;
        GUI.Label(new Rect(10, 40, 400, 20),$"Position: {position.x} / {position.y}");
        inputX = NumberField(new Rect(140, 60, 50, 20), inputX);
        inputY = NumberField(new Rect(230, 60, 50, 20), inputY);
        if (GUI.Button(new Rect(10, 60, 100, 20), "TELEPORT : "))
        {
            print($"TELEPORTING TO {inputX}/{inputY}");
            GameObject.FindObjectOfType<Controller>().player.position = new Vector2(inputX, inputY);
        }
        GUI.Label(new Rect(120, 60, 50, 20),"X : ");
        GUI.Label(new Rect(200, 60, 50, 20),"Y : ");
        float NumberField(Rect r, float? n)
        {
            string result = Regex.Replace(GUI.TextField(r, n.HasValue ? n.Value.ToString() : ""), "[^-.0-9]", "");
            if (string.IsNullOrEmpty(result))
            {
                return 0;
            }
            else
            {
                return float.Parse(result);
            }
        }
        //</editor-fold>

        ToggleCollision = GUI.Toggle(new Rect(10, 80, 130, 20), ToggleCollision, "Toggle collisions");


        GUI.EndScrollView();
    }
}
