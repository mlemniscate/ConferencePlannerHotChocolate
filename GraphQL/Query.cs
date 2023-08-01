using GraphQL.Data;
using GraphQL.Extensions;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace GraphQL;

public class Query
{
    [UseApplicationDbContext]
    public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
        context.Speakers.ToListAsync();

    [UseApplicationDbContext]
    public Task<Speaker?> GetSpeaker(int id, [ScopedService] ApplicationDbContext context) =>
        context.Speakers.FirstOrDefaultAsync(s => s.Id == id);
}