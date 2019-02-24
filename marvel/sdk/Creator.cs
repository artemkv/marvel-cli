using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace marvel.sdk
{
	/// <summary>
	/// Contains creator data retrieved from the server.
	/// </summary>
	[DataContract]
	public class Creator
	{
		[DataMember(Name = "id")]
		public int Id { get; private set; }
		[DataMember(Name = "fullName")]
		public String FullName { get; private set; }
		[DataMember(Name = "modified")]
		public DateTime Modified { get; private set; }
		[DataMember(Name = "comicsTotal")]
		public int ComicsTotal { get; private set; }
		[DataMember(Name = "seriesTotal")]
		public int SeriesTotal { get; private set; }
		[DataMember(Name = "note")]
		public Note Note { get; private set; }
	}
}
