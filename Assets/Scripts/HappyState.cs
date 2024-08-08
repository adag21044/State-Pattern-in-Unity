using UnityEngine;

// Happy state class adhering to Single Responsibility Principle
public class HappyState : IPlayerState
{
    public void DoAction(Player player)
    {
        player.GetComponent<Renderer>().material.color = Color.green;
    }

    public void CheckState(Player player)
    {
        if (player.Distance >= 10f)
        {
            player.SetState(PlayerStateFactory.CreateState(PlayerModes.Sad));
        }
    }
    
}