using System;
using System.Collections.Generic;
using System.Media;

namespace CyberSecurityAwarenessChatBot
{
    class Program
    {
        static UserProfile user = new UserProfile();

        static Dictionary<string, string> responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "how are you", "I'm just a bot, but I'm here to help you stay safe online!" },
            { "what's your purpose", "I am here to educate you about cybersecurity and online safety." },
            { "what can i ask you about", "You can ask me about: Password Safety, Phishing, Safe Browsing, Privacy, or Scams." },
            { "password", " A password is a secret word, phrase, or combination of characters that is used to verify your identity when accessing accounts, devices, or services\n- Use 12+ characters\n- Never reuse passwords\n- Use 2FA\n- Use a password manager" },
            { "phishing", " Phishing involves tricking users into giving up personal info. Never click unknown links or give out passwords!" },
            { "safe browsing", "Safe browsing means using the internet in a way that protects your personal information and keeps your device secure from online threats.\n- Look for HTTPS\n- Use ad-blockers\n- Avoid public WiFi for sensitive tasks" },
            { "privacy", "Privacy refers to your ability to control how your personal information is collected, used, and shared online.\n- Review app permissions\n- Use a VPN on public networks\n- Limit social media sharing" },
            { "scam", "A scam is a dishonest scheme or trick used to cheat someone out of their money, personal information, or security. \n- Fake offers\n- Tech support fraud\n- Romance scams\n- Investment frauds" },
            
        };

        static Dictionary<string, List<string>> randomTips = new Dictionary<string, List<string>>()
        {
            { "phishing", new List<string>
                {
                    "Tip: Phishing emails often contain grammar mistakes.",
                    "Tip: Real companies don't ask for passwords via email.",
                    "Did you know? Hover over a link to see where it goes."
                }
            },
            { "password", new List<string>
                {
                    "Pro Tip: Use passphrases like 'BlueSky$2025' instead of random characters.",
                    "Fact: Password managers help you store secure passwords easily."
                }
            }
        };

        static void Main()
        {
            Console.Title = "Cybersecurity Awareness ChatBot";
            
            DisplayWelcomeScreen();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{user.Name}: ");
                Console.ResetColor();

                string input = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    ShowError("Please enter a question or type 'help'.");
                    continue;
                }

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    ShowMessage("Goodbye! Stay safe online.", ConsoleColor.Yellow);
                    break;
                }

               
                user.PastQuestions.Add(input);

                string response = ProcessUserInput(input);
                ShowMessage(response, ConsoleColor.Cyan);
            }
        }

       

        static void DisplayWelcomeScreen()
        {
            DisplayASCIIArt();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("*   Welcome to Cybersecurity Awareness ChatBot  *");
            Console.WriteLine("-------------------------------------------------");
            Console.ResetColor();

            while (string.IsNullOrWhiteSpace(user.Name))
            {
                Console.Write("Enter your name: ");
                user.Name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(user.Name))
                    ShowError("Name cannot be empty. Please try again.");
            }

            ShowMessage($"\nHello {user.Name}, how can I assist you today?\n(Type 'help' for options, 'exit' to quit)", ConsoleColor.Green);
        }

        static void DisplayASCIIArt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
     ______________________
          .-'      '-.
         /            \
        |              |
        |,  .-.  .-.  ,|
        | )(_o/  \o_)( |
        |/     /\     \|
        (_     ^^     _)
         \__|IIIIII|__/
          | \IIIIII/ |
          \          /
           `--------`
        ___||____||___
       /   |      |   \
      /___|______|___\
     |       CYBER      |
     |    SECURITY BOT   |
     |___________________|");
            Console.ResetColor();
        }

        static string ProcessUserInput(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput == "help")
                return responses["what can i ask you about"];

            if (lowerInput == "recall" || lowerInput == "what have we talked about")
            {
                if (user.PastQuestions.Count == 0)
                    return "We haven’t discussed anything yet.";

                return "Here's what you've asked me so far:\n- " + string.Join("\n- ", user.PastQuestions);
            }

            if (lowerInput.Contains("interested in"))
            {
                foreach (var topic in responses.Keys)
                {
                    if (lowerInput.Contains(topic))
                    {
                        user.Interest = topic;
                        return $"Got it! I'll remember you're interested in {topic}. What would you like to ask?";
                    }
                }
            }

            string sentiment = DetectSentiment(lowerInput);
            if (sentiment == "worried")
                return "I understand cybersecurity can be worrying. I'm here to help!";
            if (sentiment == "frustrated")
                return "Cybersecurity can feel complex, but I’ll explain it simply.";

            foreach (var keyword in responses.Keys)
            {
                if (lowerInput.Contains(keyword))
                {
                    if (randomTips.ContainsKey(keyword))
                        return GetRandomTip(keyword);
                    return responses[keyword];
                }
            }

            if (!string.IsNullOrEmpty(user.Interest))
                return $"Since you're interested in {user.Interest}, here’s something helpful:\n{responses[user.Interest]}";

            return "Sorry, I didn't understand that. Please ask about password safety, phishing, privacy, or type 'help'.";
        }

        static string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("concerned"))
                return "worried";

            if (input.Contains("angry") || input.Contains("annoyed") || input.Contains("frustrated"))
                return "frustrated";

            return "neutral";
        }

        static string GetRandomTip(string topic)
        {
            var tips = randomTips[topic];
            Random rand = new Random();
            int index = rand.Next(tips.Count);
            return $"{responses[topic]}\n\n{tips[index]}";
        }

        static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.ResetColor();
        }
    }

    // 🔹 Extended User Profile with memory
    class UserProfile
    {
        public string Name { get; set; } = string.Empty;
        public string Interest { get; set; } = string.Empty;
        public List<string> PastQuestions { get; set; } = new List<string>(); // NEW
    }
}
