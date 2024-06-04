using Domain.User;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using System;

namespace Logic.Services.Decorators
{
    public class TicketServiceDecorator : ITicketService
    {
        private readonly ITicketService _innerTicketService;
        private readonly IAdminService _adminService;

        public TicketServiceDecorator(ITicketService innerTicketService, IAdminService adminService)
        {
            _innerTicketService = innerTicketService ?? throw new ArgumentNullException(nameof(innerTicketService));
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        public bool Buy(Ticket ticket)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerTicketService.Buy(ticket);
        }

        public List<Ticket> ListByUser(int userID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerTicketService.ListByUser(userID);
        }

        public void Generate(Ticket ticket)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            _innerTicketService.Generate(ticket);
        }

        public bool Remove(int ticketID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerTicketService.Remove(ticketID);
        }

        public int Add(Ticket ticket)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerTicketService.Add(ticket);
        }

        public bool ChangeDetails(int ticketID, Ticket newTicket)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerTicketService.ChangeDetails(ticketID, newTicket);
        }

        public Ticket GetTicketByID(int ticketID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerTicketService.GetTicketByID(ticketID);
        }

        public double GetPrice(int ticketID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerTicketService.GetPrice(ticketID);
        }

        private bool CheckCondition()
        {
            return !_adminService.IsTechnicalBreak();
        }
    }
}
