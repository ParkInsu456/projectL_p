using DocumentInterface;

public class CustomsClearanceData : ILegal
{
    public string name;
    public string DateOfBirth;
    public string CustomsNumber;
    public string IssueDate;
    public string ExpiryDate;
    public bool OfficialSeal;

    public CustomsClearanceData() { }
    public CustomsClearanceData(string name, string dateOfBirth, string customsNumber, string issueDate, string expiryDate, bool officialSeal)
    {
        this.name = name;
        DateOfBirth = dateOfBirth;
        CustomsNumber = customsNumber;
        IssueDate = issueDate;
        ExpiryDate = expiryDate;
        OfficialSeal = officialSeal;
    }

    public void OverrideRandomInfo()
    {
        System.Random random = new System.Random();
        int num = random.Next(0, 6);
        string reason;

        switch (num)
        {
            case 0:
                {
                    name = RandomMethod.Name();
                    reason = "Name";
                    break;
                }
            case 1:
                {
                    DateOfBirth = RandomMethod.RRN();
                    reason = "DateOfBirth";

                    break;
                }
            case 2:
                {
                    CustomsNumber = RandomMethod.CustomsNumber();
                    reason = "CustomsNumber";

                    break;
                }
            case 3:
                {
                    IssueDate = RandomMethod.IssueDate();
                    reason = "IssueDate";

                    break;
                }
            case 4:
                {
                    ExpiryDate = RandomMethod.ExpiryDate();
                    reason = "ExpiryDate";

                    break;
                }
            case 5:
                {
                    OfficialSeal = RandomMethod.Bool();
                    reason = "OfficialSeal";

                    break;
                }
            default:
                reason = "Unknown";
                break;
        }
        GameSceneManager.Instance.wrongPart.Add($"{this.GetType().Name}. {reason} 다름");
    }
}
