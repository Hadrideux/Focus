using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGameState : MonoBehaviour
{
    [SerializeField] protected TimerController _timerController = null;

    public abstract void Init(TimerController controller);
    public abstract void UpdateState();
    public abstract void Enter();
    public abstract void Exit();       
}

///
/// Changement de la phase de jeu dans les states   
///