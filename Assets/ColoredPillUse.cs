using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace{
public class ColoredPillUse : Ability<string,Controller>
{
    GameObject[] objectsWithColor;
    public ColoredPillUse (string name, float cooldown, Controller Player) : base(name, cooldown, Player){

    }

    public override IEnumerator CooldownAbility(){
        yield return base.CooldownAbility();
        

    }
    public void UsePill(string color){ 
        Player.speed = 12;
        objectsWithColor = GameObject.FindGameObjectsWithTag(color);
        foreach (GameObject obj in objectsWithColor){
            obj.SetActive(false); // desactive les murs
        }
        StartCoroutine(CooldownAbility());

    }

}
}