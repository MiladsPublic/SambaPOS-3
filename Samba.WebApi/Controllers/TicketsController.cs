using Microsoft.AspNetCore.Mvc;
using Samba.WebApi.DTOs;

namespace Samba.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(ILogger<TicketsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetAllTickets()
        {
            try
            {
                // TODO: Integrate with existing ticket service
                // For now, return sample data
                var tickets = new List<TicketDto>
                {
                    new TicketDto
                    {
                        Id = 1,
                        TicketNumber = "T001",
                        Date = DateTime.Now.AddHours(-2),
                        LastOrderDate = DateTime.Now.AddHours(-1),
                        LastPaymentDate = DateTime.Now,
                        TotalAmount = 25.50m,
                        RemainingAmount = 0,
                        State = "Paid",
                        Orders = new List<OrderDto>
                        {
                            new OrderDto
                            {
                                Id = 1,
                                MenuItemName = "Cheeseburger",
                                Quantity = 1,
                                Price = 15.50m,
                                Total = 15.50m,
                                State = "Prepared",
                                CreatedDateTime = DateTime.Now.AddHours(-2)
                            },
                            new OrderDto
                            {
                                Id = 2,
                                MenuItemName = "French Fries",
                                Quantity = 1,
                                Price = 5.00m,
                                Total = 5.00m,
                                State = "Prepared",
                                CreatedDateTime = DateTime.Now.AddHours(-2)
                            },
                            new OrderDto
                            {
                                Id = 3,
                                MenuItemName = "Coca Cola",
                                Quantity = 1,
                                Price = 5.00m,
                                Total = 5.00m,
                                State = "Prepared",
                                CreatedDateTime = DateTime.Now.AddHours(-2)
                            }
                        },
                        Payments = new List<PaymentDto>
                        {
                            new PaymentDto
                            {
                                Id = 1,
                                PaymentType = "Cash",
                                Amount = 25.50m,
                                Date = DateTime.Now
                            }
                        }
                    },
                    new TicketDto
                    {
                        Id = 2,
                        TicketNumber = "T002",
                        Date = DateTime.Now.AddMinutes(-30),
                        LastOrderDate = DateTime.Now.AddMinutes(-25),
                        LastPaymentDate = DateTime.Now.AddMinutes(-30),
                        TotalAmount = 12.00m,
                        RemainingAmount = 12.00m,
                        State = "Open",
                        Orders = new List<OrderDto>
                        {
                            new OrderDto
                            {
                                Id = 4,
                                MenuItemName = "Caesar Salad",
                                Quantity = 1,
                                Price = 12.00m,
                                Total = 12.00m,
                                State = "In Progress",
                                CreatedDateTime = DateTime.Now.AddMinutes(-25)
                            }
                        }
                    }
                };

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tickets");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetTicket(int id)
        {
            try
            {
                // TODO: Integrate with existing ticket service
                // For now, return sample data based on ID
                if (id == 1)
                {
                    var ticket = new TicketDto
                    {
                        Id = 1,
                        TicketNumber = "T001",
                        Date = DateTime.Now.AddHours(-2),
                        LastOrderDate = DateTime.Now.AddHours(-1),
                        LastPaymentDate = DateTime.Now,
                        TotalAmount = 25.50m,
                        RemainingAmount = 0,
                        State = "Paid"
                    };
                    return Ok(ticket);
                }

                return NotFound($"Ticket with ID {id} not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ticket {TicketId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> CreateTicket([FromBody] TicketDto ticketData)
        {
            try
            {
                // TODO: Integrate with existing ticket service
                // For now, return the created ticket with a new ID
                ticketData.Id = new Random().Next(1000, 9999);
                ticketData.TicketNumber = $"T{ticketData.Id:000}";
                ticketData.Date = DateTime.Now;
                ticketData.LastOrderDate = DateTime.Now;
                ticketData.LastPaymentDate = DateTime.Now;
                ticketData.State = "Open";

                return CreatedAtAction(nameof(GetTicket), new { id = ticketData.Id }, ticketData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ticket");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketDto ticketData)
        {
            try
            {
                // TODO: Integrate with existing ticket service
                if (id != ticketData.Id)
                {
                    return BadRequest("Ticket ID mismatch");
                }

                // Simulate update
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ticket {TicketId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}