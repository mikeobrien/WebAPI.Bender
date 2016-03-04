using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using Bender.Configuration;

namespace WebApi.Bender
{
    public static class Extensions
    {
        public static void UseBender(
            this HttpConfiguration config, 
            Action<OptionsDsl> configure)
        {
            config.UseBender(configure.Configure());
        }

        public static void UseBenderForXml(
            this HttpConfiguration config,
            Action<OptionsDsl> configure)
        {
            config.UseBenderForXml(configure.Configure());
        }

        public static void UseBenderForJson(
            this HttpConfiguration config,
            Action<OptionsDsl> configure)
        {
            config.UseBenderForJson(configure.Configure());
        }

        private static Options Configure(
            this Action<OptionsDsl> configure)
        {
            var options = new Options();
            configure?.Invoke(new OptionsDsl(options));
            return options;
        }

        public static void UseBender(
            this HttpConfiguration config, 
            Options options = null)
        {
            config.UseBenderForJson(options);
            config.UseBenderForXml(options);
        }

        public static void UseBenderForXml(
            this HttpConfiguration config,
            Options options = null)
        {
            config.PrependFormatter(new BenderXmlFormatter(
                options ?? new Options()));
        }

        public static void UseBenderForJson(
            this HttpConfiguration config,
            Options options = null)
        {
            config.PrependFormatter(new BenderJsonFormatter(
                options ?? new Options()));
        }

        private static void PrependFormatter(
            this HttpConfiguration config, 
            MediaTypeFormatter formatter)
        {
            config.Formatters.Insert(0, formatter);
        }
    }
}
