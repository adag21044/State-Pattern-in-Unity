# State Pattern Unity Project

This Unity project is an exemplary implementation of the **State Design Pattern**. The project demonstrates how to manage the behavior of a game object (in this case, a player character) that changes its state based on specific conditions. The project adheres to **SOLID principles** to ensure clean, maintainable, and scalable code.

## Project Overview

In this project, a player character changes its color based on its distance from a target object. The character can be in either a "Happy" or "Sad" state:

- **Happy State**: The player is close to the target (distance < 10 units) and is green.
- **Sad State**: The player is farther from the target (distance >= 10 units) and is red.

These states are managed using the State pattern, which allows the player to change its behavior dynamically as the game progresses.

## Key Concepts

### State Pattern
The **State Pattern** is a behavioral design pattern that allows an object to change its behavior when its internal state changes. In this project, the `Player` class acts as the context, and its behavior is determined by the current state (`HappyState` or `SadState`).

### SOLID Principles

- **Single Responsibility Principle (SRP)**: Each state class (`HappyState`, `SadState`) has a single responsibility: to define the behavior of the player in that particular state.
  
- **Open/Closed Principle (OCP)**: The `IPlayerState` interface allows the addition of new states without modifying existing code, making the system extendable.

## Code Structure

### `IPlayerState` Interface

```csharp
public interface IPlayerState
{
    void DoAction(Player player);
    void CheckState(Player player);
}
```

### `HappyState` Class
```csharp
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
```

### `SadState` Class
```csharp
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
```

### `Player` Class
```csharp
public class Player : MonoBehaviour
{
    public IPlayerState CurrentState { get; private set; }
    public Transform Target { get; set; }
    public float Distance { get; private set; }

    private void Start()
    {
        SetState(PlayerStateFactory.CreateState(PlayerModes.Happy));
    }

    private void Update()
    {
        Distance = Vector3.Distance(transform.position, Target.position);
        CurrentState.CheckState(this);
        CurrentState.DoAction(this);
    }

    public void SetState(IPlayerState newState)
    {
        CurrentState = newState;
    }
}
```

### `PlayerStateFactory` Class
```csharp
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
```

### `PlayerModes` Enum
```csharp
public enum PlayerModes 
{
    Happy,
    Sad
}
```


