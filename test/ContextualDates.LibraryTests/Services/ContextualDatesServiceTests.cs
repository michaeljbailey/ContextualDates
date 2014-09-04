using System;
using System.Collections.Generic;
using ContextualDates.Library;
using ContextualDates.Library.Services;
using NUnit.Framework;

namespace ContextualDates.LibraryTests.Services
{
    public class ContextualDatesServiceTests
    {
        [TestFixture]
        public static class when_identifying_a_context_for_querying
        {
            [Test]
            public static void then_should_return_a_single_date_context()
            {
                // Arrange
                var contextualDatesService = new ContextualDatesService();

                // Act
                const int cursorIndex = 5;
                const string documentText = "On 04/21/1980, Mike heard a sudden shriek of terror.";
                var dateContext = new DateContext
                {
                    StartIndex = 0,
                    EndIndex = documentText.Length - 1
                };

                var anchor = new List<Anchor>
                {
                    new Anchor
                    {
                        StartIndex = 0,
                        EndIndex = documentText.Length,
                        AnchorDate = new DateTime(1980, 4, 21),
                        DocumentText = documentText,
                        Contexts = new List<DateContext>
                        {
                            dateContext
                        }
                    }
                };
                var context = contextualDatesService.IdentifyContext(cursorIndex, anchor);

                // Assert
                Assert.That(context, Is.EqualTo(dateContext));
            }
        } 
    }
}