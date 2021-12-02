using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OssBssSystem
{
    using Base;
    using System.Windows;

    /// <summary>
    /// Класс для импорта данных
    /// </summary>
    public class ImportData
    {
        #region Импорт абонентов
        /// <summary>
        /// Импорт абонентов
        /// </summary>
        public static void ImportClients()
        {
            List<JsonItem> jsonItems = new List<JsonItem>();

            using (StreamReader r = new StreamReader(@"C:\Users\Asus\Desktop\Томский WSR\Сессия 2\Сессия 2\Абоненты\Адреса абонентов.json"))
            {
                string json = r.ReadToEnd();
                JsonList list = JsonConvert.DeserializeObject<JsonList>(json);
                jsonItems = list.data.ToList();
            }

            var fileData = File.ReadAllLines(@"C:\Users\Asus\Desktop\Томский WSR\Сессия 2\Сессия 2\Абоненты.txt");

            foreach (var line in fileData)
            {
                var dataLine = line.Split('\t');

                try
                {
                    Client client = new Client()
                    {
                        ID = dataLine[0],
                        FullName = dataLine[1],
                        GenderID = Convert.ToByte(dataLine[2]),
                        BirthDate = Convert.ToDateTime(dataLine[3]),
                        TelNumber = dataLine[4],
                        Email = dataLine[5],
                        ResindaceAddress = dataLine[6],
                        Pasport = dataLine[8],
                        Code = dataLine[9],
                        PasportPlace = dataLine[10],
                        PasportDate = Convert.ToDateTime(dataLine[11]),
                        LicevoySchet = dataLine[12]
                    };

                    var address = jsonItems.Where(p => p.number == dataLine[7]).FirstOrDefault();
                    var raion = AppData.GetContext().AddressRaions.FirstOrDefault(p => p.Name == address.raion);

                    client.AddressCode = address.prefix_code;
                    client.AddressPrefix = address.prefix;
                    client.AddressHouse = address.house;
                    client.AddressRaion = raion.ID;

                    AppData.GetContext().Client.Add(client);
                }
                catch
                {
                    continue;
                }
            }

            try
            {
                AppData.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Импорт сотрудников с фото

        /// <summary>
        /// Импорт сотрудников
        /// </summary>
        public static void ImportEmployess()
        {
            var fileData = File.ReadAllLines(@"C:\Users\Asus\Desktop\Томский WSR\Сессия 2\Сессия 2\Сотрудники\Сотрудники ТНС.txt");

            var images = Directory.GetFiles(@"C:\Users\Asus\Desktop\Томский WSR\Сессия 2\Сессия 2\Сотрудники");

            foreach (var line in fileData)
            {
                var dataLine = line.Split('\t');

                Employees employee = new Employees()
                {
                    ID = Convert.ToInt32(dataLine[0]),
                    FullName = dataLine[1],
                    EmployeeRoleID = Convert.ToInt32(dataLine[2])
                };

                employee.Photo = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(dataLine[0])));

                AppData.GetContext().Employees.Add(employee);
            }

            try
            {
                AppData.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }
}
