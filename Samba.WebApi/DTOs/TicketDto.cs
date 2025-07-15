using System;
using System.Collections.Generic;

namespace Samba.WebApi.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public DateTime LastOrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string State { get; set; }
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
        public List<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public string MenuItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string State { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }

    public class PaymentDto
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}