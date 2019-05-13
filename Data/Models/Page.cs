using System;
using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Models
{
    public partial class Page : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
		public string Content { get; set; }
    }
}
