using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WEAPON
{
    FISTS = 0,
    GUN,
    SWORD
}
public class WeaponSwapCommand : Command
{
    private Player player;
    private WEAPON weapon;
    public WeaponSwapCommand(Player player, WEAPON weapon, KeyCode key) : base(key) 
    {
        this.player = player;
        this.weapon = weapon;  
        
    }

    public override void GetKeyDown()
    {
        player.Actions.TrySwapWeapon(weapon);
    }
}
