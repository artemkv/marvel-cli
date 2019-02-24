using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace marvel.sdk
{
	/// <summary>
	/// Provides the HttpClient object for anyone who needs it.
	/// It is a best practice to reuse the HttpClient across connections.
	/// </summary>
	internal static class HttpClientProvider
	{
		private static HttpClient _httpClient;

		static HttpClientProvider()
		{
			_httpClient = new HttpClient();
			_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
		}

		public static HttpClient HttpClient
		{
			get
			{
				return _httpClient;
			}
		}
	}
}
