﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurnerSoftware.RobotsExclusionTools.Tokenization;
using TurnerSoftware.RobotsExclusionTools.Tokenization.Tokenizers;
using TurnerSoftware.RobotsExclusionTools.Tokenization.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurnerSoftware.RobotsExclusionTools.Tests.RobotsFile
{
	[TestClass]
	public class RobotsFileTokenPatternValidatorTests : TestBase
	{
		[TestMethod]
		public void RFCValidPatterns()
		{
			var robots = LoadRobotsRfcFileExample();
			var tokenizer = new RobotsFileTokenizer();
			var tokens = tokenizer.Tokenize(robots);

			var validator = new RobotsFileTokenPatternValidator();
			var result = validator.Validate(tokens);

			Assert.IsTrue(result.IsValid);
		}

		[TestMethod]
		public void MalformedFieldPatterns()
		{
			var robots = LoadResource("RobotsFile/InvalidField-Example.txt");
			var tokenizer = new RobotsFileTokenizer();
			var tokens = tokenizer.Tokenize(robots);

			var validator = new RobotsFileTokenPatternValidator();
			var result = validator.Validate(tokens);

			Assert.IsFalse(result.IsValid);

			var firstErrorExpectedTokens = result.Errors.First().Expected;
			Assert.AreEqual(TokenType.NewLine, firstErrorExpectedTokens.ElementAt(0));
			Assert.AreEqual(1, firstErrorExpectedTokens.Count());
			Assert.AreEqual(19, result.Errors.Count());
		}
	}
}
