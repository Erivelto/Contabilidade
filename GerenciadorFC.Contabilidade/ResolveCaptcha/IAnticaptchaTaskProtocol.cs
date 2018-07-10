using Newtonsoft.Json.Linq;

namespace ResolveCaptcha
{
    public interface IAnticaptchaTaskProtocol
    {
        JObject GetPostData();
        string GetTaskSolution();
    }
}