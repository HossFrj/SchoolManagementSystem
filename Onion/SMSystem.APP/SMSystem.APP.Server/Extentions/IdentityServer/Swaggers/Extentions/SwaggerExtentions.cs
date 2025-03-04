using SMSystem.APP.Server.Extentions.DependencyInjection.Swaggers.Options;

namespace SMSystem.APP.Server.Extentions.IdentityServer.Swaggers.Extentions;

public static class SwaggerExtentions
{
    //public static void UseSwaggerUI(this WebApplication app, string sectionName)
    //{
    //    var swaggerOption = app.Configuration.GetSection(sectionName).Get<SwaggerOption>();

    //    if (swaggerOption != null && swaggerOption.SwaggerDoc != null && swaggerOption.Enabled == true)
    //    {
    //        app.UseSwagger();
    //        app.UseSwaggerUI(option =>
    //        {
    //            option.DocExpansion(DocExpansion.None);
    //            option.SwaggerEndpoint(swaggerOption.SwaggerDoc.URL, swaggerOption.SwaggerDoc.Title);
    //            option.RoutePrefix = string.Empty;
    //            option.OAuthUsePkce();
    //        });
    //    }
    //}
}
