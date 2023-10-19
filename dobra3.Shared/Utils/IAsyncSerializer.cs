namespace dobra3.Shared.Utils
{
    public interface IAsyncSerializer<TSerialized>
    {
        Task<TSerialized> SerializeAsync(object? data, Type dataType, CancellationToken cancellationToken = default);

        Task<object?> DeserializeAsync(TSerialized serialized, Type dataType, CancellationToken cancellationToken = default);
    }
}