using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace marvel.sdk
{
	/// <summary>
	/// Contains creator note retrieved from the server.
	/// </summary>
	[DataContract]
	public class Note
	{
		[DataMember(Name = "id")]
		public int Id { get; private set; }
		[DataMember(Name = "text")]
		public string Text { get; set; }
		[DataMember(Name = "creatorId")]
		public int CreatorId { get; private set; }
		[DataMember(Name = "creatorFullName")]
		public string CreatorFullName { get; private set; }
	}
}
