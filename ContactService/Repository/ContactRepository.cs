using ContactService.Dtos;
using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> CreateAsync(Contact contactModel)
        {
            await _context.Contacts.AddAsync(contactModel);
            await _context.SaveChangesAsync();
            return contactModel;
        }

        public async Task<Contact?> DeleteAsync(int id)
        {
            var contactModel = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);

            if (contactModel == null)
            {
                return null;
            }

            _context.Contacts.Remove(contactModel);
            await _context.SaveChangesAsync();
            return contactModel;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _context.Contacts.Include(c => c.Category)
                                        .Include(c => c.Subcategory)
                                        .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> ContactExists(int id)
        {
            return _context.Contacts.AnyAsync(c => c.Id == id);
        }

        public async Task<Contact?> UpdateAsync(int id, UpdateContactDto contactDto)
        {
            var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);

            if (existingContact == null)
            {
                return null;
            }

            existingContact.FirstName = contactDto.FirstName;
            existingContact.LastName = contactDto.LastName;
            existingContact.Email = contactDto.Email;
            existingContact.Password = contactDto.Password;
            existingContact.Category = contactDto.Category;
            existingContact.Subcategory = contactDto.Subcategory;
            existingContact.PhoneNumber = contactDto.PhoneNumber;
            existingContact.BirthDate = contactDto.BirthDate;

            await _context.SaveChangesAsync();

            return existingContact;
        }
    }
}