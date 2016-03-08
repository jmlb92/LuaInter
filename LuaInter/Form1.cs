using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicLua;


namespace LuaInter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            try
            {
                dynamic lua = new DynamicLua.DynamicLua();
                lua("test='Hola soy texto en una variable de Lua, me asigno a este textbox.'");
                lua(textBox1.Text += lua.test);
            }
            catch (Exception err)
            {

                Console.WriteLine(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            try
            {
                textBox1.Text += "Los ejemplos estan en el output";
                dynamic lua = new DynamicLua.DynamicLua();
                lua("print('hello world')"); // => hello world
                double answer = lua("return 42");
                Console.WriteLine(answer); // => 42
                var arg = 5;
                lua("function luafunction(a) return a + 1 end");
                dynamic answer2 = lua.luafunction(arg);
                Console.WriteLine(answer2); // => 6
                //Console.ReadKey();
            }
            catch (Exception err)
            {

                Console.WriteLine(err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            string s = @"luanet.load_assembly ""System.Windows.Forms""
Form = luanet.import_type ""System.Windows.Forms.Form""

form = Form()
form.Text = ""Hola, soy un form""
form:ShowDialog()";
            textBox1.Text = s;
            
            try
            {
                dynamic lua = new DynamicLua.DynamicLua();
                lua(textBox1.Text);
            }
            catch (Exception)
            {
                
                //throw;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            string s = @"luanet.load_assembly ""System.Windows.Forms""
Form = luanet.import_type ""System.Windows.Forms.Form""
Button = luanet.import_type ""System.Windows.Forms.Button""
Label = luanet.import_type ""System.Windows.Forms.Label""
TextBox = luanet.import_type ""System.Windows.Forms.TextBox""
MessageBox = luanet.import_type ""System.Windows.Forms.MessageBox""


form = Form()
form.Text = ""Hola, Soy Otro Form""

button = Button()
button.Text = ""Mostrar""
button.Left = 100
button.Click:Add(function()
    MessageBox.Show(textbox.Text)
end)

form.Controls:Add(button)

textbox = TextBox()
form.Controls:Add(textbox)

label = Label()
label.Text = ""Probando""
form.Controls:Add(label)

form:ShowDialog()
";
            textBox1.Text = s;

            try
            {
                dynamic lua = new DynamicLua.DynamicLua();
                //lua.Load_Assembly("System.Drawing");
                lua(textBox1.Text);
                
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            string s = @"luanet.load_assembly ""System.Windows.Forms""
Form = luanet.import_type ""System.Windows.Forms.Form""
Button = luanet.import_type ""System.Windows.Forms.Button""
Label = luanet.import_type ""System.Windows.Forms.Label""
TextBox = luanet.import_type ""System.Windows.Forms.TextBox""
MessageBox = luanet.import_type ""System.Windows.Forms.MessageBox""

form = Form()
form.Text = ""Hola, Soy Un Form Que Suma""
button = Button()
button.text = ""Click Me!!""
label = Label();
label2 = Label();
label3 = Label();
label.text = ""Sumemos""
label2.text = ""Numero 1:""
label3.text = ""Numero 2:""
text = TextBox()
text2 = TextBox()

button.Click:Add(function()
local a = tonumber(text.Text)
local b = tonumber(text2.Text)
local c = a + b
MessageBox.Show(c)
end)


form.Controls:Add(label)
form.Controls:Add(label2)
form.Controls:Add(label3)
form.Controls:Add(text)
form.Controls:Add(text2)
form:ShowDialog()

";
            textBox1.Text = s;

            try
            {
                dynamic lua = new DynamicLua.DynamicLua();
                lua(textBox1.Text);
                
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}
