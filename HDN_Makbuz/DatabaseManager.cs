using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace HDN_Makbuz
{
    public sealed class DatabaseManager
    {
        private static DatabaseManager instance = null;
        private static readonly object padlock = new object();

        public delegate void ThrowExceptionToInterface(Exception e);
        public event ThrowExceptionToInterface ExceptionThrown;

        private SQLiteConnection conn;

        public static string databaseName = "HDN.db";

        public enum SINIFLAR { SIFIR_IKI, UC, DORT, BES_ALTI }
        public enum CINSIYET { ERKEK, KIZ }
        public enum AKTIFLIK { PASIF, AKTIF }
        public enum GELME_DUZENI { TAM_GUN }

        public static readonly string cocuk_tablosu_adi = "Cocuklar";
        public static readonly string makbuz_tablosu_adi = "Makbuzlar";
        public static readonly string ayarlar_tablosu_adi = "Ayarlar";

        public static string baglanti = "Data Source=" + databaseName + ";Version=3;";

        private static List<Cocuk_Bilgileri> cocuklar_bilgileri ;
        private static List<Makbuz_Bilgileri> makbuzlar_bilgileri;
        public static double kdv = 8.0;

        public Cocuk_Bilgileri Cocuk_Al(int indis)
        {
            return cocuklar_bilgileri.Where(f => f.id == indis).First();
        }

        public List<Cocuk_Bilgileri> Cocuklar
        {
            get
            {
                if (cocuklar_bilgileri == null) { cocuklar_bilgileri = new List<Cocuk_Bilgileri>(); }

                cocuklar_bilgileri = Cocuklari_Al();
                cocuklar_bilgileri.Sort((a, b) => a.cocuk_adi.CompareTo(b.cocuk_adi));
                return cocuklar_bilgileri;
            }
            set => cocuklar_bilgileri = value;
        }

        public List<Makbuz_Bilgileri> Makbuzlar
        {
            get
            {
                if (makbuzlar_bilgileri == null) { makbuzlar_bilgileri = new List<Makbuz_Bilgileri>(); }

                makbuzlar_bilgileri = Makbuzlari_Al();
                return makbuzlar_bilgileri;
            }
            set => makbuzlar_bilgileri = value;

        }

        public void Cocuklari_Kaydet()
        {
            foreach(var cocuk in cocuklar_bilgileri)
            {
                if (cocuk.guncelle == true)
                {
                    string sql = "update " + cocuk_tablosu_adi + " set " +
                    "Cocuk_Adi = '" + cocuk.cocuk_adi + "' ," +
                    "Cocuk_Adresi = '" + cocuk.adres + "' ," +
                    "Cocuk_TC_No = '" + cocuk.tc_no + "' ," +
                    "Aylik_Ucret_Carpi_Yuz = " + (int)(cocuk.aylik_ucret * 100) + " ," +
                    "Cocuk_Duzen = '" + cocuk.duzen_metin + "' ," +
                    "Sinif = " + (int)cocuk.sinif + " ," +
                    "Cinsiyet = " + (int)cocuk.cinsiyet + " ," +
                    "Aktif = " + (int)cocuk.aktif_mi +
                    " where ID = " + cocuk.id + " ;";

                    (new SQLiteCommand(sql, conn)).ExecuteNonQuery();
                }
            }
        }

        public void KDV_Kaydet(double kdv)
        {
            string sql = "update " + ayarlar_tablosu_adi + " set " +
                    "KDV_CARPI_YUZ = " + kdv * 100 +
                    " where ID = 0;";

            runCommand(sql);
        }

        public float KDV_Al()
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select COUNT(*) from " + ayarlar_tablosu_adi + ";";
            cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                return Convert.ToSingle((dr["KDV_CARPI_YUZ"]));
            }

            cmd.CommandText = "select * from " + ayarlar_tablosu_adi + ";";
            cmd.ExecuteNonQuery();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                return Convert.ToSingle((dr["KDV_CARPI_YUZ"]));
            }
            return 0f;
        }

        public static DatabaseManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseManager();
                    }
                    return instance;
                }
            }
        }

        internal int Cocuk_Ekle(string cocuk_adi, string adres, string cocuk_TC_no, string duzen_metin, double aylik_ucret, SINIFLAR sinif, CINSIYET cinsiyet)
        {
            try
            {
                string sql1 = "insert into " + cocuk_tablosu_adi +" values (NULL, '"
                        + cocuk_adi + "','"
                        + adres + "','"
                        + cocuk_TC_no + "',"
                        + (aylik_ucret * 100) + ",'"
                        + duzen_metin + "',"
                        + (int)sinif + ","
                        + (int)cinsiyet + ","
                        + (int)AKTIFLIK.AKTIF + ")";

                (new SQLiteCommand(sql1, conn)).ExecuteNonQuery();


                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from " + cocuk_tablosu_adi + " where Cocuk_Adi = '" + cocuk_adi + "' AND Cocuk_TC_No = '" + cocuk_TC_no + "'";
                cmd.ExecuteNonQuery();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return Convert.ToInt32((dr["ID"]));
                }
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionThrown?.Invoke(ex);
                return 0;
            }
        }

        internal int Makbuz_Ekle(string sira_no, DateTime tarih, string irsa, int cocuk_id, double kdv)
        {
            try
            {
                string sql1 = "insert into " + makbuz_tablosu_adi + " values (NULL, '"
                        + sira_no + "','"
                        + tarih.ToString("dd.MM.yyyy") + "','"
                        + irsa + "',"
                        + kdv * 100 + ","
                        + cocuk_id + ")";

                (new SQLiteCommand(sql1, conn)).ExecuteNonQuery();

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from " + makbuz_tablosu_adi + " where Sira_No = '" + sira_no + "' AND Duzenlenme_Tarihi = '" + tarih.ToString("dd.MM.yyyy") + "'";
                cmd.ExecuteNonQuery();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return Convert.ToInt32((dr["ID"]));
                }
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionThrown?.Invoke(ex);
                return 0;
            }
        }

        public bool Is_db_connected()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void connectDatabase()
        {
            //File.Delete(databaseName);
            try
            {
                if (!File.Exists(databaseName))
                {
                    SQLiteConnection.CreateFile(databaseName);
                }

                conn = new SQLiteConnection(baglanti);
                conn.Open();

                SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = ON", conn);
                cmd.ExecuteNonQuery();
                
                runCommand(@"CREATE TABLE IF NOT EXISTS [" + cocuk_tablosu_adi + "]([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT);");
                runCommand(@"ALTER TABLE [" + cocuk_tablosu_adi + @"] ADD COLUMN " + "[Cocuk_Adi] NVARCHAR(100);");
                runCommand(@"ALTER TABLE [" + cocuk_tablosu_adi + @"] ADD COLUMN " + "[Cocuk_Adresi] NVARCHAR(500);");
                runCommand(@"ALTER TABLE [" + cocuk_tablosu_adi + @"] ADD COLUMN " + "[Cocuk_TC_No] VARCHAR(20);");
                runCommand(@"ALTER TABLE [" + cocuk_tablosu_adi + @"] ADD COLUMN " + "[Aylik_Ucret_Carpi_Yuz] INTEGER(64);");
                runCommand(@"ALTER TABLE [" + cocuk_tablosu_adi + @"] ADD COLUMN " + "[Cocuk_Duzen] VARCHAR(20);");
                runCommand(@"ALTER TABLE [" + cocuk_tablosu_adi + @"] ADD COLUMN " + "[Sinif] INTEGER(16);");
                runCommand(@"ALTER TABLE [" + cocuk_tablosu_adi + @"] ADD COLUMN " + "[Cinsiyet] INTEGER(1);");
                runCommand(@"ALTER TABLE [" + cocuk_tablosu_adi + @"] ADD COLUMN " + "[Aktif] INTEGER(1);");

                runCommand(@"CREATE TABLE IF NOT EXISTS [" + makbuz_tablosu_adi + "]([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT);");
                runCommand(@"ALTER TABLE [" + makbuz_tablosu_adi + @"] ADD COLUMN " + "[Sira_No] VARCHAR(128);");
                runCommand(@"ALTER TABLE [" + makbuz_tablosu_adi + @"] ADD COLUMN " + "[Duzenlenme_Tarihi] VARCHAR(20);");
                runCommand(@"ALTER TABLE [" + makbuz_tablosu_adi + @"] ADD COLUMN " + "[Irsa] VARCHAR(50);");
                runCommand(@"ALTER TABLE [" + makbuz_tablosu_adi + @"] ADD COLUMN " + "[KDV_CARPI_YUZ] INTEGER(64);");
                runCommand(@"ALTER TABLE [" + makbuz_tablosu_adi + @"] ADD COLUMN " + "[Cocuk_Id] INTEGER(64);");
                runCommand(@"ALTER TABLE [" + makbuz_tablosu_adi + @"] ADD COLUMN " + "FOREIGN KEY (Cocuk_Id) REFERENCES " + cocuk_tablosu_adi + "(ID);");

                runCommand(@"CREATE TABLE IF NOT EXISTS [" + ayarlar_tablosu_adi + "]([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT);");
                runCommand(@"ALTER TABLE [" + ayarlar_tablosu_adi + @"] ADD COLUMN " + "[KDV_CARPI_YUZ] INTEGER(64)" + ";");

            }
            catch (Exception e)
            {
                ExceptionThrown?.Invoke(e);
            }
        }
        
        internal List<Cocuk_Bilgileri> Cocuklari_Al()
        {
            var cocuklar = new List<Cocuk_Bilgileri>();
            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from " + cocuk_tablosu_adi;
            cmd.ExecuteNonQuery();
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id              =           Convert.ToInt32((   dr["ID"]));
                var cocuk_adi       =                               dr["Cocuk_Adi"].ToString();

                string cocuk_adresi = "";

                try
                {
                    cocuk_adresi = dr["Cocuk_Adresi"].ToString();
                }
                catch
                {

                }

                var cocuk_TC_no     =                               dr["Cocuk_TC_No"].ToString();
                var aylik_ucret     =           Convert.ToDouble(   dr["Aylik_Ucret_Carpi_Yuz"].ToString()) / 100;
                var cocuk_duzen     =                               dr["Cocuk_Duzen"].ToString();
                var sinif           = (SINIFLAR)Convert.ToInt16(    dr["Sinif"].ToString());
                var cinsiyet        = (CINSIYET)Convert.ToInt16(    dr["Cinsiyet"].ToString());
                var aktif_mi        = (AKTIFLIK)Convert.ToInt16(    dr["Aktif"].ToString());

                cocuklar.Add(new Cocuk_Bilgileri(id, cocuk_adi, cocuk_adresi, cocuk_TC_no, cocuk_duzen, aylik_ucret, sinif, cinsiyet, aktif_mi));
            }

            return cocuklar;
        }

        internal List<Makbuz_Bilgileri> Makbuzlari_Al()
        {
            var makbuzlar = new List<Makbuz_Bilgileri>();
            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from " + makbuz_tablosu_adi;
            cmd.ExecuteNonQuery();
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id                  =           Convert.ToInt32((   dr["ID"]));
                var sira_no             =                               dr["Sira_No"].ToString();

                var okunan_tarih        = dr["Duzenlenme_Tarihi"].ToString();
                DateTime duzenlenme_tarihi;
                if (!string.IsNullOrEmpty(okunan_tarih))
                {
                    var parcalar = okunan_tarih.Split('.');
                    duzenlenme_tarihi = new DateTime(int.Parse(parcalar[2]), int.Parse(parcalar[1]), int.Parse(parcalar[0]));
                }
                else
                {
                    duzenlenme_tarihi = new DateTime();
                }

                var irsa                =                               dr["Irsa"].ToString();
                var cocuk_id            =           Convert.ToInt32(    dr["Cocuk_Id"].ToString());
                var kdv                 =           Math.Round(Convert.ToDouble(    dr["KDV_CARPI_YUZ"].ToString()) / 100 , 2);

                makbuzlar.Add(new Makbuz_Bilgileri(id, sira_no, duzenlenme_tarihi, irsa, cocuk_id, kdv ));
            }

            return makbuzlar;
        }
        
        public void closeDatabase()
        {
            if (null != conn)
                conn.Close();
        }

        public void runCommand(string sql, bool bildirim_at = false)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (bildirim_at)
                {
                    ExceptionThrown?.Invoke(ex);
                }
            }
        }
    }
}
