using System;
using System.Text;

namespace Anarchy.Helpers;

public class RandomCharacters
{
    private readonly Random _random = new Random();

    private const string string_0 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public string getRandomCharacters(int length)
    {
        StringBuilder stringBuilder;
        stringBuilder = new StringBuilder();
        for (int i = 1; i <= length; i++)
        {
            stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"[this._random.Next(0, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Length)]);
        }
        return stringBuilder.ToString();
    }
}