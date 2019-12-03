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
        public List<Reservatie> GetReserveringen(string userid, string sortBy)
        {
            IQueryable<Reservatie> reservaties = _context.Reservaties.Include(a => a.Restaurant);
            if (!string.IsNullOrEmpty(userid))
                reservaties = reservaties.Where(b => b.UserId == userid)
                                         .Where(b => DateTime.ParseExact(b.Datum, "yyyy-MM-dd", null) >= DateTime.Now);
            if (string.IsNullOrEmpty(sortBy)) sortBy = "default";
            switch (sortBy.ToLower())
            {
                case "datum":
                    reservaties = reservaties.OrderBy(b => b.Datum);
                    break;
                case "restaurant":
                    reservaties = reservaties.OrderBy(b => b.Restaurant);
                    break;
                default:
                    reservaties = reservaties.OrderBy(b => b.Datum);
                    break;
            }
            return reservaties.ToList();
        }
        public List<Reservatie> GetPastReserveringen(string userid, string sortBy)
        {
            IQueryable<Reservatie> reservaties = _context.Reservaties.Include(a => a.Restaurant);
            if (!string.IsNullOrEmpty(userid))
                reservaties = reservaties.Where(b => b.UserId == userid)
                                         .Where(b => DateTime.ParseExact(b.Datum, "yyyy-MM-dd", null) < DateTime.Now);
            if (string.IsNullOrEmpty(sortBy)) sortBy = "default";
            switch (sortBy.ToLower())
            {
                case "datum":
                    reservaties = reservaties.OrderByDescending(b => b.Datum);
                    break;
                case "restaurant":
                    reservaties = reservaties.OrderBy(b => b.Restaurant);
                    break;
                default:
                    reservaties = reservaties.OrderByDescending(b => b.Datum);
                    break;
            }
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
