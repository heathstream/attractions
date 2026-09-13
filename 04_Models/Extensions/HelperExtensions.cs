namespace Models;

public static class HelperExtensions
{
    public static string ToTitleCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        char[] chars = str.ToLower().ToCharArray();
        chars[0] = char.ToUpper(chars[0]);

        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i - 1] == ' ')
                chars[i] = char.ToUpper(chars[i]);
        }

        return new string(chars);
    }
}
