using System.Linq;
using ContextualDates;
using ContextualDates.Services;
using Moq;
using NUnit.Framework;

namespace ContextualDatesTests.Services
{
    public class AnchorParsingServiceTests
    {
        [TestFixture]
        public static class when_parsing_out_anchors
        {
            [Test]
            public static void then_should_parse_out_date_contexts()
            {
                // Arrange
                var dateContextParsingService = new Mock<IDateContextParsingService>();
                var anchorParsingService = new AnchorParsingService(dateContextParsingService.Object);

                // Act
                const string documentText = "On 04/21/1980, Mike heard a sudden shriek of terror.";
                var anchorList = anchorParsingService.ParseOutAnchors(documentText);


                // Assert
                dateContextParsingService.Verify(service => service.ParseOutDateContexts(It.IsAny<Anchor>())); //This is a code smell, probably needs a factory
            }
            [Test]
            public static void then_should_assign_document_text_field_to_anchor_document_text_field()
            {
                // Arrange
                var anchorParsingService = new AnchorParsingService(new Mock<IDateContextParsingService>().Object);

                // Act
                const string documentText = "On 04/21/1980, Mike heard a sudden shriek of terror.";
                var anchorList = anchorParsingService.ParseOutAnchors(documentText);


                // Assert
                Assert.That(anchorList.First().DocumentText, Is.EqualTo(documentText));
            }
            [Test]
            public static void then_should_return_a_single_anchor_for_a_passage_with_one_date()
            {
                // Arrange
                var anchorParsingService = new AnchorParsingService(new Mock<IDateContextParsingService>().Object);

                // Act
                const string documentText = "On 04/21/1980, Mike heard a sudden shriek of terror.";
                var anchorList = anchorParsingService.ParseOutAnchors(documentText);


                // Assert
                Assert.That(anchorList.Count, Is.EqualTo(1));
            }
            [Test]
            public static void then_should_return_the_specific_anchor_for_a_passage_with_one_date()
            {
                // Arrange
                var anchorParsingService = new AnchorParsingService(new Mock<IDateContextParsingService>().Object);

                // Act
                const string documentText = "On 04/21/1980, Mike heard a sudden shriek of terror.";
                var anchorList = anchorParsingService.ParseOutAnchors(documentText);


                // Assert
                Assert.That(anchorList.First().AnchorDate.ToShortDateString(), Is.EqualTo("4/21/1980"));
            }
        } 
    }
}