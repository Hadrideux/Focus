using UnityEngine;

/// <summary>
/// Doing nothing. Its only purpose is to do nothing for the <see="EGameState.NONE"/>.
/// </summary>
public class DummyState : AGameState {

    public override void Init(TimerController controller){}

    public override void Enter(){}

    public override void Exit(){}

    public override void UpdateState(){}

}