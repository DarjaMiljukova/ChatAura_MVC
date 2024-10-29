using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatAura.Startup))]

namespace ChatAura
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Оставьте здесь только другие настройки, которые не относятся к регистрации маршрутов
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            // Настройте аутентификацию, если она нужна
        }
    }
}
