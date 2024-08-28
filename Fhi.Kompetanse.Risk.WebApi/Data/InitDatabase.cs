namespace Fhi.Kompetanse.Risk.WebApi.Data;

public class InitDatabase
{
    public static void Init(IServiceProvider serviceProvider)
    {

        using (var scope = serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<RiskContext>();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
