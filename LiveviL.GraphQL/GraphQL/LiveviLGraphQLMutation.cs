using GraphQL.Types;
using LiveviL.GraphQL.GrpahType;
using LiveviL.GraphQL.Repository;

namespace LiveviL.GraphQL.GraphQL
{
    public class LiveviLGraphQLMutation : ObjectGraphType
    {
        public LiveviLGraphQLMutation(StudentRepository repository)
        {
            Description = "学生操作接口";
            Field<BooleanGraphType>("addStudent",
                arguments: new QueryArguments()
                {
                    new QueryArgument<StudentInputGraphType>(){ Name="student" }
                },
                resolve: context =>
                {
                    var student = context.GetArgument<Student>("student");
                    return repository.Add(student);
                },
                description:"新增学生");

            Field<BooleanGraphType>("updateStudent",
                arguments: new QueryArguments()
                {
                    new QueryArgument<StudentInputGraphType>(){ Name="student" },
                    new QueryArgument<IntGraphType>(){ Name="id"}
                },
                resolve: context =>
                {
                    var student = context.GetArgument<Student>("student");
                    var id = context.GetArgument<int>("id");
                    return repository.Update(id, student);
                },
                description:"编辑学生");
        }
    }
}
