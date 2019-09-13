using System;
using System.Collections.Generic;
using System.Text;

namespace Practice4.Models
{
	class PlaceModel
	{
		public IList<CandidateModel> Candidates { get; set; }
		public string Status { get; set; }
	}
}
