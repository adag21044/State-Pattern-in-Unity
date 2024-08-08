using System;
using Unity.VisualScripting;
using UnityEngine;

// Context class that holds a reference to the current state
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