using System;
using System.IO;
using Bender.Configuration;

namespace WebApi.Bender
{
    public class BenderJsonFormatter : BenderFormatter
    {
        public BenderJsonFormatter(Options options) :
            base(options, "application/json") { }

        protected override void Serialize(object value, Stream writeStream, Options options)
        {
            global::Bender.Serialize.JsonStream(value, writeStream, options);
        }

        protected override object Deserialize(Stream readStream, Type type, Options options)
        {
            return global::Bender.Deserialize.Json(readStream, type, options);
        }
    }
}
