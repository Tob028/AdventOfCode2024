var colA = new List<int>();
var colB = new List<int>();
var frequency = new Dictionary<int, int>();
var sum = 0;

using (var reader = new StreamReader("./Input.txt"))
{
    while(!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var parts = line.Split("   ");

        colA.Add(int.Parse(parts[0]));
        colB.Add(int.Parse(parts[1]));

        frequency[int.Parse(parts[1])] = frequency.GetValueOrDefault(int.Parse(parts[1]), 0) + 1;
    }
}

colA.Sort();
colB.Sort();

for (var i = 0; i < colA.Count; i++)
{
    //var diff = Math.Abs(colA[i] - colB[i]);
    var num = colA[i];
    if (frequency.ContainsKey(num))
    {
        var similarity = num * frequency[num];
        sum += similarity;
    }
}

Console.WriteLine(sum);