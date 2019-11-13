using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T1808A_MVC.Models;
using T1808A_MVC.Service;

namespace T1808A_MVC.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _memberService;
        public MemberController()
        {
            _memberService = new InMemoryMemberService();
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Save(string username, string password, string fullname)
        {
            Member member = new Member()
            {
                Username = username,
                Password = password,
                FullName = fullname
            };
            _memberService.Store(member);
            ViewBag.member = member;
            return View();
        }

        public ActionResult Index()
        {
            ViewData["members"] = _memberService.GetList(1, 10);
            return View();
        }
    }
}