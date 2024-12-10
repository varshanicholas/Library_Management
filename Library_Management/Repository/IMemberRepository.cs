using Library_Management.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_Management.Repository
{
    public interface IMemberRepository
    {
        // 1- Get all members
        Task<ActionResult<IEnumerable<Member>>> GetMembers();

        // 2- Get a member by ID
        Task<ActionResult<Member>> GetMemberById(int id);

        // 3- Insert a new member and return the member record
        Task<ActionResult<Member>> AddMember(Member member);

        // 4- Update an existing member
        Task<ActionResult<Member>> UpdateMember(int id, Member member);

        // 5- Delete a member
        Task<JsonResult> DeleteMember(int id);
    }
}
