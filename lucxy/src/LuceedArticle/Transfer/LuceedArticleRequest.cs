namespace Lucxy.LuceedArticle.Transfer;

public class LuceedArticleRequest
{
    public string Name { get; set; }

    public int From { get; set; }

    public int To { get; set; }

    public LuceedArticleRequest(string name, int from, int to) {
        Name = name;
        From = from;
        To = to;
    }
}
