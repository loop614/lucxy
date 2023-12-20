namespace Lucxy.LucxyCore.Model;

public class LuceedRequestResponseCache
{
    public long id { get; set;}
    public String request { get; set; } = String.Empty;
    public String response { get; set; } = String.Empty;
    public DateTime createdAt { get; set; }
}
