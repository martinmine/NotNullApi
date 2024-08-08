using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections;

namespace NotNullApi;

public class NonNullableEnumerableValidatorProvider : IModelValidatorProvider
{
    public void CreateValidators(ModelValidatorProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.ModelMetadata.ModelType != typeof(string) &&
            typeof(IEnumerable).IsAssignableFrom(context.ModelMetadata.ModelType) &&
            context.ModelMetadata.ElementMetadata?.ModelType != null &&
            !context.ModelMetadata.ElementMetadata.ModelType.IsValueType)
        {
            context.Results.Add(new ValidatorItem
            {
                Validator = new NonNullableEnumerableValidator(),
                IsReusable = true
            });
        }
    }
}
