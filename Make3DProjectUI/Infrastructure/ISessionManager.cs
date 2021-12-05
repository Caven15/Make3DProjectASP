using Make3DProjectBLL.Models;

namespace Make3DProjectUI.Infrastructure
{
    public interface ISessionManager
    {
        UserConnectedModel CurrentUser { get; set; }

        void ClearUser();
    }
}