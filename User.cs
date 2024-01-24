using System;
using System.Collections.Generic;

namespace GrpcServer
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string? Fio { get; set; }
        public string? Phone { get; set; }
        public string? Pass { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
