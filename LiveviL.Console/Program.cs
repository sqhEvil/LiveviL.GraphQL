using System;

namespace LiveviL.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass test = new TestClass();
            string query1 = @"query{
                                queryTestAll{
                                  fieldB
                                  fieldA
                                }
                             }";
            Console.WriteLine("query1 Result:");
            Console.WriteLine(test.TestGraphQL(query1));
            string query2 = @"query{  queryTest(fieldB:1){
                                 fieldA
                              }}";
            Console.WriteLine("query2 Result:");
            Console.WriteLine(test.TestGraphQL(query2));
            Console.Read();
        }
    }
}
