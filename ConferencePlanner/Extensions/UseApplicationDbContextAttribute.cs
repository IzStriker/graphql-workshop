using System.Reflection;
using ConferencePlanner.Data;
using HotChocolate.Types.Descriptors;

namespace ConferencePlanner.Extensions;

public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
{
    protected override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member
    )
    {
        descriptor.UseDbContext<ApplicationDbContext>();
    }
}