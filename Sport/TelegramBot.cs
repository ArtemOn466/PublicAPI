//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Telegram.Bot;
//using Telegram.Bot.Extensions;
//using Telegram.Bot.Types;
//using Telegram.Bot.Types.Enums;
//using Telegram.Bot.Types.ReplyMarkups;
//using Telegram.Bot.Extensions.Polling;
//using Telegram.Bot.Exceptions;
//using Sport.Clients;
//using Newtonsoft.Json;
//using Sport.Models;
//using Sport.Constants;
//using Sport.Controllers;
//using ReceiverOptions = Telegram.Bot.Extensions.Polling.ReceiverOptions;

//namespace TelegramBot
//{
//    public class Bot
//    {
//        TelegramBotClient botClient = new TelegramBotClient("5345950975:AAHb9uyKjv8ey9Ri69xnd3PCo7xheVJerXI");
//        CancellationToken cancellationToken = new CancellationToken();
//        ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
//        public async Task Start()
//        {
//            botClient.StartReceiving(HandlerUpdateAsync, HandlerError, receiverOptions, cancellationToken);
//            var botMe = await botClient.GetMeAsync();
//            Console.WriteLine($"Бот {botMe.Username} почав працювати");
//            Console.ReadKey();
//        }

//        private Task HandlerError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
//        {
//            var ErrorMessage = exception switch
//            {
//                ApiRequestException apiRequestException => $"Помилка в телеграм бот АПІ:\n {apiRequestException.ErrorCode}" +
//                $"\n{apiRequestException.Message}",
//                _ => exception.ToString()
//            };
//            Console.WriteLine(ErrorMessage);
//            return Task.CompletedTask;
//        }

//        private async Task HandlerUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
//        {
//            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
//            {
//                await HandlerMessageAsync(botClient, update.Message);
//            }
//            if (update?.Type == UpdateType.CallbackQuery)
//            {
//                await HandlerCallbackQuery(botClient, update.CallbackQuery);
//            }
//        }

//        private async Task HandlerCallbackQuery(ITelegramBotClient botClient, CallbackQuery? callbackQuery)
//        {
//            if (callbackQuery.Data.StartsWith("Managers"))
//            {
//                await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Find");
//                return;
//            }
//        }

//        private async Task HandlerMessageAsync(ITelegramBotClient botClient, Message message)
//        {
//            if (message.Text == "/start")
//            {
//                await botClient.SendTextMessageAsync(message.Chat.Id, "Hi!\n" +
//                    "Nice to see you here!\n" +
//                    "Let me introduce myself :)\n" +
//                    "I'm bot which can show some information that you want to know about football...almost\n" +
//                    "Well, I have such commands as /keyboard and /help\n" +
//                    "If you click on /help you will find useful information about correct types of inputs\n" +
//                    "If you click on /keyboard you will see all the functions that I can provide you\n" +
//                    "Now, let`s start!\n");


//                return;
//            }
//            else
//            if (message.Text == "/keyboard")
//            {
//                ReplyKeyboardMarkup replyKeyboardMarkup = new
//                    (
//                    new[]
//                        {
//                        new KeyboardButton [] { "Events", "Managers", "Referees"},
//                        new KeyboardButton [] { "Players", "Teams"}
//                        }
//                    )
//                {
//                    ResizeKeyboard = true
//                };
//                await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть пункт меню:", replyMarkup: replyKeyboardMarkup);
//                return;
//            }
//            else
//            if (message.Text == "Managers")
//            {
//                ReplyKeyboardMarkup replyKeyboardMarkup = new
//                (
//                     new KeyboardButton[] { "See the managers' list" }
//                )
//                {
//                    ResizeKeyboard = true
//                };
//                await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть пункт меню:", replyMarkup: replyKeyboardMarkup);
//                return;
//            }
//            else
//            if (message.Text == "See the managers' list")
//            {
//                Client client = new Client();
//                var managers = await client.GetManagerListAsync();
//                string result = "";
//                if (managers.data.ToArray().Length > 20)
//                {
//                    for (int i = 0; i < 20; i++)
//                    {
//                        if (managers.data[i].team != null)
//                            result += $" ID : {managers.data[i].id}\n Ім'я : {managers.data[i].name}\n Національність : {managers.data[i].nationality_code}\n Схема : {managers.data[i].preferred_formation}\n Команда : {managers.data[i].team.name}\n Перемоги : {managers.data[i].performance.wins}\n Поразки : {managers.data[i].performance.losses}\n Нічиї : {managers.data[i].performance.draws}\n Голів забито : {managers.data[i].performance.goals_scored}\n Голів пропущено : {managers.data[i].performance.goals_conceded}\n Кількість набраних очок : {managers.data[i].performance.total_points}\n\n";
//                        else
//                            continue;

//                    }
//                }


//                await botClient.SendTextMessageAsync(message.Chat.Id, " За вашим запитом знайдена наступна інформація...\n\n" + result);
//                return;
//            }
//            else
//            if (message.Text == "Events")
//            {
//                ReplyKeyboardMarkup replyKeyboardMarkup = new
//                    (
//                    new KeyboardButton[] { "Live", "Find by date" }
//                    )
//                {
//                    ResizeKeyboard = true
//                };
//                await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть пункт меню:", replyMarkup: replyKeyboardMarkup);
//                return;
//            }
//            else
//            if (message.Text == "Live")
//            {
//                Client client = new Client();
//                var liveevents = await client.GetEventLiveListAsync();
//                string result = "";
//                if (liveevents.data.ToArray().Length > 5)
//                {
//                    for (int i = 0; i < 5; i++)
//                    {
//                        try
//                        {
//                            result += $" Вид спорту : {liveevents.data[i].sport.name}\n Матч : {liveevents.data[i].name}\n Рахунок : {liveevents.data[i].home_score.current} - {liveevents.data[i].away_score.current}\n Розпочався : {liveevents.data[i].start_at}\n Назва ліги : {liveevents.data[i].league.name} \n Статус : {liveevents.data[i].status_more}\n \n";
//                        }
//                        catch
//                        {
//                        }

