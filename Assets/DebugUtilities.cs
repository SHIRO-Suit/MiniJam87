using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]
public class DebugUtilities : MonoBehaviour
{

    AudioSource audioData;
    public bool showDebug;
    public Vector2 scrollPosition = Vector2.zero;
    float inputX = 0;
    float inputY =  0;
    Boolean toggleCollision = true;
    public AudioClip[] audio_clips;
    private bool playedCollisionOffSound = false;
    public int avgFrameRate;
    float current = 0;

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
        if (!ToggleCollision && !audioData.isPlaying && !playedCollisionOffSound)
        {
            playedCollisionOffSound = true;
            StartCoroutine("collisionOff");
        }

        if (ToggleCollision)
        {
            playedCollisionOffSound = false;
        }
    }

    private IEnumerator collisionOff()
    {
        audioData.PlayOneShot(audio_clips[1]);
        yield return new WaitForSeconds(5);
        audioData.Stop();
    }


    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        print("DEBUG GUI LOADED");
        showDebug = false;
        windowRect = new Rect(20, 20, 400, 400);
    }

    // Update is called once per frame
    void Update()
    {
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;

        if (Input.GetKey(";"))
        {
            if (!showDebug)
            {
                audioData.PlayOneShot(audio_clips[0]);
            }
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
        //FPS
        GUI.Label(registerVerticalElement(false,400,20),$"FPS:{current}");
        //<editor-fold desc="Player">
        GUI.Label(registerVerticalElement(false,400,20),"Player");
        var position = GameObject.FindObjectOfType<Controller>().player.position;
        GUI.Label(registerVerticalElement(false,400,20),$"Position: {position.x} / {position.y}");
        inputX = NumberField(registerVerticalElement(false,50,20, 140), inputX);
        inputY = NumberField(registerVerticalElement(true,50,20,230), inputY);
        if (GUI.Button(registerVerticalElement(true,100,20), "TELEPORT : "))
        {
            print($"TELEPORTING TO {inputX}/{inputY}");
            GameObject.FindObjectOfType<Controller>().player.position = new Vector2(inputX, inputY);
        }
        GUI.Label(registerVerticalElement(true,50,20,120),"X : ");
        GUI.Label(registerVerticalElement(true,50,20,200),"Y : ");
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

        ToggleCollision = GUI.Toggle(registerVerticalElement(false,130,20), ToggleCollision, "Toggle collisions");


        GUI.EndScrollView();

        _rects.RemoveRange(0,_rects.Count);
    }

    List<Rect> _rects = new List<Rect>();
    Rect registerVerticalElement(bool keepSameHeight, int w, int h, int x = 10)
    {
        if (_rects.Count == 0)
        {
            _rects.Add(new Rect(0,0,0,0));
        }
        Rect ret;
        ret = keepSameHeight ? new Rect(x, _rects[_rects.Count - 1].y, w, h) : new Rect(x, _rects[_rects.Count - 1].y+20, w, h);
        _rects.Add(ret);
        print($"Registered rect {ret}");
        return ret;
    }
    
}
