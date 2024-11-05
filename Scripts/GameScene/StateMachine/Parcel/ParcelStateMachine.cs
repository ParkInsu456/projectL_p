
using UnityEngine;

public class ParcelStateMachine : StateMachine
{
    public Parcel document { get; }
    public ActionFlags Flags { get; set; }
    public ParcelFirstState firstState { get; }
    public ParcelRefuseState refuseState { get; }
    public ParcelPermitState permitState { get; }
    public ParcelCutState cutState { get; }
    public ParcelStickerState stickerState { get; }
    public ParcelPutStickerState putStickerState { get; }

    public ParcelStateMachine(Parcel basicInvoice)
    {
        this.document = basicInvoice;
        Flags = new ActionFlags();
        Flags.Initialize();

        firstState = new ParcelFirstState(this);
        refuseState = new ParcelRefuseState(this);
        permitState = new ParcelPermitState(this);
        cutState = new ParcelCutState(this);
        stickerState = new ParcelStickerState(this);
        putStickerState = new ParcelPutStickerState(this);
    }
}
