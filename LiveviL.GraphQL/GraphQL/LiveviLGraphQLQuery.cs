using GraphQL.Types;
using LiveviL.GraphQL.GrpahType;
using LiveviL.GraphQL.Repository;

namespace LiveviL.GraphQL.GraphQL
{
    public class LiveviLGraphQLQuery : ObjectGraphType
    {
        public LiveviLGraphQLQuery(StudentRepository repository)
        {
            Description = "学生查询接口";
            Field<StudentOutputGraphType>("student",
                arguments: new QueryArguments() {
                    new QueryArgument<IntGraphType>(){ Name="id"}
                },
                resolve: context =>
                 {
                     var id = context.GetArgument<int>("id");
                     return repository.GetById(id);
                 },
                 description:"根据id查询学生");

            Field<ListGraphType<StudentOutputGraphType>>("studnets",
                resolve: context =>
                {
                    return repository.GetAll();
                },
                description:"查询所有学生");

        }
    }
}
