using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using LiveviL.GraphQL.GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LiveviL.GraphQL.Controllers
{
    [Route("api")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly LiveviLGraphQLSchema _schema;

        public GraphQLController(LiveviLGraphQLSchema schema)
        {
            _schema = schema;
        }

        [Route("graphql")]
        public IActionResult GraphQL()
        {
            var query = string.Empty;
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                query = sr.ReadToEnd();
            }
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok();
            }
            var request = JsonConvert.DeserializeObject<GraphRequest>(query);
            var executer = new DocumentExecuter();
            var document = executer.ExecuteAsync(options =>
            {
                options.Schema = _schema;
                options.Query = request.Query;
            }).Result;
            var result = new DocumentWriter(indent: true).Write(document);
            return Ok(result);
        }

        public class GraphRequest
        {
            public string Query { get; set; }
        }
    }
}