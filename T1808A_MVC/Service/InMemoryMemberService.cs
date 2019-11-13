using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Member = T1808A_MVC.Models.Member;

namespace T1808A_MVC.Service
{
    public class InMemoryMemberService: IMemberService
    {
        private static List<Member> _members;

        public InMemoryMemberService()
        {
            if (_members == null)
            {
                _members = new List<Member>();
            }
        }

        public Member Store(Member member)
        {
            _members.Add(member);
            return member;
        }

        public List<Member> GetList(int page, int limit)
        {
            return _members;
        }

        public Member GetDetail(string username)
        {
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].Username.Equals(username))
                {
                    return _members[i];
                }
            }
            return null;
        }

        public Member Update(string username, Member member)
        {
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].Username.Equals(username))
                {
                    _members[i].Username = member.Username;
                    _members[i].Password = member.Password;
                    _members[i].FullName = member.FullName;
                    return _members[i];
                }
            }
            return null;
        }

        public bool Delete(string username)
        {
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].Username.Equals(username))
                {
                    _members.Remove(_members[i]);
                    return true;
                }
            }
            return false;
        }
    }
}