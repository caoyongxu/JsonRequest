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
        [DataRow(Query_Roles)]
        //[DataRow(Query_lpCert)]
        public void TestMethod1(string query)
        {
            AccessToken AzOpenAIAccessToken = HttpRequestHelper.GetAADPersonalToken();
            var result = HttpRequestHelper.ExecuteHttpPostAsync(query,
                Endpoint, AzOpenAIAccessToken.Token).GetAwaiter().GetResult();
            Console.WriteLine(AzOpenAIAccessToken.Token);
            Console.WriteLine(query);
            Console.WriteLine(result);
        }


        private const string Query_Roles = @"
{
    ""query"": [
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

        private const string Query_lpCert = @"
{
    ""query"": [
        {
            ""source"": {
                ""nodeType"": ""learningpath"",
                ""properties"": {
                    ""uid"": ""LEARN.WWL.CREATE-COMPUTER-VISION-SOLUTIONS-AZURE-AI""
                }
            },
            ""relationship"": ""For-Certification"",
            ""target"": {
                ""nodeType"": ""certification""
            }
        }
    ],
    ""select"": [
        ""certification"",
        ""learningpath""
    ]
}";


        private const string Query_lp2Module = @"
{
    ""query"": [
        {
            ""source"": {
                ""nodeType"": ""learningpath"",
                ""properties"": {
                    ""uid"": ""LEARN.WWL.CREATE-COMPUTER-VISION-SOLUTIONS-AZURE-AI""
                }
            },
            ""relationship"": ""For-Certification"",
            ""target"": {
                ""nodeType"": ""certification""
            }
        }
    ],
    ""select"": [
        ""certification"",
        ""learningpath""
    ]
}";

    }
}
