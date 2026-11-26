namespace Homework9.task1.Interfaces;

public interface ICipher
{
    string Encode(string text);

    string Decode(string text);
}