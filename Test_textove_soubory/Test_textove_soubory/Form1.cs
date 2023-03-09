using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_textove_soubory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int CZK()
        {
            double kurz = 22.34;
            double koruny = 0;
            for (int i = 0; i <= 100; i++)
            {
                koruny = salary[i] * kurz;
            }
            return Convert.ToInt32(koruny);
        }

        OpenFileDialog otevirac;
        StreamReader ctenar;
        StreamWriter zapisovac;
        int[] salary;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            otevirac = new OpenFileDialog();
            otevirac.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            int MaxMzda = 0;
            int MinMzda = 17300;
            if(otevirac.ShowDialog() == DialogResult.OK)
            {
                ctenar = new StreamReader(otevirac.FileName, Encoding.GetEncoding("windows-1250"));
                zapisovac = new StreamWriter("@../../best.txt", true, Encoding.GetEncoding("windows-1250"));
                string text;
                int i = 0;
                int zeny = 0;
                /*while (!ctenar.EndOfStream)
                {
                    text = ctenar.ReadLine();
                    text.Replace("\"", "");
                    while (splitCount != 4)
                    {
                        text.Split(',');
                        splitCount++;
                    }
                    salary[i] = Convert.ToInt32(text);
                    i++;
                }*/
                while (!ctenar.EndOfStream)
                {
                    text = ctenar.ReadLine();
                    text = text.Replace("\"","");
                    string[] slova;
                    listBox1.Items.Add(text);
                    slova = text.Split(',');
                    salary[i] = Convert.ToInt32(slova[4]);
                    if (slova[3] == "Female")
                    {
                            zeny++;
                        
                    }
                    if (salary[i] > MaxMzda)
                    {
                        MaxMzda = salary[i];
                    }
                    if(salary[i]<MinMzda)
                    {
                        listBox2.Items.Add(text);
                    }
                    i++;
                    zapisovac.Write(CZK() + "\n");
                }
                MessageBox.Show("Počet vygenerovaných žen:" + zeny.ToString());
                
            }
        }
        
    }

    
}
