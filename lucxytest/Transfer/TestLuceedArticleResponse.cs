using System.Text.Json.Serialization;

namespace Lucxy.LuceedArticle.Transfer;

public class TestLuceedArticleResponse
{
    public List<TestLuceedArticleResult>? Result { get; set; }
}

public class TestLuceedArticleResult
{
    public List<TestLuceedArticle>? Articles { get; set; }
}

public class TestLuceedArticle
{
    public int Id { get; init; }

    public string? Name { get; set; }
}
