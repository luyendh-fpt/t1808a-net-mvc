using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T1808A_MVC.Models;

namespace T1808A_MVC.Service
{
    public class MySQLMemberService: IMemberService
    {
        public Member Store(Member member)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetList(int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Member GetDetail(string username)
        {
            throw new NotImplementedException();
        }

        public Member Update(string username, Member member)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string username)
        {
            throw new NotImplementedException();
        }
    }
}