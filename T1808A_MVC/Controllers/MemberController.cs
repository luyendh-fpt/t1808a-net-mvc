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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            _memberService.Store(member);
            return Redirect("/Member");
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
            //ViewData["members"] = _memberService.GetList(1, 10);
            var members = _memberService.GetList(1, 10);
            return View("~/Views/Member/Index.cshtml", members);
        }

        public ActionResult Detail(string username)
        {
            var member = _memberService.GetDetail(username);
            if (member == null)
            {
                return View("~/Views/NotFound.cshtml");
            }
            return View(member);
        }
    }
}