using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGameState : MonoBehaviour
{
    public abstract void Init();
    public abstract void UpdateState();
    public abstract void Enter();
    public abstract void Exit();       
}
