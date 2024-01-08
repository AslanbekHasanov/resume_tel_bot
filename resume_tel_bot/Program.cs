
using System;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace resume_tel_bot
{
    class Program
    {
        private static TelegramBotClient telegramBotClient;
        private const string startCommand = "/start";
        private const string aboutMeCommand = "About me";
        private const string skillsCommand = "Skills"; 
        private const string languageCommand = "Languages"; 
        private const string contactCommand = "Contact me"; 
        private const string adminCommand = "About admin"; 
        private const string channelCommand = "About channel"; 
        private const string orqagaCommand = "Orqaga"; 

        static void Main(string[] args)
        {

            string token = @"MyBotToken";

            telegramBotClient = new TelegramBotClient(token);

            telegramBotClient.StartReceiving(HandleUpdate, HandleError);

            Console.ReadLine();

        }

        private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Message?.Type is MessageType.Text)
            {
                if (update.Message.Text is startCommand)
                {
                    var markupAdmin = MenuMarkupOne();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Welcome to Great Code",
                        replyMarkup: markupAdmin
                        );
                }

                if (update.Message.Text is adminCommand)
                {
                    var markup = MenuMarkup();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Welcome to Aslanbek's resume",
                        replyMarkup: markup
                        );
                }
                if (update.Message.Text is channelCommand)
                {

                    var photoPath = @"wwwroot/image/greatCode.jpg";

                    using (var photoStream = new FileStream(photoPath, FileMode.Open, FileAccess.Read))
                    {

                        var markupAdmin = MenuMarkupOne();
                        await client.SendPhotoAsync(
                        chatId: update.Message.Chat.Id,
                        photo: new InputFileStream(photoStream),
                        replyMarkup: markupAdmin,
                        caption: "Biz Shahrisabzda IT rivojlanishda o'z " +
                        "hissamizni qo'shish va IT olamidagi turli xil " +
                        "yunalishlarni targʻib qilgan holda, hozirgi" +
                        "zamonaviy IT kasblarini o'rganayotgan Shahrisabzdagi " +
                        "yoshlarni bir joyga jamlashni niyat qildik!"

                        );
                    }

                }
                if (update.Message.Text is orqagaCommand)
                {
                    var markupAdmin = MenuMarkupOne();
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Select command!",
                        replyMarkup: markupAdmin
                        );
                }
                if (update.Message?.Text is  aboutMeCommand)
                {
                    var photoPath = @"wwwroot/image/aslan.jpg";

                    using(var photoStream = new FileStream(photoPath,FileMode.Open, FileAccess.Read))
                    {
                        await client.SendPhotoAsync(
                        chatId: update.Message.Chat.Id,
                        photo: new InputFileStream(photoStream),
                        caption: "```I am a .Net Back End Developer, proficient at learning new technologies, designing modules, and```" +
                        "\r\n```integrating external APIs. Skilled in C#, Entity Framework Core, ORM and Dapper. Pursued bachelor```\r\n" +
                        "```degree at TUIT university in Karshi.```\r\n"

                        ) ;
                    }

                }
                if(update.Message?.Text is skillsCommand )
                {
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: $"C++\nBasic C#\n.Net Framework\n.Net Core\r\nMicrosoft Sql Server Management Studio\nDapper\r\nEntity Framework Core\n Rest Full Api\r\nPostgresql\nGitHub Postman\r\nVisual Studio\nAsp.NEt\nProblem "
                        );

                }
                if(update.Message?.Text is languageCommand)
                {
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: $"C++\nC#\nC\nPython\nJavaSkript"
                        );
                }
                if (update.Message?.Text is contactCommand)
                {
                    await client.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: $"@aslan_1220\n+998974638448\nShakhrisabz"
                        );
                }


            }
            else
            {
                await client.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    $"Please send only text message.");
            }

        }

        private static ReplyKeyboardMarkup MenuMarkupOne()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
                new KeyboardButton[]{new KeyboardButton("About admin"), new KeyboardButton("About channel") }
            })
            {
                ResizeKeyboard = true

            };
        }

        private static ReplyKeyboardMarkup MenuMarkup()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
                new KeyboardButton[]{new KeyboardButton("About me"),new KeyboardButton("Skills")},
                new KeyboardButton[]{new KeyboardButton("Languages"),new KeyboardButton("Contact me")},
                new KeyboardButton[]{new KeyboardButton("Orqaga")}
            })
            {
                ResizeKeyboard = true
            };
        }

        private static async Task HandleError(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            await client.SendTextMessageAsync(
                chatId: 1,
                $"Error: {exception.Message}");
        }
    }
}

