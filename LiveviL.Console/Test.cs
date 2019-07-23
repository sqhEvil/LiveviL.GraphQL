using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using LiveviL.Test;

namespace LiveviL.Test
{
    public class TestClass
    {
        public string TestGraphQL(string query)
        {
            var Schema = new Schema { Query = new GraphQLTest() };
            var executer = new DocumentExecuter();
            var result = executer.ExecuteAsync(
                options=>
                {
                    options.Schema = Schema;
                    options.Query = query;
                }).Result;
            var json = new DocumentWriter(indent: true).Write(result);
            return json;
        }
    }
}
