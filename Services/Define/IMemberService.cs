using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Define
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAllAsync();
        Task<MemberDto?> GetByIdAsync(int id);
        Task AddAsync(MemberDto memberDto);
        Task UpdateAsync(MemberDto memberDto);
        Task DeleteAsync(int id);
    }

}
