using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1AuthorizationApp.Base
{
    /// <summary>
    /// Работа с БД
    /// </summary>
    public class AppData
    {
        private static TelekomNevaSvyazDBEntities context;

        /// <summary>
        /// Получение контекста данных
        /// </summary>
        /// <returns> Модель данных </returns>
        public static TelekomNevaSvyazDBEntities GetContext()
        {
            if (context == null)
                context = new TelekomNevaSvyazDBEntities();

            return context;
        }

        /// <summary>
        /// Текущий сотрудник системы
        /// </summary>
        public static Employees CurrentEmployee { get; set; }
    }
}
