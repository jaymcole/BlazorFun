using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstBlazerApp.Data
{
    public class StringResultService
    {
        public Task<List<StringResult>> GetStringResultsAsync(StringResult[] s)
        {
            List<StringResult> results = new List<StringResult>();
            for (int i = 0; i < s.Length; i++)
            {
                results.Add((GetStringResultAsync(s[i])).Result);
            }
            return Task.FromResult(results);
        }

        public Task<StringResult> GetStringResultAsync(StringResult result)
        {
            string input = result.InputString.ToLower();


            input = input.Replace("you", "j00");
            input = input.Replace("box", "[]");
            input = input.Replace("sand", "&");
            Regex regex = new Regex("a+n+e*d+");
            input = regex.Replace(input, "&");


            input = input.Replace('o', '0');
            input = input.Replace('l', '1');
            input = input.Replace('e', '3');
            input = input.Replace('a', '4');
            input = input.Replace('t', '7');

            result.OutputString = input;
            return Task.FromResult(result);
        }

    }
}
