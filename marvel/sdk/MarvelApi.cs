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
		/// <summary>
		/// Returns the creator by id.
		/// </summary>
		/// <param name="url">Base url to connect to server.</param>
		/// <param name="id">Id of the creator.</param>
		/// <returns>The creator.</returns>
		public static async Task<Creator> GetCreatorAsync(string url, int id)
		{
			var baseUrl = new Uri(url);
			var creatorUrl = new Uri(baseUrl, $"api/creator/{id.ToString()}");
			var response = await HttpClientProvider.HttpClient.GetAsync(creatorUrl);

			if (response.IsSuccessStatusCode)
			{
				var results = JsonConvert.DeserializeObject<Creator>(await response.Content.ReadAsStringAsync());
				return results;
			}

			var error = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
			throw new HttpRequestException(((int)response.StatusCode).ToString() + " " + error.Message);
		}

		/// <summary>
		/// Returns the list of creators with paging and sorting.
		/// </summary>
		/// <param name="url">Base url to connect to server.</param>
		/// <param name="fullName">Full name of the creator.</param>
		/// <param name="modifiedSince">Modified since criteria.</param>
		/// <param name="page">Page number (0-based).</param>
		/// <param name="size">Page size (max 1000 accepted by server).</param>
		/// <param name="sorting">List of sorting criterias.</param>
		/// <returns></returns>
		public static async Task<GetCreatorsResponse> GetCreatorsAsync(
			string url, string fullName, DateTime? modifiedSince, int page, int size, IEnumerable<string> sorting)
		{
			var baseUrl = new Uri(url);
			var creatorsUrl = new Uri(baseUrl, @"api/creators");
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

			var error = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
			throw new HttpRequestException(((int)response.StatusCode).ToString() + " " + error.Message);
		}

		/// <summary>
		/// Adds the note to the creator with given id.
		/// If the note already exists, overwrites its text.
		/// </summary>
		/// <param name="url">Base url to connect to server.</param>
		/// <param name="creatorId">Id of the creator.</param>
		/// <param name="text">Text of the note</param>
		/// <returns>Nothing</returns>
		public static async Task AddNoteAsync(string url, int creatorId, string text)
		{
			var note = new NoteToPost
			{
				Text = text
			};

			var baseUrl = new Uri(url);
			var noteUrl = new Uri(baseUrl, $"api/creator/{creatorId.ToString()}/note");

			var content = new StringContent(JsonConvert.SerializeObject(note));
			content.Headers.Remove("Content-Type");
			content.Headers.Add("Content-Type", "application/json");

			var response = await HttpClientProvider.HttpClient.PutAsync(noteUrl, content);
			if (!response.IsSuccessStatusCode)
			{
				var error = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
				throw new HttpRequestException(((int)response.StatusCode).ToString() + " " + error.Message);
			}
		}

		/// <summary>
		/// Deletes the note for the creator with given id.
		/// </summary>
		/// <param name="url">Base url to connect to server.</param>
		/// <param name="creatorId">Id of the creator.</param>
		/// <returns>Nothing</returns>
		public static async Task DeleteNoteAsync(string url, int creatorId)
		{
			var baseUrl = new Uri(url);
			var noteUrl = new Uri(baseUrl, $"api/creator/{creatorId.ToString()}/note");

			var response = await HttpClientProvider.HttpClient.DeleteAsync(noteUrl);
			if (!response.IsSuccessStatusCode)
			{
				var error = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
				throw new HttpRequestException(((int)response.StatusCode).ToString() + " " + error.Message);
			}
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
