﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace TurnerSoftware.RobotsExclusionTools.Tests.Server
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
					Path.Combine(Directory.GetCurrentDirectory(), "Resources"))
			});
		}
	}
}
