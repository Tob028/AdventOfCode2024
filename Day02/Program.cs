var reports = new List<int[]>();
var safe = 0;

using (var reader = new StreamReader("./Input.txt"))
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var levels = line.Split(' ').Select(int.Parse).ToArray();
        reports.Add(levels);
    }
}

foreach (var report in reports)
{
    var isInRange = true;
    var isAscending = true;
    var isDescending = true;

    for (int i = 0; i < (report.Length - 1); i++)
    {
        var diff = report[i] - report[i + 1];
        var absDiff = Math.Abs(report[i] - report[i + 1]);

        if (absDiff < 1 || absDiff > 3)
        {
            isInRange = false;
            break;
        }

        if (diff > 0)
        {
            isAscending = false;
        }
        if (diff < 0)
        {
            isDescending = false;
        }
    }

    if (isInRange && (isAscending || isDescending))
    {
        safe++;
    }
}

Console.WriteLine(safe);