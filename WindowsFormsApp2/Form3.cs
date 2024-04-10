using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string data = Tourist.ReadFromFile("TouristInfo.txt");
            richTextBox1.AppendText(data);
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            Service service4 = new Service("Service 4", 100);
            Service service5 = new Service("Service 5", 200);
            Service service6 = new Service("Service 6", 300);
            Country country3 = new Country("Country 3");
            Country country4 = new Country("Country 4");

            // Створення об'єктів класу Tourist та додавання їх до списку
            Tourist.Tourists.Add(new Tourist("Tourist 3", new List<Service> { service4, service5 }, country3));
            Tourist.Tourists.Add(new Tourist("Tourist 4", new List<Service> { service4, service6 }, country4));
            Tourist.Tourists.Add(new SpecialTourist("Special Tourist 2", new List<Service> { service4, service6 }, country4, new SpecialService("Special Service", 500)));


            Tourist.WriteToFile("touristData.txt");

            Tourist.DisplayTourists(richTextBox3);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            string data = Tourist.ReadFromFile("VipTouristInfo.txt");
            richTextBox2.AppendText(data);
        }
    }
}
