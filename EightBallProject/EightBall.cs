using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightBallProject
{
    public class EightBall
    {
        public int CustomResponseLimit { get; private set; } = 5;

        // Used a property with read-only access instead of a field which is better for testability.
        public List<string> Responses { get; } = new List<string>
            {
                "Yeah.",
                "I don't think so.",
                "Maybe.",
                "That one's kind of complicated.",
                "When pigs fly.",
                "No.",
                "Unlikely, but still possible.",
                "Nah.",
                "For sure.",
                "100% yes!"
            };

        public string Ask(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                return "No question detected.";
            }

            var randomDefaultResponseIndex = new Random().Next(0, Responses.Count);

            return Responses[randomDefaultResponseIndex];
        }

        public string AddResponse(string response)
        {
            if (Responses.Count < 15 && !String.IsNullOrWhiteSpace(response))
            {
                Responses.Add(response);
                CustomResponseLimit--;

                return "Response successfully added.";
            }
            else
            {
                throw new InvalidOperationException("No response detected or maximum custom response limit reached.");
            }
        }

        public string RemoveResponse(int index)
        {
            if (Responses.Count > 0 && (index >= 10 && index <= 14))
            {
                Responses.RemoveAt(index);
                CustomResponseLimit++;

                return "Response successfully removed.";
            }
            else
            {
                throw new InvalidOperationException("Tried to delete from empty list or remove default response.");
            }
        }
    }
}
