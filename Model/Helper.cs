using System;
using System.Collections.Generic;

namespace Model
{
    public static class Helper
    {
        public static int port = 8000;
        public static int maxPlayers = 6;
        public static string messageQueueAddress = "234.1.1.1:8000";

        private static List<string> names = new List<string>()
        {
            "Алексей",
            "Татьяна",
            "Егор",
            "Степан",
            "Яков",
            "Сергей",
            "Александр",
            "Петр",
            "Иван",
            "Антон",
            "Анатолий",
            "Светлана",
            "Григорий"
        };

        public static string GetName()
        {
            Random random = new Random();
            return names[random.Next(names.Count)];
        }
    }
}
