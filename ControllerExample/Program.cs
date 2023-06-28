namespace ControllerExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers(); //adds all controller classes as services
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //enables routing for each action method
            });

            //or directly call endpoints.MapControllers() without calling .UseRouting and .UseEndpoints

            app.Run();
        }
    }
}