namespace Homework3.Methods;

public static class DrinkVariant
{
    public static string GetDrink(string occupation)
    {
        return occupation.Trim().ToLowerInvariant() switch
        {
            "jabroni" => "Patron Tequila",
            "school counselor" => "Anything with Alcohol",
            "programmer" => "Hipster Craft Beer",
            "bike gang member" => "Moonshine",
            "politician" => "Your tax dollars",
            "rapper" => "Cristal",
            _ => "Beer"
        };
    }
}