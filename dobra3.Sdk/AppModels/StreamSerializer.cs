using System.Text.Json;
using dobra3.Shared.Utils;

namespace dobra3.Sdk.AppModels
{
    public class StreamSerializer : IAsyncSerializer<Stream>
    {
        private JsonSerializerOptions DefaultSerializerOptions { get; }
        
        public static StreamSerializer Instance { get; } = new();

        protected StreamSerializer()
        {
            DefaultSerializerOptions = new()
            {
                WriteIndented = true
            };
        }
        
        public virtual async Task<Stream> SerializeAsync(object? data, Type dataType, CancellationToken cancellationToken = default)
        {
            var outputStream = new MemoryStream();
            
            await JsonSerializer.SerializeAsync(outputStream, data, dataType, DefaultSerializerOptions, cancellationToken);
            outputStream.Position = 0;

            return outputStream;
        }
        
        public virtual async Task<object?> DeserializeAsync(Stream serialized, Type dataType, CancellationToken cancellationToken = default)
        {
            if (serialized.CanSeek)
                serialized.Position = 0L;

            var deserialized = await JsonSerializer.DeserializeAsync(serialized, dataType, DefaultSerializerOptions, cancellationToken);
            return deserialized;
        }
    }
}