using GraphQL.Data;
using GraphQL.Speakers;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace GraphQL;

public class Mutation
{
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        [Service] ApplicationDbContext context)
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

    public async Task<RemoveSpeakerPayload> RemoveSpeakerAsync(
        RemoveSpeakerInput input,
        [Service] ApplicationDbContext context)
    {
        var speaker = await context.Speakers.FirstOrDefaultAsync(s => s.Id == input.Id);

        context.Speakers.Remove(speaker);
        await context.SaveChangesAsync();

        return new RemoveSpeakerPayload(input.Id);
    } 
}