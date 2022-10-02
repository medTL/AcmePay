using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AcmePay.BL;

public static class ErrorsMapper
{
    public static IDictionary<string, string[]?> Map(ModelStateDictionary? modelState)
    {
        if (modelState != null && modelState.Any())
        {
            return modelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
            );
        }

        return new Dictionary<string, string[]?>();
    }
}