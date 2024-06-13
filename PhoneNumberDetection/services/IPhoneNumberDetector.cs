namespace PhoneNumberDetection.services
{
    public interface IPhoneNumberDetector
    {
        bool ContainsPhoneNumber(string input);
    }
}
