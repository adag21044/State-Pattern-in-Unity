// State Interface following Open/Closed principle
public interface IPlayerState
{
    void DoAction(Player player);
    void CheckState(Player player);
}