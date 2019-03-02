using System;
using Telegram.Bot;
using Telegram.Bot.Args;

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
                Console.WriteLine(bot.Username);

                botClient.OnMessage += getMessage;
                botClient.StartReceiving();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }


        private static async void getMessage(object sender, MessageEventArgs e)
        {
            await botClient.SendPhotoAsync(e.Message.Chat.Id, "https://images.techhive.com/images/article/2016/12/error-100700406-large.jpg", $"🎈Type '{e.Message.Type.ToString()}' is not supporting!");
            
            /*
             * смайлы брать тут
             * https://ru.piliapp.com/facebook-symbols/
             */
        }
    }
}
