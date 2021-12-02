using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssBssSystem.Base
{
    /// <summary>
    /// Работа с БД
    /// </summary>
    public class AppData
    {
        private static TelekomNevaSvyazDBEntities context;
        public static TelekomNevaSvyazDBEntities GetContext()
        {
            if (context == null)
                context = new TelekomNevaSvyazDBEntities();
            return context;
        }
    }
}
