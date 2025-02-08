using System;
using System.Collections.Generic;

namespace Api1.Data.Models;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string NameCustomer { get; set; } = null!;

    public int IdTypeDocument { get; set; }

    public int DocumentNumber { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public virtual TypeDocument? IdTypeDocumentNavigation { get; set; }
}
