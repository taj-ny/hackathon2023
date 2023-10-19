using dobra3.Shared.Utils;

namespace dobra3.Shared.Extensions
{
    public static class SerializationExtensions
    {
        public static async Task<TDestination?> TryDeserializeAsync<TDestination, TSerialized>(this IAsyncSerializer<TSerialized> asyncSerializer, TSerialized serialized, CancellationToken cancellationToken = default)
        {
            try
            {
                return (TDestination?)await asyncSerializer.DeserializeAsync(serialized, typeof(TDestination), cancellationToken);
            }
            catch (Exception ex)
            {
                _ = ex;
                return default;
            }
        }
    }
}
