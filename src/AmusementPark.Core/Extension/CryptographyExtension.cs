using System.Security.Cryptography;
using System.Text;

namespace AmusementPark.Core.Extension;

public static class CryptographyExtension
{
    public static string ToSha256(this string input)
    {
        //笔记一
        using var sha256 = SHA256.Create();
        return Convert.ToHexString(sha256.ComputeHash(Encoding.UTF8.GetBytes(input)));
    }
}