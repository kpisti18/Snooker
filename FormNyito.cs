using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Snooker
{
    public partial class FormNyito : Form
    {
        MySqlConnection con = null; //SQL kapcsolathoz
        MySqlCommand cmd = null; //SQL parancsokhoz
        List<Versenyzo> versenyzok = new List<Versenyzo>(); //az sql-hez a lista létrehozása
        /*
        //Oszlopok rendezéséhez
        private bool rendezes = false; // ha az oszlopok nevére klikkeléssel rendezni akarjuk a táblázatot, akkor kell egy "villanykapcsoló", ami megmutatja, hogy épp fel vagy le van-e kapcsolva a villany (növekvő vagy csökkenő sorrend vagy abc vagy cba sorrend...)
        private int oszlopNeve;
        */

        public FormNyito()
        {
            InitializeComponent();
        }

        private void FormNyito_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost"; //127.0.0.0-et is megadhatjuk
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "snooker";

            con = new MySqlConnection(sb.ConnectionString);

            oszlopokMeghatarozasa();
            versenyzokBeolvasasa();
            adattablaFrissit();
        }

        private void versenyzokBeolvasasa()
        {
            versenyzok.Clear(); //ha van újabb adatbázis, akkor törli a lista tartalmát, és feltöltjük a legfrissebb adatokkal

            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = $"SELECT * FROM `snooker`;";

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        try //hibakezelés a Versenyzo osztály tulajdonságainak ellenőrzéséhez
                        {
                            versenyzok.Add(new Versenyzo(dr.GetInt32("Helyezes"), dr.GetString("Nev"), dr.GetString("Orszag"), dr.GetDecimal("Nyeremeny")));
                        }
                        catch (ArgumentException ex) 
                        {
                            MessageBox.Show($"Az alábbi hiba lépett fel:\n{ex.Message}");
                        }
                    }
                }  
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Az alábbi hiba lépett fel:\n{ex.Message}");
                Environment.Exit(0); //leállítjuk a programot, ha hiba van a kapcsolódással
            }
        }

        private void adattablaFrissit()
        {
            dataGridViewVersenyzo.Rows.Clear(); //kitörli az adattábla tartalmát

            foreach (Versenyzo item in versenyzok)
            {
                int sorszam = dataGridViewVersenyzo.Rows.Add(); //-- létrehozzuk a sort és letároljuk a sorszámát, ez egy int értéket ad vissza (a sornak a sorszámát, 0-tól indul, és megy fölfele)
                DataGridViewRow sor = dataGridViewVersenyzo.Rows[sorszam]; //ezzel a tulajdonságokat, értékeket is beállítjuk az egész sorból, mivel azokat áthozza majd a listából
                sor.Cells["helyezes"].Value = item.Helyezes; //a sor celláihoz hozzáadjuk a megfelelő nevű cellának az épp aktuális értékét
                sor.Cells["nev"].Value = item.Nev;
                sor.Cells["orszag"].Value = item.Orszag;
                sor.Cells["nyeremeny"].Value = item.Nyeremeny;
            }
        }

        //táblázat megrajzolása
        private void oszlopokMeghatarozasa()
        {
            //-- a táblázat általános tulajdonságai
            dataGridViewVersenyzo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //ha nem fér el a formon, akkor nem is látható
            dataGridViewVersenyzo.MultiSelect = false; //több cellakijelölést letiltunk
            dataGridViewVersenyzo.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //ezzel pl ha rákattintunk egy elemre, akkor az egész sort kijelöli, nem csak 1 karaktert, vagy szót

            //- oszlopok tulajdonságainak a beállítása
            // 1. oszlop: Helyezés
            DataGridViewColumn colHelyezes = new DataGridViewColumn();
            {
                colHelyezes.Name = "helyezes"; //oszlopnév a helyezés, ezt a cella módosításához és azonosításához használjuk
                colHelyezes.HeaderText = "Helyezés"; //oszlop felirata, ezt fogja látni a felhasználó
                colHelyezes.CellTemplate = new DataGridViewTextBoxCell();  //különböző típusú cellákat tudunk létrehozni (ismeri a date-et is)
                colHelyezes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //cellák igazítása
            }

            dataGridViewVersenyzo.Columns.Add(colHelyezes); //az insert egy adott helyre szúr be, az add meg hozzáadja

            //2. oszlop: Név
            DataGridViewColumn colNev = new DataGridViewColumn();
            {
                colNev.Name = "nev";
                colNev.HeaderText = "Név";
                colNev.CellTemplate = new DataGridViewTextBoxCell();
                colNev.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; 
            }

            dataGridViewVersenyzo.Columns.Add(colNev);

            //3. oszlop: Ország
            DataGridViewColumn colOrszag = new DataGridViewColumn();
            {
                colOrszag.Name = "orszag";
                colOrszag.HeaderText = "Ország";
                colOrszag.CellTemplate = new DataGridViewTextBoxCell();
                colOrszag.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            dataGridViewVersenyzo.Columns.Add(colOrszag);

            //4. oszlop: Nyeremény
            DataGridViewColumn colNyeremeny = new DataGridViewColumn();
            {
                colNyeremeny.Name = "nyeremeny";
                colNyeremeny.HeaderText = "Nyeremény";
                colNyeremeny.CellTemplate = new DataGridViewTextBoxCell();
                colNyeremeny.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dataGridViewVersenyzo.Columns.Add(colNyeremeny);
        }

        // ha bárhova kattintok a táblázatba, akkor az egész sort válassza ki, ehhez a design-ban a dataGridViewVersenyzo-nél keresd meg a SelectionChanged eseményt
        private void dataGridViewVersenyzo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewVersenyzo.SelectedRows.Count == 0) //ez a módosítás gombhoz kell, mert a módosításnál nem feltétlen lesz kiválasztott sor
            {
                return; //ha nincs, akkor visszatér
            }
            DataGridViewRow kivalsztottSor = dataGridViewVersenyzo.SelectedRows[0]; //mivel nincs simán row, ezért az összes sort fogja nézni, onnan is az első elemet
            if (kivalsztottSor.Cells["helyezes"].Value != null) //
            {
                tbHelyezes.Text = kivalsztottSor.Cells["helyezes"].Value.ToString(); //a kiválasztott szöveg celláinál a helyezés cellának értékét string-é alakítva belerakjuk a szövegdobozba
                tbNev.Text = kivalsztottSor.Cells["nev"].Value.ToString();
                cbOrszag.Text = kivalsztottSor.Cells["orszag"].Value.ToString();
                numericUpDownNyeremeny.Value = decimal.Parse(kivalsztottSor.Cells["nyeremeny"].Value.ToString());
            }
        }

        private void btModosit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Parameters.Clear();
                cmd = con.CreateCommand();
                // a @ azt jelzi, hogy fog kapni valamilyen paramétert később
                // a paraméterek soha nem nullázódnak ki, ezért két sorral feljebb töröljük ki a cmd.Parameters.Clear();-t
                // parancsot meghatározzuk, a paramétereket nem szabad " vagy ' közé tenni
                cmd.CommandText = $"UPDATE `snooker` SET `Nyeremeny`= @osszeg WHERE `Helyezes`= @id;";
                // végrehajtáshoz szükséges adatokat átadjuk
                cmd.Parameters.AddWithValue("@id", tbHelyezes.Text); //hozzáadjuk a paramétereket honnan kell vennie, szereti ha string formátum
                cmd.Parameters.AddWithValue("@osszeg", numericUpDownNyeremeny.Value); //ez szám típus
                // végrehajtjuk az utasítást, de előbb vizsgáljuk meg a visszatérési értéket
                if (cmd.ExecuteNonQuery() == 1) //ha csak 1 helyen történt a módosítás, mivel metódust vizsgálunk, végre is hajtódik az cmd.ExecuteNonQuery()
                {
                    MessageBox.Show("A nyeremény módosítása megtörtént.");
                    tbHelyezes.Text = ""; //kinullázzuk az értékeket
                    tbNev.Text = "";
                    cbOrszag.Text = "";
                    numericUpDownNyeremeny.Value = numericUpDownNyeremeny.Minimum; //az alsó értékre állítjuk vissza
                }
                else
                {
                    MessageBox.Show("Sikertelen");
                }

                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Az alábbi hiba lépett fel:\n{ex.Message}");
                Environment.Exit(0); //leállítjuk a programot, ha hiba van a kapcsolódással
            }
            versenyzokBeolvasasa(); //a listát is törli
            adattablaFrissit();
        }

        /* Oszlopok rendezése
        //ha az oszlopok nevére klikkeléssel rendezni akarjuk a táblázatot, akkor kell hozzá ez a klikk esemény
        private void dataGridViewVersenyzo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                oszlopNeve = dataGridViewVersenyzo.Columns[e.ColumnIndex].Index;
                
                dataGridViewVersenyzo.DataSource = versenyzokBeolvasasaRendezve();
                adattablaFrissit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        
        private List<Versenyzo> versenyzokBeolvasasaRendezve()
        {
            versenyzok.Clear();

            try
            {
                con.Open();
                cmd = con.CreateCommand();

                if (rendezes)
                {
                    cmd.CommandText = $"SELECT * FROM `snooker` ORDER BY {dataGridViewVersenyzo.Columns[oszlopNeve].Name} ASC;";

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            try
                            {
                                versenyzok.Add(new Versenyzo(dr.GetInt32("Helyezes"), dr.GetString("Nev"), dr.GetString("Orszag"), dr.GetDecimal("Nyeremeny")));
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show($"Az alábbi hiba lépett fel:\n{ex.Message}");
                            }
                        }
                    }
                }
                else
                {
                    cmd.CommandText = $"SELECT * FROM `snooker` ORDER BY {dataGridViewVersenyzo.Columns[oszlopNeve].Name} DESC;";

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            try
                            {
                                versenyzok.Add(new Versenyzo(dr.GetInt32("Helyezes"), dr.GetString("Nev"), dr.GetString("Orszag"), dr.GetDecimal("Nyeremeny")));
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show($"Az alábbi hiba lépett fel:\n{ex.Message}");
                            }
                        }
                    }
                }
                con.Close();
                rendezes = !rendezes;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Az alábbi hiba lépett fel:\n{ex.Message}");
                Environment.Exit(0);
            }
            return versenyzok;
        }
        */
    }
}
