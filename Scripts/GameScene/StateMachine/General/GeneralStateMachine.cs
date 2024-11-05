public class GeneralStateMachine : StateMachine
{
    public Document document { get; }
    public ActionFlags Flags { get; set; }
    public GeneralFirstState firstState { get; }
    public GeneralRefuseState refuseState { get; }
    public GeneralPermitState permitState { get; }
    

    public GeneralStateMachine(Document document)
    {
        this.document = document;
        Flags = new ActionFlags();
        Flags.Initialize();

        firstState = new GeneralFirstState(this);
        refuseState = new GeneralRefuseState(this);
        permitState = new GeneralPermitState(this);        
    }
}
