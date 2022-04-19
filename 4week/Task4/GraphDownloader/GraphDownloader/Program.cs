// See https://aka.ms/new-console-template for more information
using GraphDownloader.Models;
using GraphDownloader.Services;
using Newtonsoft.Json.Linq;
using Octokit;

public static class Program
{
    private const string PagedIssueQuery = @"query ($repo_name: String!,  $start_cursor:String) {
                                              repository(owner: ""dotnet"", name: $repo_name) {
                                                issues(last: 25, before: $start_cursor)
                                                 {
                                                    totalCount
                                                    pageInfo {
                                                      hasPreviousPage
                                                      startCursor
                                                    }
                                                    nodes {
                                                      title
                                                      number
                                                      createdAt
                                                    }
                                                  }
                                                }
                                              }
                                            ";

    static async Task Main(string[] args)
    {
        //Follow these steps to create a GitHub Access Token
        // https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/#creating-a-token
        //Select the following permissions for your GitHub Access Token:
        // - repo:status
        // - public_repo
        // Replace the 3rd parameter to the following code with your GitHub access token.
        GraphsDownloader downloader = new GraphsDownloader();
        var key = downloader.GetEnvVariable("GitHubKey",
        "You must store your GitHub key in the 'GitHubKey' environment variable",
        "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");

        var client = new GitHubClient(new Octokit.ProductHeaderValue("IssueQueryDemo"))
        {
            Credentials = new Credentials(key)
        };

        // <SnippetEnumerateOldStyle>
        var progressReporter = new ProgressStatus((num) =>
        {
            Console.WriteLine($"Received {num} issues in total");
        });
        CancellationTokenSource cancellationSource = new CancellationTokenSource();

        try
        {
            var results = downloader.RunPagedQueryAsync(client, PagedIssueQuery, "docs",
                cancellationSource.Token, progressReporter);
            await foreach (var issue in results)
                Console.WriteLine(issue);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Work has been cancelled");
        }
        // </SnippetEnumerateOldStyle>
    }
    // </SnippetStarterAppMain>

    // <SnippetRunPagedQuery>
 
}