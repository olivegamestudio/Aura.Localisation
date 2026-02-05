using System.Globalization;
using FluentAssertions;

namespace Aura.Tests;

public class LocalisedStringTableCollectionTests : IDisposable
{
	public LocalisedStringTableCollectionTests() => LocalisedStringTableCollection.Clear();

	public void Dispose() => LocalisedStringTableCollection.Clear();

	[Fact]
	public void Add_And_Resolve_ReturnsCorrectText()
	{
		// Arrange
		string key = "greeting";
		CultureInfo culture = new CultureInfo("en-US");
		string text = "Hello";
		LocalizationSettings.SelectedLocale = culture;

		// Act
		LocalisedStringTableCollection.Add(key, culture, text);
		string result = LocalisedStringTableCollection.Resolve(key);

		// Assert
		result.Should().Be(text);
	}

	[Fact]
	public void Resolve_WhenKeyDoesNotExist_ReturnsEmptyString()
	{
		// Act
		string result = LocalisedStringTableCollection.Resolve("non_existent_key");

		// Assert
		result.Should().BeEmpty();
	}

	[Theory]
	[InlineData("en-US", "Hello")]
	[InlineData("fr-FR", "Bonjour")]
	public void Resolve_ReturnsCorrectText_BasedOnSelectedLocale(string cultureCode, string expected)
	{
		// Arrange
		string key = "greeting";
		CultureInfo enCulture = new CultureInfo("en-US");
		CultureInfo frCulture = new CultureInfo("fr-FR");

		LocalisedStringTableCollection.Add(key, enCulture, "Hello");
		LocalisedStringTableCollection.Add(key, frCulture, "Bonjour");

		// Act
		LocalizationSettings.SelectedLocale = new CultureInfo(cultureCode);
		string result = LocalisedStringTableCollection.Resolve(key);

		// Assert
		result.Should().Be(expected);
	}
}
