using ContactService.Dtos;
using ContactService.Models;

namespace ContactService.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task<Contact> CreateAsync(Contact contactModel);
        Task<Contact?> UpdateAsync(int id, UpdateContactDto contactDto);
        Task<Contact?> DeleteAsync(int id);
        Task<bool> ContactExists(int id);
    }
}