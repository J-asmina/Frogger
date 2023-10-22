using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger
{
    public partial class Igrica : Form
    {
        List<Rectangle> zabe;
        Rectangle ciljPravougaonik;
        List<Rectangle> braonPravougaonici;
        List<Rectangle> vodeniPravougaonici;
        Timer petljaIgre;
        bool jeKliknuto = false;
        int random_number = new Random().Next(1, 30);

        int ukupnoZaba; // Ukupan broj žaba
        int preziveleZabe; // Broj preživelih žaba

        public Igrica()
        {
            InitializeComponent();
            lblInfo.Visible = false;
            lblRezultat.Visible = false;
            zabe = new List<Rectangle>();
            ciljPravougaonik = new Rectangle(0, 0, this.Width, 20);
            braonPravougaonici = new List<Rectangle>();
            vodeniPravougaonici = new List<Rectangle>();

            ukupnoZaba = 0;
            preziveleZabe = 0;

            petljaIgre = new Timer();
            petljaIgre.Interval = 100;
            petljaIgre.Tick += PetljaIgre_Tick;

            petljaIgre.Start();
            KreirajBraonPravougaonike(200, 200);
            KreirajVodenePravougaonike(200, 200);
            KreirajBraonPravougaonike(300, 150);
            KreirajVodenePravougaonike(300, 150);
            KreirajBraonPravougaonike(400, 100);
            KreirajVodenePravougaonike(400, 100);
        }

        private void Igrica_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.OrangeRed), ciljPravougaonik);

            foreach (Rectangle vodeniPravougaonik in vodeniPravougaonici)
            {
                g.FillRectangle(new SolidBrush(Color.Aqua), vodeniPravougaonik);
            }

            foreach (Rectangle braonPravougaonik in braonPravougaonici)
            {
                g.FillRectangle(new SolidBrush(Color.SaddleBrown), braonPravougaonik);
            }

            foreach (Rectangle zaba in zabe)
            {
                g.FillRectangle(new SolidBrush(Color.Green), zaba);
            }
        }

        private void DobaviZabe()
        {
            int sirinaZabe = 40;
            int visinaZabe = 20;

            int brojZaba = this.Width / (sirinaZabe + 20);

            for (int i = 1; i < brojZaba; i++)
            {
                int x = i * (sirinaZabe + 20);
                int y = this.Height - (visinaZabe * 2);

                Rectangle zaba = new Rectangle(x, y, sirinaZabe, visinaZabe);
                zabe.Add(zaba);
            }

            ukupnoZaba = zabe.Count;

            this.Refresh();
        }

        private void KreirajBraonPravougaonike(int a, int sirina)
        {
            int sirinaBraonPravougaonika = sirina;
            int visinaBraonPravougaonika = 40;
            int razmak = sirina;

            int brojPravougaonika = (this.Width + razmak) / (sirinaBraonPravougaonika + razmak) + 1;

            for (int i = 0; i < brojPravougaonika; i++)
            {
                int x = i * (sirinaBraonPravougaonika + razmak);
                int y = this.Height - a;

                Rectangle braonPravougaonik = new Rectangle(x, y, sirinaBraonPravougaonika, visinaBraonPravougaonika);
                braonPravougaonici.Add(braonPravougaonik);
            }

            this.Refresh();
        }

        private void KreirajVodenePravougaonike(int a, int sirina)
        {
            int sirinaVodenogPravougaonika = sirina;
            int visinaVodenogPravougaonika = 40;
            int razmak = sirina;

            int brojPravougaonika = (this.Width + razmak) / (sirinaVodenogPravougaonika + razmak) + 1;

            for (int i = 0; i < brojPravougaonika; i++)
            {
                int x = i * (sirinaVodenogPravougaonika + razmak);
                int y = this.Height - a;

                Rectangle vodeniPravougaonik = new Rectangle(x + 100, y, sirinaVodenogPravougaonika, visinaVodenogPravougaonika);
                vodeniPravougaonici.Add(vodeniPravougaonik);
            }

            this.Refresh();
        }

        private void PetljaIgre_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < braonPravougaonici.Count; i++)
            {
                Rectangle braonPravougaonik = braonPravougaonici[i];
                braonPravougaonik.X -= random_number;

                if (braonPravougaonik.Right < 0)
                {
                    braonPravougaonik.X = this.Width;
                }

                braonPravougaonici[i] = braonPravougaonik;
            }

            for (int i = 0; i < vodeniPravougaonici.Count; i++)
            {
                Rectangle vodeniPravougaonik = vodeniPravougaonici[i];
                vodeniPravougaonik.X -= random_number;

                if (vodeniPravougaonik.Right < 0)
                {
                    vodeniPravougaonik.X = this.Width;
                }

                vodeniPravougaonici[i] = vodeniPravougaonik;

                for (int y = 0; y < zabe.Count; y++)
                {
                    Rectangle zaba = zabe[y];

                    // Samo se kreću žabe ako je igra počela
                    if (jeKliknuto == true)
                    {
                        lblInfo.Visible = false;
                        lblRezultat.Visible = false;
                        zaba.Y -= 5;
                        zabe[y] = zaba;
                        if (zaba.IntersectsWith(vodeniPravougaonik))
                        {
                            zabe.RemoveAt(y);
                            preziveleZabe = zabe.Count;
                        }
                        if (zaba.IntersectsWith(ciljPravougaonik))
                        {
                            lblInfo.Visible = true;
                            lblRezultat.Visible = true;
                            lblRezultat.Text = preziveleZabe.ToString();
                            btnStart.Enabled = true;
                            jeKliknuto = false;
                            zabe.Clear();
                        }
                    }
                }
            }

            this.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            jeKliknuto = true;
            DobaviZabe();
            preziveleZabe = 0;
            btnStart.Enabled = false;
        }
    }
}