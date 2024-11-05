using System;
using System.Collections;
using System.Collections.Generic;

public class EventSubject
{
    // Observer pattern

    public event Action OnUpdateUI;
    public event Action OnEndCustomer;
    public event Action OnCounter;
    public event Action OnFailAlarm;
    public event Action OnStamp;

    public event Action OnStampPermit;
    public event Action OnStampRefuse;
    public event Action OnCut;
    public event Action OnSticker;
    public event Action OnPutSticker;

    public event Action OnStampImage;

    public void EventUpdateUI()
    {
        OnUpdateUI?.Invoke();
    }
    public void EventEndCustomer()
    {
        OnEndCustomer?.Invoke();
    }
    public void EventCounter()
    {
        OnCounter?.Invoke();
    }
    public void EventFailAlarm()
    {
        OnFailAlarm?.Invoke();
    }
    public void EventStamp()
    {
        OnStamp?.Invoke();
    }


    public void EventStampPermit()
    {
        OnStampPermit?.Invoke();
    }
    public void EventStampRefuse()
    {
        OnStampRefuse?.Invoke();
    }
    public void EventCut()
    {
        OnCut?.Invoke();
        OnStampImage = null;
    }
    public void EventSticker()
    {
        OnSticker?.Invoke();
    }
    public void EventPutSticker()
    {
        OnPutSticker?.Invoke();
    }

    public void EventStampImage()
    {
        OnStampImage?.Invoke();
    }
}
