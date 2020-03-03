using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            //int? tmp1 = null;
            //double tmp2 = 2.2;
            //string tmp3 = "aaa";
            //bool tmp4 = true;
            //var tmp51 = 1;
            //var tmp5 = "ala ma kota";
            //var tmp6 = "i psa";

            //var path = @"C:\Users\s18985\Desktop\cw1";

            //Console.WriteLine($"{ tmp5} { tmp6} {tmp51+tmp2}");

            //var newPerson = new Person { FirstName = "Julia" };

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

            //var httpClient = new HttpClient();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {                 
                    
            //httpClient.Dispose();
            //var response = await httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }


                    }
                }
            }
        }
    }
}
