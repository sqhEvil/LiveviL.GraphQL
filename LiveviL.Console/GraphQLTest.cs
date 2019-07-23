using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveviL.Test
{
    public class Test
    {
        public string FieldA { get; set; }

        public int FieldB { get; set; }
    }

    public class GraphQLTest : ObjectGraphType<Test>
    {
        public GraphQLTest()
        {
            Field(x => x.FieldA);
            Field(x => x.FieldB);

            Field<ListGraphType<GraphQLTest>>("queryTestAll",
                resolve:context=>
                {
                    return tests;
                });

            Field<GraphQLTest>("queryTest",
                arguments:new QueryArguments() {
                    new QueryArgument<IntGraphType>()
                    {
                        Name="fieldB"
                    }
                },
                resolve: context =>
                {
                    var fieldB = context.GetArgument<int>("fieldB");
                    return tests.Where(x=>x.FieldB== fieldB).FirstOrDefault();
                });
        }


        List<Test> tests = new List<Test>()
        {
            new Test(){FieldA="AAA",FieldB=1 },
            new Test(){FieldA="BBB",FieldB=2 },
            new Test(){FieldA="CCC",FieldB=3 },
        };
    }
}
