/*
 * Lab 1
 * Rickard Yxelflod
 * NEU25G
 */

string input = string.Empty;
ulong sum = 0;

Console.Write("Enter a string of text: ");
input = Console.ReadLine();

for (int i = 0; i < input.Length; i++)
{
    int indexStart = i;
    int indexEnd = 0;
    string number = string.Empty;

    if (char.IsLetter(input[i])) continue;

    for (int j = i + 1; j < input.Length; j++)
    {

        if (char.IsLetter(input[j])) break;

        if (input[j] == input[i])
        {
            indexEnd = j;
            break;
        }
    }

    for (int k = 0; k < input.Length; k++)
    {
        if (indexStart >= indexEnd) break;
        else if (k >= indexStart && k <= indexEnd)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            number += input[k];
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write(input[k]);
    }


    if (indexStart < indexEnd)
    {
        sum += ulong.Parse(number);
        Console.Write($"\t{number}\n");
    }
}

Console.ForegroundColor = ConsoleColor.Gray;

if (sum > 0) Console.Write($"Sum: {sum}");