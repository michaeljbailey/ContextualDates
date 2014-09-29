using System;
using ContextualDates.Library;
using ContextualDates.Library.Services;
using NUnit.Framework;

namespace ContextualDates.LibraryTests.Services
{
    public class DateContextParsingServiceTests
    {
        [TestFixture]
        public static class when_parsing_date_contexts
        {
            [Test]
            public static void then_should_return_a_single_date_context_from_an_anchor()
            {
                // Arrange
                var dateContextParsingService = new DateContextParsingService();
                var documentText = "On 04/21/1980, Mike heard a sudden shriek of terror.";
                // Act
                
                var dateContexts = dateContextParsingService.ParseOutDateContexts(documentText);

                // Assert
                Assert.That(dateContexts.Count, Is.EqualTo(1));
            }
        } 
    }
}