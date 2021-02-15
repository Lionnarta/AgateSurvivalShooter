using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ShootCommand : Command
{
    PlayerShooting playerShooting;

    public ShootCommand(PlayerShooting _playerShooting)
    {
        this.playerShooting = _playerShooting;
    }

    public override void Execute()
    {
        //MethodInfo mInfoMethod = playerShooting.GetType().GetMethod("Shoot", BindingFlags.Instance | BindingFlags.NonPublic);
        //mInfoMethod.Invoke(playerShooting, null);
        playerShooting.Shoot();
    }

    public override void UnExecute()
    {
        
    }
}
