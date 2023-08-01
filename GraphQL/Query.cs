using GraphQL.Data;
using HotChocolate;

namespace GraphQL;

public class Query
{
    public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context) =>
        context.Speakers;

    public IQueryable<Speaker> GetSpeaker(int id, [Service] ApplicationDbContext context) =>
        context.Speakers.Where(s => s.Id == id);
}