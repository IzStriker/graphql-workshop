using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.Extensions;

public static class ObjectFieldDescriptorExtensions
{
    public static IObjectFieldDescriptor UseDbContext<TDbContext>(
        this IObjectFieldDescriptor descriptor
    ) where TDbContext : DbContext
        => descriptor.UseScopedService<TDbContext>(
                create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext(),
                disposeAsync: (s, c) => c.DisposeAsync()
            );

}