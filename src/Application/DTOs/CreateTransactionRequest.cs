using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;

public class CreateTransactionRequest
{
    public decimal Amount { get; set; }

    public int Type { get; set; }
}
