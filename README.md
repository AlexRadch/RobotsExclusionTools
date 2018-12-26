# Robots Exclusion Tools
A "robots.txt" parsing and querying library in C#, closely following the [NoRobots RFC](http://www.robotstxt.org/norobots-rfc.txt) and other details on [robotstxt.org](http://www.robotstxt.org/robotstxt.html).

[![AppVeyor](https://img.shields.io/appveyor/ci/Turnerj/robotsexclusiontools/master.svg)](https://ci.appveyor.com/project/Turnerj/robotsexclusiontools)
[![Codecov](https://img.shields.io/codecov/c/github/turnersoftware/robotsexclusiontools/master.svg)](https://codecov.io/gh/TurnerSoftware/RobotsExclusionTools)
[![NuGet](https://img.shields.io/nuget/v/TurnerSoftware.RobotsExclusionTools.svg)](https://www.nuget.org/packages/TurnerSoftware.RobotsExclusionTools)

## Features
- Load Robots by string, by URI (Async) or by streams (Async)
- Supports multiple user-agents and "*"
- Supports `Allow` and `Disallow`
- Supports `Crawl-delay` entries
- Supports `Sitemap` entries
- Supports wildcard paths (*) as well as must-end-with declarations ($)
- Built-in "robots.txt" tokenization system (allowing extension to support other custom fields)
- Built-in "robots.txt" validator (allowing to validate a tokenized file)

## NoRobots RFC Compatibility
This library attempts to stick closely to the rules defined in the RFC document, including:
- Global/any user-agent when none is explicitly defined (Section 3.2.1 of RFC)
- Field names (eg. "User-agent") are case sensitive and are character restricted (Section 3.3)
- Allow/disallow rules are performed by order-of-occurence (Section 3.2.2)
- Loading by URI applies default rules based on access to "robots.txt" (Section 3.1)
- Interoperability for varying line endings (Section 5.2)

## Tokenization & Validation
At the core of the library is a tokenization system to parse the file format. 
It follows the formal syntax rules defined in Section 3.3 of the NoRobots RFC to the characters that are valid.
When used in conjunction with the token validator, it can enforce the correct token structure too.

The major benefit for designing the library around this system is that is allows for greater extendability.
If you wanted to support custom fields that the core `RobotsFile` class didn't use, you can parse the data with the tokenizer.

## Example Usage
```csharp
using TurnerSoftware.RobotsExclusionTools;

var robotsParser = new RobotsParser();
RobotsFile robotsFile = await robotsParser.FromUriAsync(new Uri("http://www.example.org/robots.txt"));

var allowedAccess = robotsFile.IsAllowedAccess(
	new Uri("http://www.example.org/some/url/i-want-to/check"),
	"MyUserAgent"
);

```