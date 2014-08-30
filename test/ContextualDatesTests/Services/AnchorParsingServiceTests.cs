using ContextualDates.Services;
using NUnit.Framework;

namespace ContextualDatesTests.Services
{
    public class AnchorParsingServiceTests
    {
        [TestFixture]
        public static class when_parsing_out_anchors
        {
            [Test]
            public static void then_should_return_a_single_anchor_for_a_passage_with_one_date()
            {
                // Arrange
                var anchorParsingService = new AnchorParsingService();

                // Act
                const string documentText = "On 04/21/1980, Mike heard a sudden shriek of terror.";
                var anchorList = anchorParsingService.ParseOutAnchors(documentText);


                // Assert
                Assert.That(anchorList.Count, Is.EqualTo(1));
            }
        } 
    }
}