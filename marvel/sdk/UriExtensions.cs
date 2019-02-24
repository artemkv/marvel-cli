using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace marvel.sdk
{
	/// <summary>
	/// Copy-paste from StackOverflow
	/// https://stackoverflow.com/questions/14517798/append-values-to-query-string
	/// </summary>
	static class UriExtensions
	{
		/// <summary>
		/// Adds the specified parameter to the Query String.
		/// </summary>
		/// <param name="url">Url to add parameters to.</param>
		/// <param name="paramName">Name of the parameter to add.</param>
		/// <param name="paramValue">Value for the parameter to add.</param>
		/// <returns>Url with added parameter.</returns>
		public static Uri AddParameter(this Uri url, string paramName, string paramValue)
		{
			var uriBuilder = new UriBuilder(url);
			var query = HttpUtility.ParseQueryString(uriBuilder.Query);
			query[paramName] = paramValue;
			uriBuilder.Query = query.ToString();
			return uriBuilder.Uri;
		}
	}
}
