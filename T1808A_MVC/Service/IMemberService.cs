using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1808A_MVC.Models;

namespace T1808A_MVC.Service
{
    interface IMemberService
    {
        Member Store(Member member);
        List<Member> GetList(int page, int limit);
        Member GetDetail(string username);
        Member Update(string username, Member member);
        bool Delete(string username);

    }
}
