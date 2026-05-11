// insall package Ganss.Xss
using Ganss.Xss;

namespace YAWA.COM.Helpers
{
    public static class SanitizerHelper
    {
        private static readonly HtmlSanitizer _sanitizer
            = new HtmlSanitizer();

        public static string Sanitize(string? input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            return _sanitizer.Sanitize(input);
        }

    }
}