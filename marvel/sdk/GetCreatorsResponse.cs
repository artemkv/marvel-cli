using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace marvel.sdk
{
	/// <summary>
	/// Contains response data with the list of creators retrieved from the server.
	/// </summary>
	[DataContract]
	public class GetCreatorsResponse
	{
		[DataMember(Name = "pageNumber")]
		public int PageNumber { get; private set; }
		[DataMember(Name = "pageSize")]
		public int PageSize { get; private set; }
		[DataMember(Name = "total")]
		public int Total { get; private set; }
		[DataMember(Name = "count")]
		public int Count { get; private set; }
		[DataMember(Name = "results")]
		public List<Creator> Creators { get; private set; }
	}
}
