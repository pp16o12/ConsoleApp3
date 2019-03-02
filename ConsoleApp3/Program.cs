using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
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

        private static async void getQueryMess(object sender, CallbackQueryEventArgs e)
        {
            switch (e.CallbackQuery.Data.ToLower())
            {
                case "/taverna":
                    {
                        Console.WriteLine("asd");

                        List<InlineKeyboardButton> btns = new List<InlineKeyboardButton>();
                        btns.Add(new InlineKeyboardButton() { CallbackData = "/home", Text = "В город" });
                        btns.Add(new InlineKeyboardButton() { CallbackData = "/buhat", Text = "Напиться в стельку"});

                  
                        var klava = new InlineKeyboardMarkup(btns);
                        await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "https://images.stopgame.ru/uploads/images/222710/form/normal_1301827588.jpg", "бу-га-га!", replyMarkup: klava);
                        break;
                    }
                case "/buhat":
                    {
                   
                        await botClient.SendPhotoAsync(e.CallbackQuery.Message.Chat.Id, "http://www.gamer.ru/system/attached_images/images/000/641/329/original/63241677.jpg", "бу-га-га!");
                        break;
                    }
            }
        }

        private static async Task getMainGamePage(Message userMsg)
        {
       
            InlineKeyboardButton b = new InlineKeyboardButton();
            b.Text = "В таверну";
            b.CallbackData = "/taverna";

            var klava = new InlineKeyboardMarkup(b);
            await botClient.SendTextMessageAsync(userMsg.Chat.Id, "-", replyMarkup: klava);
          
        }

     

        private static async void getMessage(object sender, MessageEventArgs e)
        {
            switch (e.Message.Text)
            {
                case "/start":
                    {
                        await botClient.SendPhotoAsync(e.Message.Chat.Id, "http://klan-voin.at.ua/Kartinki/cs1x1ak6.jpg", $"Добро пожаловать, в мою игру!");
                        await getMainGamePage(e.Message);
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
