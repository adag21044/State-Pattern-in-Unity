// Context class that holds a reference to the current state

using UnityEngine;

public class SadState : IPlayerState
{
    public void DoAction(Player player)
    {
        player.GetComponent<Renderer>().material.color = Color.red;
    }

    public void CheckState(Player player)
    {
        if (player.Distance < 10f)
        {
            player.SetState(PlayerStateFactory.CreateState(PlayerModes.Happy));
        }
    }
}