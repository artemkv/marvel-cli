using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace marvel.sdk
{
	/// <summary>
	/// Contains note data to post to the server.
	/// </summary>
	[DataContract]
	class NoteToPost
	{
		[DataMember(Name = "text")]
		public String Text { get; set; }
	}
}
