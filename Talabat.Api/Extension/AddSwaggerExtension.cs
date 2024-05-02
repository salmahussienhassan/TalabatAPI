﻿namespace Talabat.Api.Extension
{
    public static class AddSwaggerExtension
    {
        public static WebApplication UseSwaggerMiddleware(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