//                    }
//                }
//                await botClient.SendTextMessageAsync(message.Chat.Id, $" Наразі проходить {liveevents.data.Count} матчів, тому ми покажемо 5 перших, які знайшли найшвидше\n");
//                await botClient.SendTextMessageAsync(message.Chat.Id, " За вашим запитом знайдена наступна інформація...\n\n" + result);
//                return;
//            }
//            else
//            if (message.Text == "Find by date")
//            {
//                await botClient.SendTextMessageAsync(message.Chat.Id, " Введіть дату: \n");
//            }
//            else
//            if (message.Text.StartsWith("20"))
//            {
//                Client client = new Client();
//                string date = message.Text;
//                var eventbydate = await client.GetEventListByDateAsync(date);
//                string result = "";
//                if (eventbydate.data.ToArray().Length > 15)
//                {

//                    for (int i = 0; i < 15; i++)
//                    {
//                        try
//                        {
//                            if (eventbydate.data[i].sport.name == "Football")
//                            {
//                                result += $" Матч : {eventbydate.data[i].name}\n Відбувся : {eventbydate.data[i].start_at}\n Назва ліги : {eventbydate.data[i].league.name}\n Рахунок : {eventbydate.data[i].home_score.current} - {eventbydate.data[i].away_score.current}\n Сезон : {eventbydate.data[i].season.name}\n Вид спорту : {eventbydate.data[i].sport.name}\n\n";
//                            }
//                            else
//                                continue;

//                        }
//                        catch { }
//                    }
//                }
//                await botClient.SendTextMessageAsync(message.Chat.Id, " За вашим запитом знайдена наступна інформація...\n\n" + result);
//                return;
//            }
//            else
//            if (message.Text == "Players")
//            {
//                ReplyKeyboardMarkup replyKeyboardMarkup = new
//                (
//                     new KeyboardButton[] { "See the players' list" }
//                )
//                {
//                    ResizeKeyboard = true
//                };
//                await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть пункт меню:", replyMarkup: replyKeyboardMarkup);
//                return;
//            }
//            else
//            if (message.Text == "See the players' list")
//            {
//                Client client = new Client();
//                var players = await client.GetPlayerListAsync();
//                string result = "";
//                if (players.data.ToArray().Length > 20)
//                {
//                    for (int i = 0; i < 20; i++)
//                    {

//                        result += $" Ім'я : {players.data[i].name}\n Національність : {players.data[i].nationality_code}\n Позиція : {players.data[i].position_name}\n Вік : {players.data[i].age}\n Нога : {players.data[i].preferred_foot}\n\n";
//                    }
//                }
//                await botClient.SendTextMessageAsync(message.Chat.Id, " За вашим запитом знайдена наступна інформація...\n\n" + result);
//                return;
//            }
//            else
//            if (message.Text == "Teams")
//            {
//                ReplyKeyboardMarkup replyKeyboardMarkup = new
//                (
//                     new KeyboardButton[] { "See the teams' list" }
//                )
//                {
//                    ResizeKeyboard = true
//                };
//                await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть пункт меню:", replyMarkup: replyKeyboardMarkup);
//                return;
//            }
//            else
//            if (message.Text == "See the teams' list")
//            {
//                Client client = new Client();
//                var teams = await client.GetTeamListAsync();
//                string result = "";
//                if (teams.data.ToArray().Length > 20)
//                {
//                    for (int i = 0; i < 20; i++)
//                    {
//                        await botClient.SendPhotoAsync(message.Chat.Id, teams.data[i].logo);
//                        result += $" Назва : {teams.data[i].name}\n Країна : {teams.data[i].country}\n\n";
//                    }
//                }

//                await botClient.SendTextMessageAsync(message.Chat.Id, " За вашим запитом знайдена наступна інформація...\n\n" + result);
//                return;
//            }
//            else
//            if (message.Text == "Referees")
//            {
//                ReplyKeyboardMarkup replyKeyboardMarkup = new
//                (
//                     new KeyboardButton[] { "See the referees' list" }
//                )
//                {
//                    ResizeKeyboard = true
//                };
//                await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть пункт меню:", replyMarkup: replyKeyboardMarkup);
//                return;
//            }
//            else
//            if (message.Text == "See the referees' list")
//            {
//                Client client = new Client();
//                var referees = await client.GetRefereeListAsync();
//                string result = "";
//                if (referees.data.ToArray().Length > 20)
//                {
//                    for (int i = 0; i < 20; i++)
//                    {
//                        result += $" Ім'я : {referees.data[i].name}\n Країна : {referees.data[i].nationality_code}\n Жовті картки : {referees.data[i].yellow_cards}\n Червоні картки : {referees.data[i].red_cards}\n Кількість ігор : {referees.data[i].games}\n\n";
//                    }
//                }
//                await botClient.SendTextMessageAsync(message.Chat.Id, " За вашим запитом знайдена наступна інформація...\n\n" + result);
//                return;
//            }
           
//        }
//    }
//}

