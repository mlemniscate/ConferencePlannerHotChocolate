using GraphQL.Data;

namespace GraphQL.Speakers;

public class AddSpeakerPayload
{
    public AddSpeakerPayload(Speaker speaker)
    {
        Speaker = speaker;
    }

    public Speaker Speaker { get; set; }
}

