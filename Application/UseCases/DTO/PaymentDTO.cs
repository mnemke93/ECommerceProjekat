using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class PaymentDTO : BaseDTO
    {
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string TransactionID { get; set; }
        public string PaymentDate { get; set; }
        public int OrderID { get; set; }
    }

    public class CreatePaymentDTO : BaseDTO
    {
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string TransactionID { get; set; }
        public string PaymentDate { get; set; }
        public int OrderID { get; set; }
    }

    public class UpdatePaymentDTO : BaseDTO
    {
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string TransactionID { get; set; }
        public string PaymentDate { get; set; }
        public int OrderID { get; set; }
        public bool IsActive { get; set; }
    }
    public class DeletePaymentDTO : BaseDTO
    {
    }
}
