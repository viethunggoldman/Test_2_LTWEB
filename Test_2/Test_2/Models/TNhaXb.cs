﻿using System;
using System.Collections.Generic;

namespace Test_2.Models;

public partial class TNhaXb
{
    public string MaNxb { get; set; } = null!;

    public string? TenNxb { get; set; }

    public virtual ICollection<TSach> TSaches { get; set; } = new List<TSach>();
}
