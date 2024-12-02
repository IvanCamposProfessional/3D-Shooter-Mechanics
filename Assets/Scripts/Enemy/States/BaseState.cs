public abstract class BaseState{
    //Instance of enemy class
    public Enemy enemy;
    //Instance of state machine class
    public StateMachine stateMachine;

    //Abstract function to set the actions we want to perform when we use Mono Behaviour start
    //We will set up any properties we need to
    public abstract void Enter();
    //Abstract function to set the actions we will call it every frame the state is active
    //We process and monitor every action we need in real time
    public abstract void Perform();
    //Abstract function that will be called before we change into a new state
    //We can carry up all the necessary clean up
    public abstract void Exit();
}
