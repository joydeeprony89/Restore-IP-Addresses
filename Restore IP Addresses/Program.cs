// See https://aka.ms/new-console-template for more information

// https://www.youtube.com/watch?v=61tN4YEdiTM
Solution s = new Solution();
var answer = s.RestoreIpAddresses("25525511135");
Console.WriteLine(string.Join(",", answer));

public class Solution
{
  public IList<string> RestoreIpAddresses(string s)
  {
    var res = new List<string>();
    Helper(0, 0, "");

    void Helper(int idx, int dotCount, string ip)
    {
      // base condition
      if (idx == s.Length && dotCount == 4)
      {
        res.Add(ip);
        return;
      }

      for (int size = 1; size <= s.Length - idx; size++)
      {
        var subStr = s.Substring(idx, size);
        if (subStr.Length > 1 && subStr.StartsWith("0") || subStr.Length > 3
        || (subStr.Length == 3 && Convert.ToInt32(subStr) >= 256)) break;
        Helper(idx + size, dotCount + 1, ip + subStr + (dotCount == 3 ? "" : "."));
      }
    }
    return res;
  }
}