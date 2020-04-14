using EvolentHealth.Core.Model.Base;
using EvolentHealth.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvolentHealth.Core.Model
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Status Status { get; set; }

    }
}
