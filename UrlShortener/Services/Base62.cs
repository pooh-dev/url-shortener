using System.Text;

namespace UrlShortener.Services;

/// <summary>
/// Base62-encoding is similar to Base64-encoding except it only uses standard
/// English decimal digits and alphabet characters. It is useful for encoding data
/// in URLs because it is URL-safe and does not need escaped. This class provides
/// two pairs of encoders: an integer encoder/decoder (useful for encoding ids) and
/// a block-based encoder/decoder for arbitrary byte arrays.
/// </summary>
public static class Base62
{
    // NB. This code is published under the MIT License.
    // The original source code is available at:
    //   https://github.com/rossdempster/base62csharp

    private readonly static char[] _chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

    /// <summary>
    /// Encode a 64-bit number to base62. This has a maximum expansion
    /// of 11/8 (i.e. 8 bytes turn into 11 characters). Leading 0s are
    /// dropped (as you would expect if encoding to standard decimal).
    /// </summary>
    /// <param name="value">The value to encode.</param>
    public static string EncodeUInt64(ulong value)
    {
        // A 64-bit number has a maximum length of 11 characters when expressed
        // in base62. We start with the most significant position (=62^10) and see
        // how many of those are present in our ulong. This is the first encoded
        // character. Repeat through the remaining positions (62^9, 62^8 etc.).

        if (value == 0)
            return "0";

        var dividend = value;
        var divisor = 839299365868340224UL;     // 10000000000 base 62
        var result = new StringBuilder();
        var started = false;

        while (divisor > 0)
        {
            // How many of this base62 digit are present in value?
            var quotient = dividend / divisor;

            // Drop leading zeroes. We want a concise encoding.
            started |= quotient != 0;
            if (started)
                result.Append(_chars[quotient]);

            // Subtract and move to next digit.
            dividend -= quotient * divisor;
            divisor /= 62;
        }

        return result.ToString();
    }
}