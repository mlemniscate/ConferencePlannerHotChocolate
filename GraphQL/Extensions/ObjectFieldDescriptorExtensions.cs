﻿using Microsoft.EntityFrameworkCore;

namespace GraphQL.Extensions;

public static class ObjectFieldDescriptorExtensions
{
    public static IObjectFieldDescriptor UseDbContext<TDbContext>(
        this IObjectFieldDescriptor descriptor)
        where TDbContext : DbContext
    {
        return descriptor.UseScopedService<TDbContext>(
            create: s => s.GetService<IDbContextFactory<TDbContext>>()!.CreateDbContext(),
            disposeAsync: (s, c) => c.DisposeAsync());
    }
}