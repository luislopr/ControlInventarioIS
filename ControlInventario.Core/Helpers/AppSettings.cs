namespace ControlInventario.Core.Helpers;

public class AppSettings
{
    public string Secret { get; set; } = string.Empty;
    public int Expiration { get; set; }
}