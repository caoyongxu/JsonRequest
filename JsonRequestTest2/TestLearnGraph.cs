using Azure.Core;
using JsonRequest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace JsonRequestTest2
{
    [TestClass]
    public class TestLearnGraph
    {
        private const string Endpoint = "https://content.ops.microsoft-int.com/api/graph/query";
        //private const string Auth_scope = "https://content-proxy-sandbox.docs.microsoft.com/.default";

        [TestMethod]
        [DataRow(Query_skills)]
        public void TestMethod1(string query)
        {
            var q = query.Replace("\r\n", "").Replace(" ", "");
            AccessToken AzOpenAIAccessToken = HttpRequestHelper.GetAADPersonalToken();
            var result = HttpRequestHelper.ExecuteHttpPostAsync(q,
                Endpoint, AzOpenAIAccessToken.Token).GetAwaiter().GetResult();
            Console.WriteLine(q);
            Console.WriteLine(result);

            Assert.IsTrue(true);
        }


        private const string Query_skills = @"
{
    ""jsonData"": [
        {
            ""source"": {
                ""nodeType"": ""TAXONOMY_SKILLS"",
                ""as"": ""skills""
            }
        }
    ],
    ""select"": [
        ""skills""
    ]
}
";

        private const string Query_Roles = @"";
    }
}
