# 🛡️ Cybersecurity Awareness ChatBot

A C# console-based chatbot designed to **educate users about cybersecurity** and promote **online safety awareness**. It interacts with users through friendly dialogue and provides randomized advice on topics like passwords, phishing, scams, privacy, and safe browsing.

---

## 📌 Features

- 🤖 Interactive chatbot that responds to user questions
- 🗂️ Covers key cybersecurity topics:
  - Password Safety
  - Phishing Awareness
  - Safe Browsing
  - Privacy Best Practices
  - Scam Recognition
- 🎲 Randomized responses for natural, engaging answers
- 📚 Remembers user name, interests, and past questions
- 🧠 Basic sentiment detection (e.g., frustration, concern)
- 🎨 ASCII art + color-coded terminal output

---

## 💻 Demo

Welcome to Cybersecurity Awareness ChatBot
Enter your name: Alice

Alice: tell me about phishing
Bot: Phishing is when someone tries to trick you into giving up sensitive information. Always verify links!

Alice: I'm worried about my passwords
Bot: I understand cybersecurity can be worrying. I'm here to help!

Alice: recall
Bot: Here's what you've asked me so far:

tell me about phishing

I'm worried about my passwords



## 🚀 Getting Started

### Prerequisites

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/en-us/download)
- C#-compatible IDE (e.g., Visual Studio, Visual Studio Code)

### Running the Bot

```bash
git clone https://github.com/st10448398/cybersecurity-chatbot.git
cd cybersecurity-chatbot
dotnet run
🧠 Code Structure


CyberSecurityAwarenessChatBot/
│
├── Program.cs           # Main chatbot logic
├── UserProfile.cs       # Tracks user name, interest, and past questions
├── README.md            # Project documentation
🛡 Topics Explained
Each topic contains 3+ randomized responses to simulate a more conversational AI:

Topic	Sample Insight
password    	  "A password is a secret code that only you know. It helps protect your accounts so only you can access them."
phishing     	  "Phishing is when someone tries to trick you into giving up sensitive information. Always verify links!"
privacy	        "Privacy means controlling who can see your personal data online and how it's used."
scam	          "A scam is when someone tries to fool you into doing something unsafe, like sending them money or giving them your password."
safe browsing 	"Safe browsing means using the internet in a way that protects your data and devices from threats like malware, phishing, and malicious websites."

🛠 Future Improvements
Save/load conversation history

Add GUI using WPF or WinForms

Expand sentiment detection using NLP libraries

Integrate external cybersecurity news via APIs

🙌 Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

📄 License
This project is licensed under the MIT License.

📚 References
National Cyber Security Centre (NCSC)

Cybersecurity & Infrastructure Security Agency (CISA)

StaySafeOnline.org – National Cybersecurity Alliance

OWASP Foundation

Microsoft Security Blog

These resources were consulted to help shape accurate and up-to-date cybersecurity advice in the chatbot’s responses
