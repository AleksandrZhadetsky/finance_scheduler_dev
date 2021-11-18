using Domain.Categories;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Purchases
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string CreatedById { get; set; }

        public int Count { get; set; }

        public string CategoryId { get; set; }
    }
}
