using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace marvel.sdk
{
	/// <summary>
	/// Provides an access to the marvel server API
	/// </summary>
	public static class MarvelApi
	{
		public static async Task<GetCreatorsResponse> GetCreatorsAsync(
			string url, string fullName, DateTime? modifiedSince, int page, int size)
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

			var response = await HttpClientProvider.HttpClient.GetAsync(creatorsUrl);

			if (response.IsSuccessStatusCode)
			{
				var results = JsonConvert.DeserializeObject<GetCreatorsResponse>(await response.Content.ReadAsStringAsync());
				return results;
			}

			throw new HttpRequestException(((int)response.StatusCode).ToString() + " " + response.ReasonPhrase);
		}
	}
}
