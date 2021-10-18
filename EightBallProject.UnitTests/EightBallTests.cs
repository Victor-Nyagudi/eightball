using System;
using NUnit.Framework;

namespace EightBallProject.UnitTests
{
    [TestFixture]
    class EightBallTests
    {
        EightBall _eightball;

        int _customResponseLimit, _responsesCount;

        [SetUp]
        public void SetUp()
        {
            _eightball = new EightBall();
            _customResponseLimit = _eightball.CustomResponseLimit;
            _responsesCount = _eightball.Responses.Count;
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Ask_QuestionIsNullOrWhiteSpace_ReturnsErrorMessage(string question)
        {
            // Arrange 
            // Act
            // Assert

            var result = _eightball.Ask(question);

            Assert.That(result, Is.EqualTo("No question detected."));
        }

        [Test]
        public void Ask_ValidQuestion_ReturnsRandomResponse()
        {
            var result = _eightball.Ask("a");

            Assert.That(_eightball.Responses, Is.Not.Empty);
            Assert.That(_eightball.Responses, Does.Contain(result));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void AddResponse_ResponseIsNullOrWhiteSpace_ThrowsInvalidOperationException(string response)
        {
            Assert.That(() => _eightball.AddResponse(response), Throws.Exception.TypeOf<InvalidOperationException>());

            // Shorter way to do it
            // Assert.That(() => _eightball.AddResponse(response), Throws.InvalidOperationException);
        }

        [Test]
        public void AddResponse_ValidReponse_ResonseAddedToResponsesList()
        {
            var result = _eightball.AddResponse("a");

            Assert.That(_eightball.CustomResponseLimit, Is.EqualTo(_customResponseLimit - 1));
            Assert.That(_eightball.Responses.Count, Is.EqualTo(_responsesCount + 1));
            Assert.That(result, Does.Contain("successfully added"));
        }

        [Test]
        public void RemoveResponse_InvalidIndex_ThrowsInvalidOperationException()
        {
            Assert.That(() => _eightball.RemoveResponse(16), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveResponse_ValidIndex_RemovesResponseFromResponsesList()
        {
            _eightball.AddResponse("a");
            var result = _eightball.RemoveResponse(10);

            Assert.That(_eightball.CustomResponseLimit, Is.EqualTo(_customResponseLimit));
            Assert.That(_eightball.Responses.Count, Is.EqualTo(_responsesCount));
            Assert.That(result, Does.Contain("successfully removed"));
        }
    }
}
