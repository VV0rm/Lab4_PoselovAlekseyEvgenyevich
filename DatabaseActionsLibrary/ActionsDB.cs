using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseActionsLibrary.Model;

namespace DatabaseActionsLibrary
{
    public class ActionsDB
    {
        public Messages_users GetByID(int index)
        {
            Messages_users messageByID = new Messages_users();
            
            if (DataBinding.db.Messages_users.Where(m => m.Id_message == index).FirstOrDefault() != null)
            {
                messageByID = DataBinding.db.Messages_users.Where(m => m.Id_message == index).FirstOrDefault();
                
                return messageByID;
            }
            else
            {
                Console.WriteLine("Неверный Id сообщения");

                messageByID = null;
                
                return messageByID;
            }
        }

        public List<Messages_users> GetByName(string name)
        {
            List<Messages_users> messagesByName = new List<Messages_users>();

            if(DataBinding.db.Messages_users.Where(m => m.Login_user == name).FirstOrDefault() != null)
            {
                messagesByName = DataBinding.db.Messages_users.Where(m => m.Login_user == name).ToList();
                
                return messagesByName;
            }
            else
            {
                Console.WriteLine("От данного пользователя нет собщений");
                
                messagesByName = null;
                
                return messagesByName;
            }
        }

        public string Add()
        {
            string result = "";
            List<Messages_users> listMessages = new List<Messages_users>();

            listMessages = ParserMessages.ParserMessagesUsers();

            foreach(Messages_users message in listMessages)
            {
                DataBinding.db.Messages_users.Add(message);

                DataBinding.db.SaveChanges();
            }

            result = "Данные успешно добавлены";

            return result;
        }

        public string Update(int index)
        {
            string result = "";

            if (DataBinding.db.Messages_users.Where(m => m.Id_message == index).FirstOrDefault() != null)
            {
                DataBinding.db.Messages_users.Where(m => m.Id_message == index).FirstOrDefault().Message_user = "Исправленное сообщение";
                DataBinding.db.SaveChanges();

                result = "Данные успешно изменены";

                return result;
            }
            else
            {
                result = "Неверный Id сообщения";

                return result;
            }
        }

        public string Delete(int index)
        {
            string result = "";

            if (DataBinding.db.Messages_users.Where(m => m.Id_message == index).FirstOrDefault() != null)
            {
                DataBinding.db.Messages_users.Remove(DataBinding.db.Messages_users.Where(m => m.Id_message == index).FirstOrDefault());
                DataBinding.db.SaveChanges();

                result = "Данные успешно удалены";
                
                return result;
            }
            else
            {
                result = "Неверный Id сообщения";

                return result;
            }
        }
    }
}
