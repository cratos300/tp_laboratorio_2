using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        public static double operar(Numero n1, Numero n2, string operador)
        {
            double dato;
            dato = Calculadora.Operador(n1, n2, operador);
            return dato;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Hernan Vilar del curso 2 °A";
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("/");
            comboBox1.Items.Add("*");
            comboBox1.SelectedIndex = 0;
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            label1.Text = "";
            comboBox1.Text = "+";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double dato;
             Numero PrimerNumero = new Numero(this.textBox2.Text);
            Numero SegundoNumero = new Numero(this.textBox3.Text);
            dato = FormCalculadora.operar(PrimerNumero, SegundoNumero, this.comboBox1.Text);
            label1.Text = dato.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dato;
            dato = label1.Text;
            Numero n1 = new Numero();
            label1.Text = n1.DecimalBinario(dato);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero();
            label1.Text = n1.BinarioDecimal(label1.Text);
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
