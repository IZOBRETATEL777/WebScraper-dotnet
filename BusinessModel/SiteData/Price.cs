namespace BusinessModel.SiteData;

public class Price
{
    public Decimal? Value { get; set; }
    public String? Currency { get; set; }

    public Price(Decimal? value, String? currency)
    {
        this.Value = value;
        this.Currency = currency;
    }

    public Price()
    {
        
    }

    public override string ToString()
    {
       return $"{this.Value} {this.Currency}";
    }
}
