public class MoveUpCommand : ICommand
{
    public void Execute(IActor actor)
    {
        actor.MoveUp();
    }
}