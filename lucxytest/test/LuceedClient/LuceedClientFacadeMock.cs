using Lucxy.LuceedClient;

namespace lucxytest.LuceedClient;

public class LuceedClientFacadeMock : ILuceedClientFacade
{
    public Task<string> Get(string uri)
    {
        string startupPath = System.IO.Directory.GetCurrentDirectory();
        DirectoryInfo? projectDirectory = Directory.GetParent(startupPath)?.Parent?.Parent;
        if (projectDirectory is null) {
            throw new Exception();
        }
        String projectDirectoryPath = projectDirectory.FullName;

        if (uri.Equals("artikli/naziv/pri/[0,10]")) {
            return Task.FromResult(File.ReadAllText(projectDirectoryPath + "/Data/LuceedArticle/LuceedArticleResponse.json"));
        }
        if (uri.Equals("mpobracun/artikli/132/01.01.1999/01.01.2024")) {
            return Task.FromResult(File.ReadAllText(projectDirectoryPath + "/Data/LuceedTransaction/LuceedTransactionArticleResponse.json"));
        }
        if (uri.Equals("mpobracun/placanja/132/01.01.1999/01.01.2024")) {
            return Task.FromResult(File.ReadAllText(projectDirectoryPath + "/Data/LuceedTransaction/LuceedTransactionPaymentResponse.json"));
        }

        throw new NotImplementedException();
    }
}
