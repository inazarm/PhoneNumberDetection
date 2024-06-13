using System.Text.RegularExpressions;

namespace PhoneNumberDetection.services
{
    public class PhoneNumberDetector : IPhoneNumberDetector
    {
        private readonly List<Regex> _numberPatterns;

        public PhoneNumberDetector()
        {
            _numberPatterns = new List<Regex>
            {
                // English number words
                new Regex(@"\b(one|two|three|four|five|six|seven|eight|nine|ten|eleven|twelve|thirteen|fourteen|fifteen|sixteen|seventeen|eighteen|nineteen|twenty)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled),
                // Urdu/Hindi number words
                new Regex(@"\b(ek|do|teen|char|paanch|chhah|saat|aath|nau|das)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled),
                // Roman numerals
                new Regex(@"\b(I|II|III|IV|V|VI|VII|VIII|IX|X)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled),
                new Regex(@"\b\d+[A-Za-z]*\b", RegexOptions.Compiled), // General digits with optional letters
                // Digits only
                new Regex(@"\b\d+\b", RegexOptions.Compiled),
                // Digits with letters before, after, or in between
                new Regex(@"\b([A-Za-z]*\d+[A-Za-z]*)\b", RegexOptions.Compiled)
            };
        }

        public bool ContainsPhoneNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (var pattern in _numberPatterns)
            {
                if (pattern.IsMatch(input))
                    return true;
            }

            return false;
        }
    }
}
