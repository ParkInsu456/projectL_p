public class ActionFlags
{
    //private bool isStampPermit;
    public bool IsStampPermit { get; set; } = false;
    //private bool isStampRefuse;
    public bool IsStampRefuse { get; set; } = false;

    //private bool isCut;
    public bool IsCut { get; set; } = false;

    //private bool isSticker;
    public bool IsSticker { get; set; } = false;

    //private bool isPutSticker;
    public bool IsPutSticker { get; set; } = false;

    public void Initialize()
    {
        GameSceneManager.Instance.eventSubject.OnStampPermit += () => IsStampPermit = true;
        GameSceneManager.Instance.eventSubject.OnStampRefuse += () => IsStampRefuse = true;
        GameSceneManager.Instance.eventSubject.OnCut += IsCutMethod;
        GameSceneManager.Instance.eventSubject.OnSticker += () => IsSticker = true;
        GameSceneManager.Instance.eventSubject.OnPutSticker += () => IsPutSticker = true;
    }
    public void FalseAll()
    {
        IsStampPermit = false;
        IsStampRefuse = false;
        IsCut = false;
        IsSticker = false;
        IsPutSticker = false;
    }

    private void IsCutMethod()
    {
        IsCut = true;

    }
}