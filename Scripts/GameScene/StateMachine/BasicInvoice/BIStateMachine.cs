public class BIStateMachine : StateMachine
{
    public BasicInvoice document { get; }
    public ActionFlags Flags { get; set; }
    public BIFirstState firstState { get; }
    public BIRefuseState refuseState { get; }
    public BIPermitState permitState { get; }
    public BICutState cutState { get; }
    public BIStickerState stickerState { get; }
    public BIPutStickerState putStickerState { get; }

    public BIStateMachine(BasicInvoice basicInvoice)
    {
        this.document = basicInvoice;
        Flags = new ActionFlags();
        Flags.Initialize();

        firstState = new BIFirstState(this);
        refuseState = new BIRefuseState(this);
        permitState = new BIPermitState(this);
        cutState = new BICutState(this);
        stickerState = new BIStickerState(this);
        putStickerState = new BIPutStickerState(this);
    }
}
