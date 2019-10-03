public class MoveDownCommand : ICommand
{
    public void Execute(IActor actor)
    {
        actor.MoveDown();
    }
}