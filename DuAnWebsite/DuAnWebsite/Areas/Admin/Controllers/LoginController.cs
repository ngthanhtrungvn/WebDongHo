using DuAnWebsite.Areas.Admin.Models;
using DuAnWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DuAnWebsite.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        IEnumerable<ACCOUNT> lstACC;
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
           return View();
        }
        [HttpPost]
        public JsonResult Login(string user, string pass)
        {
            HttpResponseMessage respon = Global.WebAPIClient.GetAsync("ACCOUNTs").Result;
            lstACC = respon.Content.ReadAsAsync<IEnumerable<ACCOUNT>>().Result.ToList();
            ACCOUNT acc = lstACC.Where(a => a.USERNAME.Equals(user) && 
                                       a.passwordd.Equals(pass))
                                       .FirstOrDefault();
            if (acc != null)
            {
                SessionHelper.Instances.setSession(acc);
                return Json(new
                {
                    status = true,
                    message = "Đăng nhập thành công."
                });
            }
            return Json(new
            {
                status = false,
                message = "Sai tên tài khoản hoặc mật khẩu."
            });
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(ACCOUNT acc)
        {
            try
            {
                if (lstACC.Where(x => x.USERNAME.Equals(acc.USERNAME)) != null)
                    return Json(0);
                if (lstACC.Where(x => x.Email.Equals(acc.Email)) != null)
                    return Json(2);
                #region mã xác nhận email
                Session["code"] = SessionHelper.Instances.randCode();
                string body = @"<!DOCTYPE html>
<html lang='en'>

<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Document</title>
    <style>
        * {
            padding: 0;
            margin: 0;
            box-sizing: border-box;
        }

        body {
            padding: 16px;
        }

        .body {
            border: 1px solid #ccc;
            width: 100%;
            margin: auto;
        }

        .code {
            text-align: center;
            margin: 0 auto;
            background: rgb(35, 189, 137);
            border-radius: 50px;
            font-size: 1.5rem;
            line-height: 2rem;
            color: white;
            min-width: 150px;
            max-width: 200px;
        }

        .code_text {
            margin: auto;
            min-width: 150px;
            max-width: 200px;
            text-align: center;
            font-size: 1.5rem;
            line-height: 2rem;
        }

        .header {
            text-align: center;
            text-transform: uppercase;
            background: #00BBA6;
            color: white;
            padding: 4px;
        }

        .header h1 {
            line-height: 2.5rem;

        }

        .header h4 {

            line-height: 2rem;
        }

        footer {
            margin-top: 12px;
            text-align: center;
            text-transform: uppercase;
            background: #00BBA6;
            color: white;
            padding: 4px;

        }

        p {
            line-height: 2rem;
            padding: 0 8px;
        }
    </style>
</head>

<body>
    <div class='body'>
        <div class='header'>
            <h1>Công ty PatekPhilip</h1>
            <h4>Xác thực tài khoản " + acc.USERNAME + @"</h4>
        </div>
        <p>Chào bạn " + acc.LASTNAME + " " + acc.FIRSTNAME + @",</p>
        <p>Đây là mã xác nhận kích hoạt tài khoản của bạn. Vui lòng không cung cấp cho người khác.</p>
        <h4 class='code_text'>Mã xác nhận</h4>
        <div class='code'>
            <span>" + Session["code"] + @"</span>
        </div>

        <p>Nếu không phải bạn? Vui lòng bỏ qua email này.</p>
        <p>Đã có tài khoản?<a href='https://xnxx.com'>Đăng nhập tại đây</a></p>

        <p>Xin cảm ơn,</p>
        <p>trungthanh200156@gmail.com</p>
        <footer class='footer'>
            <p>Cảm ơn bạn đã đăng kí tài khoản trên <a href='https://xnxx.com'>xnxx</a></p>
        </footer>
    </div>
</body>

</html>";
                #endregion
                if (SessionHelper.Instances.sendMail("Kích hoạt tài khoản", acc.Email, body))
                {
                    Session["acc"] = acc;
                    return Json(1);
                }
            }
            catch (Exception ex)
            {
            }
            return Json(-1);

        }
    }
}