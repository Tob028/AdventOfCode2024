using System.Text.RegularExpressions;

var input = File.ReadAllText("input.txt");
var pattern = @"(mul\(\d+,\d+\))|(do\(\))|(don't\(\))";
var sum = 0;

var matches = Regex.Matches(input, pattern);
var doMul = true;

foreach (Match match in matches)
{
    if (match.Value == "do()")
    {
        doMul = true;
    }
    else if (match.Value == "don't()")
    {
        doMul = false;
    }
    else
    {
        if (!doMul)
        {
            continue;
        }
        var values = match.Value.Split("(")[1].Split(")")[0].Split(",");
        var a = int.Parse(values[0]);
        var b = int.Parse(values[1]);
        var result = a * b;
        sum += result;
    }
}

Console.WriteLine(sum);