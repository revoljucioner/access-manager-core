using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AccessManager.Sso.Attributes.FromClaimAttribute
{
    public class ClaimValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            var claims = context.ActionContext.HttpContext.User.Claims;

            context.ValueProviders.Add(new ClaimValueProvider(ClaimBindingSource.Instance, claims));

            return Task.CompletedTask;
        }
    }
}
