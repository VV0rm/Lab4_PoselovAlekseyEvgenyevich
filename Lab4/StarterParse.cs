using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseActionsLibrary;
using DatabaseActionsLibrary.Model;

namespace Lab4
{
    class StarterParse
    {
        static void Main()
        {
            ActionsDB actions = new ActionsDB();

            Messages_users fisrtSearch = actions.GetByID(60);

            Console.Write(fisrtSearch.Login_user + " " + fisrtSearch.Number_message + "\n");
            Console.WriteLine();
            Console.Write(fisrtSearch.Message_user + "\n");
            Console.WriteLine();

            List<Messages_users> secondSearch = actions.GetByName("svansvan");

            foreach(Messages_users message in secondSearch)
            {
                Console.Write(message.Login_user + " " + message.Number_message + "\n");
                Console.WriteLine();
                Console.Write(message.Message_user + "\n");
                Console.WriteLine();
            }

            actions.Add();

            actions.Update(11);
            actions.Update(83);

            actions.Delete(12);
            actions.Delete(84);

            Console.ReadKey();
        }
    }
}
