using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task AddAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Email.Value == email);
        }

        public async Task<Customer?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.PhoneNumber.Value == phoneNumber);
        }

        public async Task<Customer?> GetWithAppointmentsAsync(Guid customerId)
        {
            return await _context.Customers
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
    }
}
