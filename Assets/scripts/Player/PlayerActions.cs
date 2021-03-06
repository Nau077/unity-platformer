using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions
{
    private Player player;
    public PlayerActions(Player player)
    {
        this.player = player;
    }

    public void Move(Transform transform)
    {
        player.Components.RigidBody.velocity = new Vector2(player.Stats.Direction.x * player.Stats.Speed * Time.deltaTime, player.Components.RigidBody.velocity.y);

        if (player.Stats.Direction.x != 0)
        {
            transform.localScale = new Vector3(player.Stats.Direction.x < 0 ? -1 : 1, 1, 1);
            player.Components.Animator.TryPlayAnimation("Body_Walk");
            player.Components.Animator.TryPlayAnimation("Legs_Walk");
            
        }
        else if (player.Components.RigidBody.velocity == Vector2.zero)
        {
            player.Components.Animator.TryPlayAnimation("Body_Idle");
            player.Components.Animator.TryPlayAnimation("Legs_Idle");
            
        }
    }

    public void Jump()
    {   
        if (player.Utilities.IsGrounded())
        {
            player.Components.RigidBody.AddForce(new Vector2(0, player.Stats.JumpForce), ForceMode2D.Impulse);
            player.Components.Animator.TryPlayAnimation("Legs_Jump");
            player.Components.Animator.TryPlayAnimation("Body_Jump");
        }
        
    }

    public void Attack()
    {
        player.Components.Animator.TryPlayAnimation("Legs_Attack");
        player.Components.Animator.TryPlayAnimation("Body_Attack");
    }

    public void TrySwapWeapon(WEAPON weapon)
    {
        player.Stats.Weapon = weapon;
        SwapWeapon();
    }
    
    public void SwapWeapon()
    {
        for (int i = 1; i < player.References.WeaponObjects.Length; i++)
        {
            player.References.WeaponObjects[i].SetActive(false);
        }
        // ???? ?????? ????? ?????? ????, ?? ???????????? ??????
        // 0 - ??? ??????
        if (player.Stats.Weapon > 0)
        {
            player.References.WeaponObjects[(int)player.Stats.Weapon].SetActive(true);
        }
    }
}
