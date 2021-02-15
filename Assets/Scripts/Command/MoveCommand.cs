using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class MoveCommand : Command
{
    PlayerMovement playerMovement;
    float h, v;

    public MoveCommand(PlayerMovement _playerMovement, float _h, float _v)
    {
        this.playerMovement = _playerMovement;
        this.h = _h;
        this.v = _v;
    }

    public override void Execute()
    {
        //MethodInfo mInfoMethod = playerMovement.GetType().GetMethod("Move", BindingFlags.Instance | BindingFlags.NonPublic);
        //MethodInfo mInfoMethod2 = playerMovement.GetType().GetMethod("Animating", BindingFlags.Instance | BindingFlags.NonPublic);
        //mInfoMethod.Invoke(playerMovement, new object[] { h, v });
        //mInfoMethod2.Invoke(playerMovement, new object[] { h, v });
        playerMovement.Move(h, v);
        playerMovement.Animating(h, v);
    }

    public override void UnExecute()
    {
        //MethodInfo mInfoMethod = playerMovement.GetType().GetMethod("Move", BindingFlags.Instance | BindingFlags.NonPublic);
        //MethodInfo mInfoMethod2 = playerMovement.GetType().GetMethod("Animating", BindingFlags.Instance | BindingFlags.NonPublic);
        //mInfoMethod.Invoke(playerMovement, new object[] { h, v });
        //mInfoMethod2.Invoke(playerMovement, new object[] { h, v });
        playerMovement.Move(-h, -v);
        playerMovement.Animating(h, v);
    }
}
