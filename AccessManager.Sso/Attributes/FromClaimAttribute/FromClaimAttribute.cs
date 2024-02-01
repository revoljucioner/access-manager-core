using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AccessManager.Sso.Attributes.FromClaimAttribute
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromClaimAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
    {
        public FromClaimAttribute(string name)
        {
            Name = name;
        }

        public BindingSource BindingSource => ClaimBindingSource.Instance;

        public string Name { get; set; }
    }
}
