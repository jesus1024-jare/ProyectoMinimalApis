using System;
using System.Collections.Generic;

namespace Api1.Data.Models;

public partial class TypeDocument
{
    public int IdTypeDocument { get; set; }

    public string DocumentName { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
