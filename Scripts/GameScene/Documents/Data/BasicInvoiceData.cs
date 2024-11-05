using System;
using System.Collections.Generic;
using DocumentInterface;

[Serializable]
public class BasicInvoiceData : ILegal
{
    public string TrackingNumber;     // 운송장 번호
    public PersonInfo Sender;        // 보내는 사람
    public PersonInfo Recipient;        // 받는 사람
    public List<string> ParcelContents; // 택배 내용물
    public List<int> Quantity;          // 택배 수량
    public float Weight;                 // 중량
    //public int Fare;                       // 택배 요금
    public bool HasSenderSignature;     // 발송인 서명

    public BasicInvoiceData() { }
    public BasicInvoiceData(string trackingNumber, PersonInfo sender, PersonInfo recipient, List<string> parcelContents, List<int> quantity, float weight, bool hasSenderSignature)
    {
        TrackingNumber = trackingNumber;
        Sender = sender;
        Recipient = recipient;
        ParcelContents = parcelContents;
        Quantity = quantity;
        Weight = weight;
        //Fare = fare;
        HasSenderSignature = hasSenderSignature;
    }

    public void OverrideRandomInfo()
    {
        System.Random random = new System.Random();
        int num;
        if (GameManager.Instance.date <= 1)
        {
            num = random.Next(0, 1);
        }
        else
        {
            num = random.Next(0, 4);
        }
        string reason;

        switch (num)
        {
            case 0:
                {
                    Sender = RandomMethod.PersonInfo();
                    reason = "Sender";                    

                    break;
                }
            case 1:
                {
                    TrackingNumber = RandomMethod.TrackingNumber();
                    reason = "TrackingNumber";

                    break;
                }
            case 2:
                {
                    Recipient = RandomMethod.PersonInfo();
                    reason = "Recipient";

                    break;
                }
            case 3:
                {
                    ParcelContents = RandomMethod.ParcelContents();
                    reason = "ParcelContents";

                    break;
                }
                case 4:
                {
                    Quantity = RandomMethod.ParcelQuantity();
                    reason = "Quantity";
                    break;
                }
            case 5:
                {
                    Weight = RandomMethod.Weight();
                    reason = "Weight";
                    break;
                }
            default:
                reason = "Unknown";
                break;
        }
        GameSceneManager.Instance.wrongPart.Add($"{this.GetType().Name}. {reason} 다름");
    }
}
