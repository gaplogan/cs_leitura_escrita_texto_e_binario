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

namespace LeituraEscrita
{
    public partial class Form1 : Form
    {
        byte[] buffer;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(@"c:\curso\arquivo.txt", true);
            try
            {
                writer.Write(txtConteudo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
            finally
            {
                writer.Flush();
                writer.Dispose();
                writer.Close();
            }

            txtConteudo.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtConteudo.Clear();

            StreamReader reader = new StreamReader(@"c:\curso\arquivo.txt");
            try
            {
                //txtConteudo.Text = reader.ReadToEnd();

                //string linha = reader.ReadLine();
                //while (linha != null)
                //{
                //    txtConteudo.Text += linha + "\n";
                //    linha = reader.ReadLine();
                //}

                while (!reader.EndOfStream)
                {
                    txtConteudo.Text += (char)reader.Read();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
            finally
            {
                reader.Dispose();
                reader.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtConteudo.Clear();

            //BinaryReader binReader = new BinaryReader(File.OpenRead(@"c:\curso\arquivo.txt"));
            //BinaryReader binReader = new BinaryReader(File.OpenRead(@"c:\curso\audio.mp3"));
            //BinaryReader binReader = new BinaryReader(File.OpenRead(@"c:\curso\imagem.png"));
            BinaryReader binReader = new BinaryReader(File.OpenRead(@"c:\curso\video.mp4"));
            try
            {
                //while (binReader.BaseStream.Position != binReader.BaseStream.Length)
                //{
                //    txtConteudo.Text += binReader.ReadByte() + " ";
                //}

                //foreach (var b in binReader.ReadBytes((int)binReader.BaseStream.Length))
                //{
                //    txtConteudo.Text += b;
                //}


                //buffer = binReader.ReadBytes((int)binReader.BaseStream.Length);

                buffer = new byte[(int)binReader.BaseStream.Length];
                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = binReader.ReadByte();
                    //txtConteudo.Text += buffer[i] + " ";
                }

                //buffer = File.ReadAllBytes(@"c:\curso\imagem.png");

                //foreach (byte b in buffer)
                //{
                //    txtConteudo.Invoke(new Action(() => txtConteudo.Text += b));
                //}

                MessageBox.Show("Finalizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
            finally
            {
                binReader.Dispose();
                binReader.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //BinaryWriter binWriter = new BinaryWriter(File.OpenWrite(@"c:\curso\arquivo2.txt"));
            //BinaryWriter binWriter = new BinaryWriter(File.OpenWrite(@"c:\curso\audio2.mp3"));
            //BinaryWriter binWriter = new BinaryWriter(File.OpenWrite(@"c:\curso\imagem2.png"));
            BinaryWriter binWriter = new BinaryWriter(File.OpenWrite(@"c:\curso\video2.mp4"));
            try
            {
                //binWriter.Write(txtConteudo.Text);
                binWriter.Write(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
            }
            finally
            {
                binWriter.Flush();
                binWriter.Dispose();
                binWriter.Close();
            }

            txtConteudo.Text = "";
        }
    }
}
