using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Створюємо екземпляр агентства
            TouristAgency agency = new TouristAgency();

            // Додаємо сервіси до агентства
            agency.AddService(new Service("Бронювання готелю", 1500.0));
            agency.AddService(new Service("Страхування подорожі", 500.0));
            agency.AddService(new Service("Екскурсія з гідом", 800.0));
            agency.AddService(new Service("Транспортні послуги", 1000.0));
            agency.AddService(new Service("Харчування", 700.0));

            // Отримуємо дані з текстових полів
            string name = materialTextBox1.Text;
            string Service = materialTextBox2.Text;
            string country = materialTextBox3.Text;

            // Перевіряємо, чи існує сервіс
            Service service = agency.Services.Find(s => s.Name == Service);

            if (service == null)
            {
                // Якщо сервіс не існує, виводимо повідомлення
                MessageBox.Show("Такого сервісу немає!");
            }
            else
            {
                // Створюємо нового туриста
                Tourist newTourist = new Tourist(name, new List<Service> { service }, new Country { Name = country });

                // Додаємо туриста до агентства
                agency.AddTourist(newTourist);

                // Записуємо дані туриста в файл
                string touristData = $"Ім'я: {name}, Сервіс: {Service}, Країна: {country}\n";
                File.AppendAllText("TouristInfo.txt", touristData);

                MessageBox.Show("Дані були успішно записані в файл!");
            }

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void materialButton2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}
