using DocumentInterface;

public class ParcelPermitData : ILegal
{
    public string Name;
    public string DateOfBirth;
    public string TrackingNumber; // 운송장 번호
    public string IssueDate;     // 발급일자
    public string ExpiryDate;    // 만료일자
    public bool OfficialSeal;  // 관리국 인장

    public ParcelPermitData() { }
    public ParcelPermitData(string name, string dateOfBirth, string trackinNumber, string issueDate, string expiryDate, bool officialSeal)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        TrackingNumber = trackinNumber;
        IssueDate = issueDate;
        ExpiryDate = expiryDate;
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
                    Name = RandomMethod.Name();
                    GameSceneManager.Instance.wrongPart.Add($"택배허가서. 이름 다름");

                    break;
                }
            case 1:
                {
                    DateOfBirth = RandomMethod.RRN();
                    GameSceneManager.Instance.wrongPart.Add($"택배허가서. 주민번호 다름");
                    break;
                }
            case 2:
                {
                    TrackingNumber = RandomMethod.TrackingNumber();
                    GameSceneManager.Instance.wrongPart.Add($"택배허가서. TrackingNumber 다름");
                    break;
                }
            case 3:
                {
                    IssueDate = RandomMethod.IssueDate();
                    GameSceneManager.Instance.wrongPart.Add($"택배허가서. IssueDate 다름");

                    break;
                }
            case 4:
                {
                    ExpiryDate = RandomMethod.ExpiryDate();
                    GameSceneManager.Instance.wrongPart.Add($"택배허가서. ExpiryDate 다름");

                    break;
                }
            case 5:
                {
                    OfficialSeal = RandomMethod.Bool();
                    GameSceneManager.Instance.wrongPart.Add($"택배허가서. OfficialSeal 다름");

                    break;
                }
        }
    }
}
