using System;

public static class PlayerStateFactory
{
    public static IPlayerState CreateState(PlayerModes mode)
    {
        switch (mode)
        {
            case PlayerModes.Happy:
                return new HappyState();
            case PlayerModes.Sad:
                return new SadState();
            default:
                throw new ArgumentException("Invalid Player Mode");
        }
    }
}