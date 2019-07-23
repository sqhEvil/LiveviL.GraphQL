using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveviL.GraphQL.GraphQL
{
    public class LiveviLGraphQLSchema : Schema
    {
        public LiveviLGraphQLSchema(
            LiveviLGraphQLQuery query,
            LiveviLGraphQLMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
