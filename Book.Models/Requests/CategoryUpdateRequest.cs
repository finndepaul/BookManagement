using Book.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Models.Requests
{
    public class CategoryUpdateRequest
    {
        public string CategoryName { get; set; }
        public Status Status { get; set; }
    }
}
