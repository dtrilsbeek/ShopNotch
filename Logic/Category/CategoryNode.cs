using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Logic
{
	class Node
	{
		public List<Node> SubNodes { get; set; }

		public Category Category { get; set; }
	}
}
