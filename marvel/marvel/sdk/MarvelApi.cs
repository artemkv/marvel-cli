using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace marvel.sdk
{
	/// <summary>
	/// Provides an access to the marvel server API
	/// </summary>
	public static class MarvelApi
	{
		public static async Task<GetCreatorsResponse> GetCreatorsAsync(
			string url, string fullName, DateTime? modifiedSince, int page, int size, IEnumerable<string> sorting)
		{
			var baseUrl = new Uri(url);
			var creatorsUrl = new Uri(baseUrl, @"creators");
			creatorsUrl = creatorsUrl.AddParameter("page", page.ToString());
			creatorsUrl = creatorsUrl.AddParameter("size", size.ToString());
			if (!String.IsNullOrEmpty(fullName))
			{
				creatorsUrl = creatorsUrl.AddParameter("fullName", fullName);
			}
			if (modifiedSince != null)
			{
				// Here we take responsibility for formatting date the way API expects it.
				creatorsUrl = creatorsUrl.AddParameter("modifiedSince", modifiedSince.Value.ToString("yyyy-MM-dd'T'HH:mm:ss"));
			}
			creatorsUrl = AppendSortingParams(creatorsUrl, sorting);
			var response = await HttpClientProvider.HttpClient.GetAsync(creatorsUrl);

			if (response.IsSuccessStatusCode)
			{
				var results = JsonConvert.DeserializeObject<GetCreatorsResponse>(await response.Content.ReadAsStringAsync());
				return results;
			}

			throw new HttpRequestException(((int)response.StatusCode).ToString() + " " + response.ReasonPhrase);
		}

		private static Uri AppendSortingParams(Uri uri, IEnumerable<string> sorting)
		{
			// Since HttpUtility parses query string into namevalue collection 
			// and does not allow multiple parameters with the same name,
			// I have to append them manually.
			bool hasParams = false;
			var uriBuilder = new UriBuilder(uri);
			var query = HttpUtility.ParseQueryString(uriBuilder.Query);
			if (query.Count > 0)
			{
				hasParams = true;
			}

			StringBuilder sb = new StringBuilder(uri.AbsoluteUri);
			foreach (string sortCriteria in sorting)
			{
				if (hasParams)
				{
					sb.Append("&");
				}
				sb.Append($"sort={sortCriteria}");
				hasParams = true;
			}

			return new Uri(sb.ToString());
		}
	}
}
