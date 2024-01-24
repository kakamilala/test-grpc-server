using System;
using System.Collections.Generic;

namespace GrpcServer
{
    public partial class Account
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Number { get; set; }
        public string? Type { get; set; }

        public virtual User? User { get; set; }
    }
}
