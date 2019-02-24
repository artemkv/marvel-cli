using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace marvel.sdk
{
	/// <summary>
	/// Contains data returned from the server in case of error.
	/// </summary>
	[DataContract]
	class ErrorResponse
	{
		[DataMember(Name = "message")]
		public String Message { get; private set; }
	}
}
