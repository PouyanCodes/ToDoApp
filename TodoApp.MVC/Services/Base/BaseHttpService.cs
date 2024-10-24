namespace TodoApp.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;

        public BaseHttpService(IClient client)
        {
            _client = client;
        }
    }
}
