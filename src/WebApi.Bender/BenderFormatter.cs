using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Bender.Configuration;

namespace WebApi.Bender
{
    public abstract class BenderFormatter : BufferedMediaTypeFormatter
    {
        private readonly Options _options;

        protected BenderFormatter(Options options, string mediaType)
        {
            _options = options;
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
        }

        protected abstract void Serialize(object value, Stream writeStream, Options options);
        protected abstract object Deserialize(Stream readStream, Type type, Options options);

        public override bool CanReadType(Type type)
        {
            return type.IsClass || type.IsInterface;
        }

        public override bool CanWriteType(Type type)
        {
            return CanReadType(type);
        }

        public override void WriteToStream(Type type, object value, 
            Stream writeStream, HttpContent content)
        {
            Serialize(value, writeStream, _options);
        }

        public override object ReadFromStream(Type type, Stream readStream, 
            HttpContent content, IFormatterLogger formatterLogger)
        {
            return Deserialize(readStream, type, _options);
        }
    }
}