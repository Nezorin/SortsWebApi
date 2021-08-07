using System;
using System.ComponentModel.DataAnnotations;

namespace Sorts.Models
{
    public class SortingResult
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string SortName { get; set; }
        public int[] StartArray { get; set; }
        public int[] SortedArray { get; set; }
        public TimeSpan SortingTime { get; set; }
        public DateTime RequestTime { get; set; }
    }
}