namespace ControlInventario.Datos.DTO;
public class DTOPageObjectResponse<T>
{
    public int Count { get; set; }
    public List<T> Entidades { get; set; } = new List<T>();
    
    public DTOPageObjectResponse()
    {
        this.Entidades = new List<T>(); 
    }

    public DTOPageObjectResponse(int count, List<T> list)
    {
        this.Count = count;
        this.Entidades = list;
    }
}