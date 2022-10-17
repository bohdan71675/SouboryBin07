using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouboryBin07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader("../../sport.txt");
            FileStream fs = new FileStream("../../sport.dat", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            BinaryReader br = new BinaryReader(fs);

            while (!streamReader.EndOfStream)
            {
                string s = streamReader.ReadLine();

                string[] slova = s.Split(';');

                int osc = int.Parse(slova[0]);
                bw.Write(osc);
                string jmeno = slova[1];
                bw.Write(jmeno);
                string prijmeni = slova[2];
                bw.Write(prijmeni);
                char pohlavi = char.Parse(slova[3]);
                bw.Write(pohlavi);
                int vyska = int.Parse(slova[4]);
                bw.Write(vyska);
                int hmotnost = int.Parse(slova[5]);
                bw.Write(hmotnost);
            }
            streamReader.Close();
            fs.Seek(0, SeekOrigin.Begin);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {

                int osc = br.ReadInt32();
                textBox1.Text += osc;
                textBox1.Text += " ";
                string jmeno = br.ReadString();
                textBox1.Text += jmeno;
                textBox1.Text += " ";
                string prijmeni = br.ReadString();
                textBox1.Text += prijmeni;
                textBox1.Text += " ";
                char pohlavi = br.ReadChar();
                textBox1.Text += pohlavi;
                textBox1.Text += " ";
                int vyska = br.ReadInt32();
                textBox1.Text += vyska;
                textBox1.Text += " ";
                int hmotnost = br.ReadInt32();
                textBox1.Text += hmotnost;
                textBox1.Text += "\r\n";

            }

            fs.Close();
        }
    }
}
