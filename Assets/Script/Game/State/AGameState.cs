using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGameState : MonoBehaviour
{
    protected GameController _gameController = null;

    public abstract void Init(GameController controller);
    public abstract void UpdateState();
    public abstract void Enter();
    public abstract void Exit();       
}
