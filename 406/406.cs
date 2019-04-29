public class Solution
{
    public int[][] ReconstructQueue(int[][] people)
    {
        if (people.Length == 0)
        {
            return people;
        }

        Array.Sort(people, (p1, p2) => (p1[0] > p2[0] || (p1[0] == p2[0] && p1[1] < p2[1])) ? -1 : 1);

        var result = new List<int[]>();
        foreach (var person in people)
        {
            result.Insert(person[1], person);
        }

        return result.ToArray();
    }
}
