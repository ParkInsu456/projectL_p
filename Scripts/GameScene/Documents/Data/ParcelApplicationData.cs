using System.Collections.Generic;
using DocumentInterface;

public class ParcelApplicationData : ILegal
{
    public string customsNumber;       // 통관 번호
    public string trackingNumber;       // 운송장 번호
    public float Weight;               // 중량
    public PersonInfo Recipient;       // 수취인
    public string ApplicationDate;     // 신청일자
    public List<string> ParcelContents; // 택배 내용물
    public List<int> Quantity;          // 택배 수량
    public ReceiptReason Purpose;       // 택배 목적, 배송 이유
    public string PersonalUseReason;    // 기타 배송 이유, ReceiptReason이 PersonalUse일 때 사용
    public bool OfficialSeal;         // 관리국 인장

    public ParcelApplicationData() { }
    public ParcelApplicationData(string customsNumber, string trackingNumber, float weight, PersonInfo recipient, string applicationDate, List<string> parcelContents, List<int> quantity, ReceiptReason purpose, string personalUseReason, bool officialSeal)
    {
        this.customsNumber = customsNumber;
        this.trackingNumber = trackingNumber;
        Weight = weight;
        Recipient = recipient;
        ApplicationDate = applicationDate;
        ParcelContents = parcelContents;
        Quantity = quantity;
        Purpose = purpose;
        PersonalUseReason = personalUseReason;
        OfficialSeal = officialSeal;
    }

    public void OverrideRandomInfo()
    {
        System.Random random = new System.Random();
        int num = random.Next(0, 6);

        switch (num)
        {
            case 0:
                {
                    customsNumber = RandomMethod.CustomsNumber();
                    GameSceneManager.Instance.wrongPart.Add($"ParcelApplication. CustomsNumber 다름");

                    break;
                }
            case 1:
                {
                    trackingNumber = RandomMethod.TrackingNumber();
                    GameSceneManager.Instance.wrongPart.Add($"ParcelApplication. TrackingNumber 다름");

                    break;
                }
            case 2:
                {
                    Recipient = RandomMethod.PersonInfo();
                    GameSceneManager.Instance.wrongPart.Add($"ParcelApplication. Recipient 다름");

                    break;
                }
            case 3:
                {
                    ApplicationDate = RandomMethod.IssueDate();
                    GameSceneManager.Instance.wrongPart.Add($"ParcelApplication. ApplicationDate 다름");

                    break;
                }
            case 4:
                {
                    ParcelContents = RandomMethod.ParcelContents();
                    GameSceneManager.Instance.wrongPart.Add($"ParcelApplication. ParcelContents 다름");

                    break;
                }
            case 5:
                {
                    Quantity = RandomMethod.ParcelQuantity();
                    GameSceneManager.Instance.wrongPart.Add($"ParcelApplication. Quantity 다름");

                    break;
                }
            case 6:
                {
                    Purpose = RandomMethod.ReceiptReason();
                    GameSceneManager.Instance.wrongPart.Add($"ParcelApplication. Purpose 다름");

                    break;
                }
            case 7:
                {
                    OfficialSeal = RandomMethod.Bool();
                    GameSceneManager.Instance.wrongPart.Add($"ParcelApplication. OfficialSeal 다름");

                    break;
                }            
        }
    }
}
