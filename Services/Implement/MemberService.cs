using BusinessObjects;
using DataAccessObjects;
using Services.DTO;
using Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(MemberDto memberDto)
        {
            var member = new Member
            {
                Email = memberDto.Email,
                CompanyName = memberDto.CompanyName,
                City = memberDto.City,
                Country = memberDto.Country,
                Password = memberDto.Password,
                IsActive = memberDto.IsActive
            };

            _unitOfWork.Members.Add(member);
            _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            var member = _unitOfWork.Members.GetById(id);
            if (member != null)
            {
                _unitOfWork.Members.Delete(member);
                _unitOfWork.Save();
            }
        }

        public async Task<IEnumerable<MemberDto>> GetAllAsync()
        {
            var members = _unitOfWork.Members.GetAll();
            return members.Select(m => new MemberDto
            {
                MemberId = m.MemberId,
                Email = m.Email,
                CompanyName = m.CompanyName,
                City = m.City,
                Country = m.Country,
                Password = m.Password,
                IsActive = m.IsActive
            });
        }

        public async Task<MemberDto?> GetByIdAsync(int id)
        {
            var member = _unitOfWork.Members.GetById(id);
            if (member == null) return null;

            return new MemberDto
            {
                MemberId = member.MemberId,
                Email = member.Email,
                CompanyName = member.CompanyName,
                City = member.City,
                Country = member.Country,
                Password = member.Password,
                IsActive = member.IsActive
            };
        }

        public async Task UpdateAsync(MemberDto memberDto)
        {
            var existing = _unitOfWork.Members.GetById(memberDto.MemberId);
            if (existing == null) return;

            existing.Email = memberDto.Email;
            existing.CompanyName = memberDto.CompanyName;
            existing.City = memberDto.City;
            existing.Country = memberDto.Country;
            existing.Password = memberDto.Password;
            existing.IsActive = memberDto.IsActive;

            _unitOfWork.Members.Update(existing);
            _unitOfWork.Save();
        }
    }
}
