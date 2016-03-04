using System;
using System.IO;
using Bender.Configuration;

namespace WebApi.Bender
{
    public class BenderXmlFormatter : BenderFormatter
    {
        public BenderXmlFormatter(Options options) :
            base(options, "application/xml") { }

        protected override void Serialize(object value, Stream writeStream, Options options)
        {
            global::Bender.Serialize.XmlStream(value, writeStream, options);
        }

        protected override object Deserialize(Stream readStream, Type type, Options options)
        {
            return global::Bender.Deserialize.Xml(readStream, type, options);
        }
    }
}
