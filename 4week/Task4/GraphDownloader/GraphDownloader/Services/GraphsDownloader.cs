using GraphDownloader.Models;
using Newtonsoft.Json.Linq;
using Octokit;

namespace GraphDownloader.Services
{
    public class GraphsDownloader
    {
        public async IAsyncEnumerable<JObject> RunPagedQueryAsync(GitHubClient client, string queryText, string repoName, CancellationToken cancel, IProgress<int> progress)
        {
            JObject issues(JObject result) => (JObject)result["data"]["repository"]["issues"];
            JObject pageInfo(JObject result) => (JObject)issues(result)["pageInfo"];
            var issueAndPRQuery = new GraphQLRequest
            {
                Query = queryText
            };
            issueAndPRQuery.Variables["repo_name"] = repoName;
            bool hasMorePages = true;
            int pagesReturned = 0;
            int issuesReturned = 0;
            // Stop with 10 pages, because these are large repos:
            for (pagesReturned = 0; pagesReturned < 10; pagesReturned++)
            {
                var postBody = issueAndPRQuery.ToJsonText();
                var response = await client.Connection.Post<string>(new Uri("https://api.github.com/graphql"),
                    postBody, "application/json", "application/json");

                JObject results = JObject.Parse(response.HttpResponse.Body.ToString());

                int totalCount = (int)issues(results)["totalCount"];
                hasMorePages = (bool)pageInfo(results)["hasPreviousPage"];
                issueAndPRQuery.Variables["start_cursor"] = pageInfo(results)["startCursor"].ToString();
                issuesReturned += issues(results)["nodes"].Count();
                // <SnippetProcessPage>
                yield return results;
                progress?.Report(issuesReturned);
                cancel.ThrowIfCancellationRequested();
                // </SnippetProcessPage>
            }
        }
        // </SnippetRunPagedQuery>

        public string GetEnvVariable(string item, string error, string defaultValue)
        {
            var value = Environment.GetEnvironmentVariable(item);
            if (string.IsNullOrWhiteSpace(value))
            {
                if (!string.IsNullOrWhiteSpace(defaultValue))
                {
                    return defaultValue;
                }

                if (!string.IsNullOrWhiteSpace(error))
                {
                    Console.WriteLine(error);
                    Environment.Exit(0);
                }
            }
            return value;
        }
    }
}