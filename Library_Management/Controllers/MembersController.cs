using Library_Management.Model;
using Library_Management.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        // Call repository
        private readonly IMemberRepository _repository;

        // DI Constructor Injection
        public MembersController(IMemberRepository repository)
        {
            _repository = repository;
        }

        #region 1- Get all members - search all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllMembers()
        {
            var members = await _repository.GetMembers();
            if (members == null)
            {
                return NotFound("No Members found");
            }

            return Ok(members);
        }
        #endregion

        #region 2- Get member by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMemberById(int id)
        {
            var member = await _repository.GetMemberById(id);
            if (member == null)
            {
                return NotFound("No Member found");
            }

            return Ok(member);
        }
        #endregion

        #region 3- Insert a member - Return member record
        [HttpPost]
        public async Task<ActionResult<Member>> InsertMember(Member member)
        {
            if (ModelState.IsValid)
            {
                var newMember = await _repository.AddMember(member);
                if (newMember != null)
                {
                    return Ok(newMember);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        #region 4- Update member - Return member record
        [HttpPut("{id}")]
        public async Task<ActionResult<Member>> UpdateMember(int id, Member member)
        {
            if (ModelState.IsValid)
            {
                var updatedMember = await _repository.UpdateMember(id, member);
                if (updatedMember != null)
                {
                    return Ok(updatedMember);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        #endregion

        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteMember(int id)
{
    try
    {
        var result = await _repository.DeleteMember(id);
        if (result.Value == null)
        {
            return NotFound(new { success = false, message = "Member could not be deleted or not found" });
        }
        return Ok(result.Value);
    }
    catch (Exception ex)
    {
        return StatusCode(StatusCodes.Status500InternalServerError,
            new { success = false, message = "An unexpected error occurred" });
    }
}

        //#region 5- Delete member
        //[HttpDelete("{id}")]
        //public IActionResult DeleteMember(int id)
        //{
        //    try
        //    {
        //        var result = _repository.DeleteMember(id);
        //        if (result == null)
        //        {
        //            return NotFound(new { success = false, message = "Member could not be deleted or not found" });
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            new { success = false, message = "An unexpected error occurred" });
        //    }
        //}
        //#endregion
    }
}
