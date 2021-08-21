using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Ability<T, TP> 

    {
    private string abilityName;
    private T effect;
    private float cooldown;
    private bool active;
    private TP player;

    public Ability(string name, float cooldown, TP player)
    {
        this.abilityName = name;
        this.cooldown = cooldown;
        this.player = player;
    }

    public virtual IEnumerator CooldownAbility()
    {
        Debug.Log("COOLING DOWN");
        DeactivateAbility();
        yield return new WaitForSeconds(cooldown);
        ActivateAbility();
        
    }

    

    void DeactivateAbility()
    {
        Debug.Log(abilityName + " DEACTIVATED");
        this.active = false;
    }

    void ActivateAbility()
    {
        Debug.Log(abilityName + " ACTIVATED");
        this.active = true;
    }

    public string AbilityName
    {
        get => abilityName;
        set => abilityName = value;
    }

    public T Effect
    {
        get => effect;
        set => effect = value;
    }

    public float Cooldown
    {
        get => cooldown;
        set => cooldown = value;
    }

    public bool Active
    {
        get => active;
        set => active = value;
    }

    public TP Player
    {
        get => player;
        set => player = value;
    }
    }
}