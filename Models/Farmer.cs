﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri_Energy_Connect.Models
{
    [Table("Farmer")]
    public class Farmer
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("location")]
        public string Location { get; set; }

        [Required]
        [Column("phone number")]
        public string Contact { get; set; }
    }

}
