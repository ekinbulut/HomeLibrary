using Library.Mvc.Base;

namespace Library.Mvc
{
    public static class Registeration
    {
        public static void RegisterBase()
        {
            var svc = new ServiceRegisterar();

            svc.RegisterServices();
        }
    }
}
