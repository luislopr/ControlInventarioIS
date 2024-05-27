namespace ControlInventario.Core.Helpers;

public class AppSettings
{
    public string Secret { get; set; } = string.Empty;
    public int Expiration { get; set; }
    public Roles Roles {  get; set; }
}

public class Roles
{
    public int Administrador { get; set; }
    public int Compras { get; set; }
    public int Ventas { get; set; }
}