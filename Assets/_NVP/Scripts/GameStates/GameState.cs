public abstract class GameState
{
    // +++ abstact fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public System.Action Update;


    // +++ abstract methods +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();
    
    
}