using System;
using System.ComponentModel.DataAnnotations;

namespace LPNU_Library.Models
{
	public class Book
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();

		[Required, MaxLength(200)]
		public string Title { get; set; }

		[Required, MaxLength(150)]
		public string Author { get; set; }

		[Range(1500, 2100)]
		public int Year { get; set; }
	}
}
