namespace BusinessModel.Enum;

public static class StoresNames
{
    public static string GetShortName(this StoresEnum storesEnum)
    {
        switch (storesEnum)
        {
            case StoresEnum.Amazon:
                return "amazon";
            case StoresEnum.Trendyol:
                return "trendyol";
            case StoresEnum.Tapaz:
                return "tapaz";
            default:
                return "";
        }
    }

    public static string GetFullName(this StoresEnum storesEnum)
    {
        switch (storesEnum)
        {
            case StoresEnum.Amazon:
                return "Amazon";
            case StoresEnum.Trendyol:
                return "Trendyol";
            case StoresEnum.Tapaz:
                return "Tap.az";
            default:
                return "";
        }
    }

    public static string GetShortName (string fullName)
    {
        switch (fullName)
        {
            case "Amazon":
                return "amazon";
            case "Trendyol":
                return "trendyol";
            case "Tap.az":
                return "tapaz";
            default:
                return "";
        }
    }

    public static string GetFullName(string shortName) 
    {
        switch (shortName)
        {
            case "amazon":
                return "Amazon";
            case "trendyol":
                return "Trendyol";
            case "tapaz":
                return "Tap.az";
            default:
                return "";
        }
    }
}