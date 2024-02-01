using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace AccessManager.Sso.Attributes.FromClaimAttribute
{
    public class ClaimValueProvider : BindingSourceValueProvider
    {
        private IEnumerable<Claim> Claims { get; }

        public ClaimValueProvider(BindingSource bindingSource, IEnumerable<Claim> claims) : base(bindingSource)
        {
            Claims = claims;
        }

        public override bool ContainsPrefix(string prefix)
        {
            var isContains = Claims.Any(i => i.Type == prefix);

            return isContains;
        }

        public override ValueProviderResult GetValue(string key)
        {
            var result = Claims.Any(i => i.Type == key)
                ? new ValueProviderResult(Claims.Single(i => i.Type == key).Value)
                : ValueProviderResult.None;

            return result;
        }
    }
}
