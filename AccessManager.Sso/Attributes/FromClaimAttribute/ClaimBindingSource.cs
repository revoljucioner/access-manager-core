using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AccessManager.Sso.Attributes.FromClaimAttribute
{
    public static class ClaimBindingSource
    {
        public static readonly BindingSource Instance = new BindingSource(
            "Claim",
            "Claim",
            isGreedy: false,
            isFromRequest: true);
    }
}
