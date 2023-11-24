using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DatabaseActionsLibrary.Model;

namespace DatabaseActionsLibrary
{
    public class ParserMessages
    {
        public static List<Messages_users> ParserMessagesUsers()
        {
            List<Messages_users> newAllMessages = new List<Messages_users>();

            IWebDriver driver = new ChromeDriver();

            string url = "https://4pda.to/forum/index.php?showtopic=684033";

            driver.Navigate().GoToUrl(url);

            var messageNumberElement = driver.FindElements(By.XPath("//*[@class='row2']/div/a"));

            var usernameElement = driver.FindElements(By.ClassName("normalname"));

            var messageElement = driver.FindElements(By.ClassName("postcolor"));

            for(int i = 0; i < usernameElement.Count; i++)
            {
                Messages_users newMessage = new Messages_users();

                newMessage.Number_message = messageNumberElement[i].Text;
                newMessage.Login_user = usernameElement[i].Text;
                newMessage.Message_user = messageElement[i].Text;

                newAllMessages.Add(newMessage);
            }

            driver.Quit();

            return newAllMessages;
        }
    }
}
