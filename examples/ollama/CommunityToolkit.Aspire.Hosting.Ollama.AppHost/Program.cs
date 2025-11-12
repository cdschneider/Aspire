using YamlDotNet.Core.Tokens;

var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder.AddOllama("ollama")
    .WithDataVolume()
    .WithOpenWebUI(UseSlimVariant);

var phi3 = ollama.AddModel("phi3", "phi3");
var llama = ollama.AddHuggingFaceModel("llama", "bartowski/Llama-3.2-1B-Instruct-GGUF:IQ4_XS");

var ollama2 = builder.AddOllama("ollama2")
    .WithDataVolume()
    .WithOpenWebUI(UseSlimVariant);

var tinyllama = ollama2.AddModel("tinyllama", "tinyllama");

builder.AddProject<Projects.CommunityToolkit_Aspire_Hosting_Ollama_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(phi3)
    .WaitFor(phi3)
    .WithReference(llama)
    .WithReference(tinyllama);

builder.Build().Run();

static void UseSlimVariant(IResourceBuilder<OpenWebUIResource> builder)
{
    if (builder.Resource.TryGetLastAnnotation(out ContainerImageAnnotation? imageAnnotation)
        && imageAnnotation is { Tag: not null } )
    {
        imageAnnotation.Tag += imageAnnotation.Tag.EndsWith("-slim") ? string.Empty : "-slim";
    }
}
