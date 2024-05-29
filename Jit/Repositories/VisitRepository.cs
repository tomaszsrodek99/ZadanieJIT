using AutoMapper;
using Jit.Context;
using Jit.Interfaces;
using Jit.Dtos;
using Jit.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Jit.Repositories
{

    public class VisitRepository(MyDbContext context, IMapper mapper) : GenericRepository<Visit>(context), IVisitRepository
    {
        private readonly MyDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public bool VisitExists(DateTime date)
        {
            return _context.Visits.Any(x => x.Date.Hour == date.Hour);
        }

        public bool DateOfVisitValidator(DateTime value)
        {
            if ((value.DayOfWeek < DayOfWeek.Monday || value.DayOfWeek > DayOfWeek.Friday) || (value.Hour < 9 || value.Hour >= 17))
            {
                return false;
            }

            return true;
        }
    }
}
