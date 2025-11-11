namespace Aspire.Hosting.ApplicationModel;

/// <summary>
/// 
/// </summary>
public interface IOllamaResource : IResourceWithConnectionString, IResourceWithWaitSupport
{
    /// <summary>
    /// Adds a model to the list of models to download on initial startup.
    /// </summary>
    IReadOnlyList<string> Models { get; }

    /// <summary>
    /// Gets the endpoint for the Ollama server.
    /// </summary>
    EndpointReference PrimaryEndpoint { get; }
    
    /// <summary>
    /// Gets the host endpoint reference for this resource.
    /// </summary>
    EndpointReferenceExpression Host { get; }
    
    /// <summary>
    /// Gets the port endpoint reference for this resource.
    /// </summary>
    EndpointReferenceExpression Port { get; }
    
    /// <summary>
    /// Adds a model to the list of models to download on initial startup.
    /// </summary>
    /// <param name="modelName">The name of the model</param>
    void AddModel(string modelName);
}