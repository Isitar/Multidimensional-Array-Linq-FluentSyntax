using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProj.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var mySource = new List<string>[3, 2]
            {
                {new List<string> {"00hello", "world"}, new List<string> {"01hallo", "Welt"}},
                {new List<string> {"10hello", "world"}, new List<string> {"11hallo", "Welt"}},
                {new List<string> {"20hello", "world"}, new List<string> {"22hallo", "Welt"}},
            };

            // dummy Lösung mit foreach
            var resultListForeach = new List<string>();
            foreach (var sourceElem in mySource)
            {
                resultListForeach.Add(sourceElem.Aggregate("", someComplicatedStringAggr));
            }
            System.Console.WriteLine("dummy solution:");
            System.Console.WriteLine(string.Join(Environment.NewLine, resultListForeach));
            System.Console.WriteLine(new string('-', 20));


            // query syntax
            var resultListQuerySyntax =
                (from List<string> sourceElem in mySource
                 select sourceElem.Aggregate("", someComplicatedStringAggr)
                ).ToList();
            System.Console.WriteLine("query syntax solution:");
            System.Console.WriteLine(string.Join(Environment.NewLine, resultListQuerySyntax));
            System.Console.WriteLine(new string('-', 20));


            // fluent syntax
            var resultListFluentSyntax = mySource.Cast<List<string>>().Select(s => s.Aggregate("", someComplicatedStringAggr));
            System.Console.WriteLine("fluent syntax solution:");
            System.Console.WriteLine(string.Join(Environment.NewLine, resultListFluentSyntax));

            System.Console.ReadLine();
        }

        private static string someComplicatedStringAggr(string x, string y)
        {
            return x + " " + y;
        }

    }


}
