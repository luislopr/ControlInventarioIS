namespace ControlInventario.WebApi.Models;
public class PageListRequestModel
{
    public PageListRequestModel()
    {
        this.CheckRequest();
    }

    public string? FilterValue { get; set; }
    public string? OrderBy { get; set; }
    public string? OrderOrientation { get; set; }
    public short Page { get; set; } = 0;
    public short Take { get; set; } = 20;

    public bool CheckRequest()
    {
        if (Take > 1000) Take = 1000;
        if (FilterValue == string.Empty) FilterValue = null;
        if (OrderBy == string.Empty) OrderBy = null;
        if (OrderOrientation == string.Empty) OrderOrientation = "ASC";

        return true;
    }
}

public class PageListRequestModelExtended : PageListRequestModel
{
    public bool Pending { get; set; } = true;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public new bool CheckRequest()
    {
        if (EndDate == null) EndDate = DateTime.Now;
        if (StartDate == null) StartDate = EndDate.Value.AddDays(-15);
        if (StartDate > EndDate) throw new InvalidOperationException("Rango de Fechas Invalido");
        if (StartDate > DateTime.Now) throw new InvalidOperationException("Rango de Fechas Invalido");
        return base.CheckRequest();
    }
}
