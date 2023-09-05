# Retrievers

Permettent la convertion entre type passe et donnee a recuperer

## Exemple

```c#
internal class ClothesSizeRetriever : IValueRetriever
{
    public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
    {
        return propertyType == typeof(InternalSize);
    }

    public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
    {
        return keyValuePair.Value switch
        {
            "XXL" => new InternalSize { InternalName = "ExtraExtraLarge", Width = "240cm", Height = "240cm" },
            "L" => new InternalSize { InternalName = "Large", Width = "200cm", Height = "200cm" },
            "S" => new InternalSize { InternalName = "Small", Width = "140cm", Height = "140cm" },
            _ => throw new InvalidDataException($"{keyValuePair.Value} : {keyValuePair.Value}")
        };
    }
}
```

Utilisation

```c#
[BeforeTestRun(Order = 1)]
public static void BeforeTestRunManager()
{
    Service.Instance.ValueRetrievers.Register<ClothesSizeRetriever>();
}
```
