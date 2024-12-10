using Library_Management.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_Management.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryManagementContext _context;

        public MemberRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        // 1- Get all members
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            try
            {
                if (_context != null)
                {
                    return await _context.Members.ToListAsync();
                }
                return new List<Member>();
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                return null;
            }
        }

        // 2- Get a member by ID
        public async Task<ActionResult<Member>> GetMemberById(int id)
        {
            try
            {
                if (_context != null)
                {
                    var member = await _context.Members.FindAsync(id);
                    return member;
                }
                return null;
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                return null;
            }
        }

        // 3- Insert a new member and return the member record
        public async Task<ActionResult<Member>> AddMember(Member member)
        {
            try
            {
                if (member == null)
                {
                    throw new ArgumentNullException(nameof(member), "Member data is null");
                }
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized");
                }

                await _context.Members.AddAsync(member);
                await _context.SaveChangesAsync();

                var addedMember = await _context.Members.FindAsync(member.MemberId);
                return addedMember;
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                return null;
            }
        }

        // 4- Update an existing member
        public async Task<ActionResult<Member>> UpdateMember(int id, Member member)
        {
            try
            {
                if (member == null)
                {
                    throw new ArgumentNullException(nameof(member), "Member data is null");
                }
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized");
                }

                var existingMember = await _context.Members.FindAsync(id);
                if (existingMember == null)
                {
                    return null;
                }

                existingMember.Name = member.Name;
                existingMember.Email = member.Email;
                existingMember.PhoneNumber = member.PhoneNumber;

                await _context.SaveChangesAsync();

                var updatedMember = await _context.Members.FindAsync(member.MemberId);
                return updatedMember;
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                return null;
            }
        }

        // 5- Delete a member
        public async Task<JsonResult> DeleteMember(int id)
        {
            try
            {
                if (_context == null)
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Database context is not initialized."
                    })
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                }

                var existingMember = await _context.Members.FindAsync(id);
                if (existingMember == null)
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Member not found."
                    })
                    {
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }

                _context.Members.Remove(existingMember);
                await _context.SaveChangesAsync();

                return new JsonResult(new
                {
                    success = true,
                    message = "Member deleted successfully."
                })
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                return new JsonResult(new
                {
                    success = false,
                    message = "An error occurred while deleting the member."
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
