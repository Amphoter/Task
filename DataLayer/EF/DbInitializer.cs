
namespace DataLayer.EF
{
   public static  class DbInitializer
    {

                
        public static void Initialize(ApplicationContext db)
        {
            db.Database.EnsureCreated();
            
                
            
        }
    }
}
