using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace Translator
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.ContentType = "text/plain; charset=utf-8";
                    if (context.Request.Query.ContainsKey("word"))
                    {
                        string word = context.Request.Query["word"].ToString().ToLower();
                        Translator dictionary = new Translator("Dictionary.txt");
                        string translation = dictionary.GetTranslation(word);
                        if (translation == null)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            await context.Response.WriteAsync("HTTP 404 Not Found");
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.OK;
                            await context.Response.WriteAsync($"Translation: {translation}");
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.Response.WriteAsync("HTTP 400 Bad Request");
                    }
                });
            });
        }
    }
}
