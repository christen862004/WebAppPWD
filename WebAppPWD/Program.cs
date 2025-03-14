namespace WebAppPWD
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });


            var app = builder.Build();
            # region inline Midelware "Cutom With no name"
            //app.Use(async (httpContext, next) => {
            //   await  httpContext.Response.WriteAsync("1) Middleware 1\n");
            //   await next.Invoke();
            //   await httpContext.Response.WriteAsync("1-1) Middleware 1\n");

            //});
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("2) Middleware 2\n");
            //    await next.Invoke();//<---
            //    await httpContext.Response.WriteAsync("2-2) Middleware 2\n");

            //});
            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3) Terminate\n");

            //});
            #endregion
            #region Configure the HTTP request pipeline. Day3 Middlewares
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");//handel any request
            }
            //css/jqyer/jquery.js
            
            app.UseStaticFiles();//take requet extension change default setting
            //employee/index
            app.UseRouting();//send action contoll
            
            app.UseSession();//<---open session |write |read |close session |Generate id unique

            app.UseAuthorization();//prmision for remember

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();//application start
        }
    }
}
