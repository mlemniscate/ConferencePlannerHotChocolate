using GraphQL.Data;
using GraphQL.Extensions;
using GraphQL.Speakers;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace GraphQL;

public class Mutation
{
    [UseApplicationDbContext]
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        [ScopedService] ApplicationDbContext context)
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.WebSite
        };

        context.Speakers.Add(speaker);
        await context.SaveChangesAsync();

        return new AddSpeakerPayload(speaker);
    }

    [UseApplicationDbContext]
    public async Task<RemoveSpeakerPayload> RemoveSpeakerAsync(
        RemoveSpeakerInput input,
        [ScopedService] ApplicationDbContext context)
    {
        var speaker = await context.Speakers.FirstOrDefaultAsync(s => s.Id == input.Id);

        context.Speakers.Remove(speaker);
        await context.SaveChangesAsync();

        return new RemoveSpeakerPayload(input.Id);
    } 
}