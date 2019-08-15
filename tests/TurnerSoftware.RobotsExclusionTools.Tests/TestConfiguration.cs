﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TurnerSoftware.RobotsExclusionTools.Tests.Server;

namespace TurnerSoftware.RobotsExclusionTools.Tests
{
	static class TestConfiguration
	{
		private static TestServer Server { get; set; }

		private static HttpClient Client { get; set; }
		public static HttpClient GetHttpClient()
		{
			if (Client == null)
			{
				Client = Server.CreateClient();
			}
			return Client;
		}

		public static void StartupServer()
		{
			if (Server != null)
			{
				return;
			}

			var builder = new WebHostBuilder()
				.UseStartup<Startup>();

			Server = new TestServer(builder);
		}

		public static void ShutdownServer()
		{
			Server.Dispose();
		}
	}
}