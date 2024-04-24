string s1 = "привет".ToLower();
string s2 = "привет".ToLower();
Console.WriteLine(CompareStrings(s1, s2).First() * 100 + "%");

static List<double> CompareStrings(string s1, string s2)
{
    List<double> r = new();
    int[] max;
    int[] min;
    if (s1.Length > s2.Length)
    {
        max = StringToNumArray(s1);
        min = StringToNumArray(s2);
    }
    else
    {
        max = StringToNumArray(s2);
        min = StringToNumArray(s1);
    }

    for (int i = 0; i < max.Length - min.Length + 1; i++)
    {
        r.Add(Math.Abs(Correlation(max[i..(i + min.Length)], min)));
    }
    return r;
}


static int[] StringToNumArray(string s)
{
    int[] r = new int[s.Length];
    for (int i = 0; i < s.Length; i++)
        r[i] = (int)s[i];
    return r;
}

static double Correlation(int[] x, int[] y)
{
    double xAv = x.Average();
    double yAv = y.Average();

    double sum1 = 0;
    for (int i = 0; i < x.Length; i++)
        sum1 += (x[i] - xAv) * (y[i] - yAv);

    double sum2 = 0;
    for (int i = 0; i < x.Length; i++)
        sum2 += (x[i] - xAv) * (x[i] - xAv);

    double sum3 = 0;
    for (int i = 0; i < y.Length; i++)
        sum3 += (y[i] - yAv) * (y[i] - yAv);

    return sum1 / Math.Sqrt(sum2 * sum3);
}