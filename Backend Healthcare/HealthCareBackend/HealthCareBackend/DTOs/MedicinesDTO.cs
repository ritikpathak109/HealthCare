using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class MedicinesDTO
    {
        [Key]
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public string Manufacturer { get; set; }
        public decimal PricePerUnit { get; set; }
        public string CategoryName { get; set; }
    }
}
