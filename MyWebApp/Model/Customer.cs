

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace MyWebApp.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
