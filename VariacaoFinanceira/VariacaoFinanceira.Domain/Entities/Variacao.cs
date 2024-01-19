namespace VariacaoFinanceira.Domain.Entities;

public class Variacao
{
    public Variacao(DateTime cL_DATE, double cL_VALUE, double cL_VARIATION_PREVIOUS_DATE, double cL_VARIATION_FIRST_DATE)
    {
        CL_DATE = cL_DATE;
        CL_VALUE = cL_VALUE;
        CL_VARIATION_PREVIOUS_DATE = cL_VARIATION_PREVIOUS_DATE;
        CL_VARIATION_FIRST_DATE = cL_VARIATION_FIRST_DATE;
    }

    public int ID { get; set; }
    public DateTime CL_DATE { get; set; }
    public double CL_VALUE { get; set; }
    public double CL_VARIATION_PREVIOUS_DATE { get; set; }
    public double CL_VARIATION_FIRST_DATE { get; set; }
    
}
