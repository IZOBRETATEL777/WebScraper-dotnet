namespace BusinessModel.SiteData;

// public class Price
// {
//     public Decimal? Value { get; set; }
//     public String? Currency { get; set; }

//     public Price(Decimal? value, String? currency)
//     {
//         this.Value = value;
//         this.Currency = currency;
//     }

//     public Price()
//     {
        
//     }

//     public override string ToString()
//     {
//        return $"{this.Value} {this.Currency}";
//     }
// }


// interface that is used to create Different prices
public interface IPrice
{
    
    Decimal? Value { get; set; }
    String? Currency { get; set; }

    // method to convert the currency to the common one - USD
    Double? getCommonPrice();

   
}

public class USD: IPrice
{
    public Decimal? Value { get; set; }
    public String? Currency { get; set; }

    // Constructor
    public USD(Decimal? value, String? currency )
    {
        Value = value;
        Currency = currency; 
    }

    // Convertor
    public Double? getCommonPrice()
    {
        int factor = 1;
        return Decimal.ToDouble(this.Value.Value) * factor;
    }

    public override string ToString()
    {
       return $"{this.Value} {this.Currency}";
    }
}

public class TRY: IPrice
{
    public Decimal? Value { get; set; }
    public String? Currency { get; set; }

    // Constructor
    public TRY(Decimal? value, String? currency )
    {
        Value = value;
        Currency = currency; 
    }

    // Convertor
    public Double? getCommonPrice()
    {
        double factor = 0.068;
        return Decimal.ToDouble(this.Value.Value) * factor;
    }

    public override string ToString()
    {
       return $"{this.Value} {this.Currency}";
    }
}

public class AZN: IPrice
{
    public Decimal? Value { get; set; }
    public String? Currency { get; set; }

    // Constructor
    public AZN(Decimal? value, String? currency )
    {
        Value = value;
        Currency = currency; 
    }

    // Convertor
    public Double? getCommonPrice()
    {
        double factor = 0.59;
        return Decimal.ToDouble(this.Value.Value) * factor;
    }

    public override string ToString()
    {
       return $"{this.Value} {this.Currency}";
    }
}

public class INR: IPrice
{
    public Decimal? Value { get; set; }
    public String? Currency { get; set; }

    // Constructor
    public INR(Decimal? value, String? currency )
    {
        Value = value;
        Currency = currency; 
    }
    
    // Convertor
    public Double? getCommonPrice()
    {
        double factor = 0.013;
        return Decimal.ToDouble(this.Value.Value) * factor;
    }

    public override string ToString()
    {
       return $"{this.Value} {this.Currency}";
    }
}

// Factory template that is used to create custom Price instances
public abstract class PriceFactory
{
    public abstract IPrice GetCurrency(Decimal? value, String currency);
}

// Factory
public class ConcretePriceFactory: PriceFactory
{
    
    // Method that defines the type of currency and creates relavant class
    public override IPrice GetCurrency(Decimal? value, String currency)
    {
        switch (currency)
        {
            case "INR":
                return new INR(value, currency);
            case "TL":
                return new TRY(value, currency);
            case "USD":
                return new USD(value, currency);
            case "AZN":
                return new AZN(value, currency);
            default:
                throw new ApplicationException(String.Format("Currency '{0}' does not exist", currency));
        }
    }
}

