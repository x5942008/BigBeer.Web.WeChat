using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;

namespace weixin.mp.wujixiong.com.Controllers
{
    public class WeixinController : Controller
    {
        IConfiguration Config { get; }
        string Token { get { return Config["weixin_mp_token"]; }}
        string AesKey { get { return Config["weixin_mp_aeskey"]; } }
        string AppId { get { return Config["weixin_mp_appid"]; } }
        public WeixinController(IConfiguration configuration)
        {
            Config = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 微信验证网站是否可访问,GET请求
        /// </summary>
        /// <param name="model"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Message(PostModel model,string echostr)
        {
            if(CheckSignature.Check(model.Signature,model.Timestamp,model.Nonce,Token))
            return Content(echostr);
            else
            return Content("并非微信官方请求");
        }
    }
}