using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp3
{
    class Program
    {
        static TelegramBotClient botClient;
        readonly static string connectionString = @"Data Source=10.2.2.212;Initial Catalog=ptpjam_db;Persist Security Info=True;User ID=student;Pooling=False";
        static void Main(string[] args)
        {
            try
            {
                botClient = new TelegramBotClient("645940537:AAH1MIdux32JpkX0XIsz3jkp7k30RQfVx6E");
                var bot = botClient.GetMeAsync().Result;


                botClient.OnMessage += getMessage;
                botClient.OnCallbackQuery += getQueryMess;
                botClient.StartReceiving();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        private static void getQueryMess(object sender, CallbackQueryEventArgs e)
        {
            switch (e.CallbackQuery.Data.ToLower())
            {
                case "/taverna":
                    {
                        Console.WriteLine("asd");
                        botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "https://images.stopgame.ru/uploads/images/222710/form/normal_1301827588.jpg", "бу-га-га!");
                        break;
                    }
            }
        }

        private static async Task getMainGamePage(Chat userChat)
        {
            InlineKeyboardButton b = new InlineKeyboardButton();
            b.Text = "В таверну";
            b.CallbackData = "/taverna";

            var klava = new InlineKeyboardMarkup(b);
            await botClient.SendTextMessageAsync(userChat.Id, "-", replyMarkup: klava);
        }

        private static async void getMessage(object sender, MessageEventArgs e)
        {
            switch (e.Message.Text)
            {
                case "/start":
                    {
                        await botClient.SendPhotoAsync(e.Message.Chat.Id, "http://klan-voin.at.ua/Kartinki/cs1x1ak6.jpg", $"Добро пожаловать, в мою игру!");
                        await getMainGamePage(e.Message.Chat);
                        break;
                    }
                default:
                    break;
            }


            /*
             * смайлы брать тут
             * https://ru.piliapp.com/facebook-symbols/
             */
        }
    }
}
