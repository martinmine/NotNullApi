using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections;

namespace NotNullApi;

public class NonNullableEnumerableValidator : IModelValidator
{
    public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
    {
        var results = new List<ModelValidationResult>();

        if (context.Model is IEnumerable enumerable)
        {
            int index = 0;
            foreach (var item in enumerable)
            {
                if (item == null)
                {
                    results.Add(new ModelValidationResult(
                        memberName: $"{context.ModelMetadata.Name}[{index}]",
                        message: "The collection contains a null value."));
                }
                index++;
            }
        }

        return results;
    }
}
