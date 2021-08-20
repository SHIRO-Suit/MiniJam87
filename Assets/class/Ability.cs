using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Ability<T, TP>

    {
    private string name;
    private T effect;
    private float cooldown;
    private bool active;
    private TP player;

    public Ability(string name, float cooldown, TP player)
    {
        this.name = name;
        this.cooldown = cooldown;
        this.player = player;
        this.active = true;
    }

    public IEnumerator CooldownAbility()
    {
        Debug.Log("COOLING DOWN");
        DeactivateAbility();
        yield return new WaitForSeconds(cooldown);
        ActivateAbility();
    }

    void DeactivateAbility()
    {
        Debug.Log(name + " DEACTIVATED");
        this.active = false;
    }

    void ActivateAbility()
    {
        Debug.Log(name + " ACTIVATED");
        this.active = true;
    }

    public string Name
    {
        get => name;
        set => name = value;
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