using System;
using UnityEngine;

public class State : MonoBehaviour
{
    private PlayerModes playerMode = PlayerModes.Happy;
    public float distance;
    public Transform target;

    public void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        CheckState();
        DoAction();
        print("Player mode : "+ playerMode);
    }

    void CheckState()
    {
        if (distance < 10f)
        {
            playerMode = PlayerModes.Happy;
        }
        else
        if(distance < 20f && distance > 10f)
        {
            playerMode = PlayerModes.Sad;
        }
    }

    void DoAction()
    {
        switch (playerMode)
        {
            case PlayerModes.Happy:
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case PlayerModes.Sad:
                GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }
}
