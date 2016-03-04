using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Bender;
using Bender.Configuration;

namespace WebApi.Bender
{
    public class BenderFormatter : BufferedMediaTypeFormatter
    {
        private readonly Options _options;

        public BenderFormatter(Options options)
        {
            _options = options;
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        public override bool CanReadType(Type type)
        {
            return true; //type.IsClass || type.IsInterface;
        }

        public override bool CanWriteType(Type type)
        {
            return true; //CanReadType(type);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            Serialize.JsonStream(value, writeStream, _options);
        }

        public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            return Deserialize.Json(readStream, type, _options);
        }

        public static void Enable(Action<OptionsDsl> configure)
        {
            Enable(GlobalConfiguration.Configuration, configure);
        }

        public static void Enable(HttpConfiguration config, Action<OptionsDsl> configure)
        {
            var options = new Options();
            configure?.Invoke(new OptionsDsl(options));
            Enable(config, options);
        }

        public static void Enable(Options options = null)
        {
            Enable(GlobalConfiguration.Configuration, options);
        }

        public static void Enable(HttpConfiguration config, Options options = null)
        {
            config.Formatters.Insert(0, new BenderFormatter(options ?? new Options()));
        }
    }
}
