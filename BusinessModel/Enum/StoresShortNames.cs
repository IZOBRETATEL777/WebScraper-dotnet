namespace BusinessModel.Enum;

public static class StoresShortNames
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
}