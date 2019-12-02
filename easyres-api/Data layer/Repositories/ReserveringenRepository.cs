using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_layer.Repositories
{
    public class ReserveringenRepository : IReserveringenRepository
    {
        private readonly DatabaseContext _context;

        public ReserveringenRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public List<Reservatie> GetReserveringen(string userid)
        {
            IQueryable<Reservatie> reservaties = _context.Reservaties.Include(a => a.Restaurant);
            if (!string.IsNullOrEmpty(userid))
                reservaties = reservaties.Where(b => b.UserId == userid);
            return reservaties.ToList();
        }
        public Reservatie GetReservatie(long id)
        {
            return _context.Reservaties.Where(a => a.ReservatieId == id)
                                        .FirstOrDefault();
        }
        public Reservatie DeleteReservatie(long id, string user = "gebruiker")
        {
            var reservatie = _context.Reservaties.Where(a => a.ReservatieId == id)
                                                .Include(a => a.Restaurant)
                                                .FirstOrDefault();
            try
            {
                _context.Reservaties.Remove(reservatie);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            return reservatie;
        }
    }
}
