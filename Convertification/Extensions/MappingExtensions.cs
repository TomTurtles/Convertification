namespace Convertification;

public static class MappingExtensions
{
    /// <summary>
    /// Creates a new object of type <typeparamref name="TDestination"/> 
    /// </summary>
    /// <typeparam name="TDestination"></typeparam>
    /// <param name="source"></param>
    /// <param name="configureMapping"></param>
    /// <returns></returns>
    public static TDestination Map<TSource, TDestination>(this TSource source, Action<TSource, TDestination> configureMapping)
     where TDestination : new()
    {
        var destination = source.Map<TSource, TDestination>();
        configureMapping(source, destination);
        return destination;
    }

    /// <summary>
    /// Creates a new object of type <typeparamref name="TDestination"/> 
    /// </summary>
    /// <typeparam name="TDestination"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static TDestination Map<TSource, TDestination>(this TSource source)
        where TDestination : new()
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        // Neues Ziel-Objekt erstellen
        TDestination destination = new TDestination();

        // Properties beider Typen ermitteln
        var sourceProperties = typeof(TSource).GetProperties();
        var destProperties = typeof(TDestination).GetProperties();

        // Properties mit gleichem Namen und Typ werden kopiert
        source.DoPropertyMapping(destination, sourceProperties, destProperties);

        return destination;
    }

    /// <summary>
    /// Uses the instance of the destination object of type <typeparamref name="TDestination"/> and overrides the fitting properties
    /// </summary>
    /// <typeparam name="TDestination"></typeparam>
    /// <param name="destination"></param>
    /// <param name="source"></param>
    /// <param name="configureMapping"></param>
    public static void MapFrom<TSource, TDestination>(this TDestination destination, TSource source, Action<TSource, TDestination> configureMapping)
     where TDestination : new()
    {
        destination.MapFrom(source);
        configureMapping(source, destination);
    }

    /// <summary>
    /// Uses the instance of the destination object of type <typeparamref name="TDestination"/> and overrides the fitting properties
    /// </summary>
    /// <typeparam name="TDestination"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static void MapFrom<TSource, TDestination>(this TDestination destination, TSource source)
        where TDestination : new()
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        // Properties beider Typen ermitteln
        var sourceProperties = typeof(TSource).GetProperties();
        var destProperties = typeof(TDestination).GetProperties();

        // Properties mit gleichem Namen und Typ werden kopiert
        source.DoPropertyMapping(destination, sourceProperties, destProperties);
    }

    private static void DoPropertyMapping<TSource, TDestination>(this TSource source, TDestination destination, PropertyInfo[] sourceProperties, PropertyInfo[] destinationProperties)
    { // Properties mit gleichem Namen und Typ werden kopiert
        foreach (var sourceProperty in sourceProperties)
        {
            var destProperty = destinationProperties
                .FirstOrDefault(dp => dp.Name.Equals(sourceProperty.Name) && dp.PropertyType.Equals(sourceProperty.PropertyType));

            if (destProperty != null && destProperty.CanWrite)
            {
                var value = sourceProperty.GetValue(source);
                destProperty.SetValue(destination, value);
            }
        }
    }
}