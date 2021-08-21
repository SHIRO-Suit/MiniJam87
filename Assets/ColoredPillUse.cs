using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace{
public class ColoredPillUse : Ability<string,Controller> 
{
    
    GameObject[] objectsWithColor;
    public ColoredPillUse (string name, float cooldown, Controller Player, bool active) : base(name, cooldown, Player){
        Active = active;
    }

    public override IEnumerator CooldownAbility(){
        Player.speed = 12;
        objectsWithColor = GameObject.FindGameObjectsWithTag(Effect);
        SetObjectsActive(false);
        yield return base.CooldownAbility();
        SetObjectsActive(true); // remets le layer desactivé une fois l'effet de la pillule estompé.
        Player.speed = 10;

    }
    public void UsePill(){ 
        
        

    }
    public void SetObjectsActive(bool active){ 
        foreach (GameObject obj in objectsWithColor){
            obj.SetActive(active); // desactive les murs
        }
    }

}
}