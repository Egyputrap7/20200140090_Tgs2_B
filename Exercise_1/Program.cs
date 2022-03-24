using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EXE1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().InsertData();
            new Program().CreateDatabase();
        }
        public void CreateDatabase()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-GHEF0MBM\\EGY;database=Apotek;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("Create table Pembeli ( ID_Pembeli char(5) PRIMARY KEY NOT NULL,Nama_Pembeli varchar(20) NOT NULL,Alamat_Pembeli Varchar(50) NOT NULL,)" +
                    "create table karyawan( ID_Karyawan char(5) PRIMARY KEY NOT NULL,Nama_Karyawan varchar(20) NOT NULL,Alamat_Karyawan Varchar(50) NOT NULL,NO_Tlp char(12) NOT NULL,)" +
                    "create table suplier_Obat( ID_Suplier char(5) PRIMARY KEY NOT NULL,Nama_Suplier varchar(20) NOT NULL,Alamat_Suplier varchar(50) NOT NULL,NO_Tlp char(12) NOT NULL) " +
                    "create table Stock_obat( ID_Obat char(5) PRIMARY KEY NOT NULL,Nama_Obat varchar(10) NOT NULL,Harga money NOT NULL,jenis varchar(30) NOT NULL,ID_suplier char(5) FOREIGN KEY REFERENCES suplier_Obat(ID_Suplier)  NOT NULL) " +
                    "Create table Transaksi( ID_Transaksi char(5) NOT NULL,ID_Karyawan char(5) FOREIGN KEY REFERENCES Karyawan(ID_Karyawan),ID_Pembeli char(5) FOREIGN KEY REFERENCES Pembeli(ID_Pembeli)  NOT NULL,ID_Obat char(5) FOREIGN KEY REFERENCES Stock_obat(ID_Obat) NOT NULL,tanggal datetime,Jumlah int NOT NULL,Total_harga money) ", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Sukses MEnambah Data");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Gagal menambah data" + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-GHEF0MBM\\EGY;database=Apotek;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("insert into Pembeli (ID_Pembeli,Nama_Pembeli,Alamat_Pembeli) values ('00-01','Egy Putra','Yogyakarta Sleman');" +
                    "insert into Pembeli(ID_Pembeli, Nama_Pembeli, Alamat_Pembeli) values('00-02', 'Edy Sugio', 'Yogyakarta Sleman');" +
                    "insert into Pembeli(ID_Pembeli, Nama_Pembeli, Alamat_Pembeli) values('00-03', 'Prabowo JKW', 'Yogyakarta Sleman');" +
                    "insert into Pembeli(ID_Pembeli, Nama_Pembeli, Alamat_Pembeli) values('00-04', 'Sri Hartati', 'Yogyakarta Sleman');" +
                    "insert into Pembeli(ID_Pembeli, Nama_Pembeli, Alamat_Pembeli) values('00-05', 'Purnomo Sri', 'Yogyakarta Sleman');" +
                    "insert into karyawan (ID_Karyawan,Nama_Karyawan,Alamat_Karyawan,NO_Tlp) Values ('K0-01','Ahmad zuhdan','Tempel Yogyakarta','085647823654')" +
                    "insert into karyawan(ID_Karyawan, Nama_Karyawan, Alamat_Karyawan, NO_Tlp) Values('K0-02', 'Bilal burak', 'Tempel Yogyakarta', '085647854657')" +
                    "insert into karyawan(ID_Karyawan, Nama_Karyawan, Alamat_Karyawan, NO_Tlp) Values('K0-03', 'Aldena tegar', 'Tempel Yogyakarta', '085647823545')" +
                    "insert into karyawan(ID_Karyawan, Nama_Karyawan, Alamat_Karyawan, NO_Tlp) Values('K0-04', 'Gustian Dayat', 'Tempel Yogyakarta', '085879723654')" +
                    "insert into karyawan(ID_Karyawan, Nama_Karyawan, Alamat_Karyawan, NO_Tlp) Values('K0-05', 'Ridwan  Maulana', 'Tempel Yogyakarta', '085234123654')" +
                    "insert into suplier_Obat (ID_Suplier,Nama_Suplier,Alamat_Suplier,NO_Tlp) Values ('S0-01','Dikiy zuaaardi','Margorejo Yogyakarta','081354653654')" +
                    "insert into suplier_Obat(ID_Suplier, Nama_Suplier, Alamat_Suplier, NO_Tlp) Values('S0-02', 'Nikit Gilang', 'Margorejo Yogyakarta', '081546523654')" +
                    "insert into suplier_Obat(ID_Suplier, Nama_Suplier, Alamat_Suplier, NO_Tlp) Values('S0-03', 'Burlai Duna', 'Margorejo Yogyakarta', '081354657895')" +
                    "insert into suplier_Obat(ID_Suplier, Nama_Suplier, Alamat_Suplier, NO_Tlp) Values('S0-04', 'Aminah suawardi', 'Margorejo Yogyakarta', '081234653684')" +
                    "insert into suplier_Obat(ID_Suplier, Nama_Suplier, Alamat_Suplier, NO_Tlp) Values('S0-05', 'Luki Juandi', 'Margorejo Yogyakarta', '081354658792')" +
                    "insert into  Stock_obat (ID_Obat,Nama_Obat,Harga,jenis,ID_suplier) Values ('O0-01','OBH',1500,'Obat Batuk','S0-01')" +
                    "insert into  Stock_obat(ID_Obat, Nama_Obat, Harga, jenis, ID_suplier) Values('O0-02', 'Dekolgen', 2000, 'Obat Pusing', 'S0-02')" +
                    "insert into  Stock_obat(ID_Obat, Nama_Obat, Harga, jenis, ID_suplier) Values('O0-03', 'Prokol', 2500, 'Obat Demam', 'S0-03')" +
                    "insert into  Stock_obat(ID_Obat, Nama_Obat, Harga, jenis, ID_suplier) Values('O0-04', 'Intunal', 3000, 'Obat Flue', 'S0-04')" +
                    "insert into  Stock_obat(ID_Obat, Nama_Obat, Harga, jenis, ID_suplier) Values('O0-05', 'CTM', 4000, 'Obat Tidur', 'S0-05')" +
                    "insert into Transaksi (ID_Transaksi,ID_Karyawan,ID_Pembeli,ID_Obat,tanggal,Jumlah,Total_harga) Values" +
                    "('T0-01', 'K0-01', '00-01', 'O0-01', 13 - 05 - 2022, 2, '3000')" +
                    "insert into Transaksi(ID_Transaksi, ID_Karyawan, ID_Pembeli, ID_Obat, tanggal, Jumlah, Total_harga) Values" +
                    "('T0-02', 'K0-02', '00-02', 'O0-02', 16 - 08 - 2022, 1, '2000')" +
                    "insert into Transaksi(ID_Transaksi, ID_Karyawan, ID_Pembeli, ID_Obat, tanggal, Jumlah, Total_harga) Values" +
                    "('T0-03', 'K0-03', '00-03', 'O0-03', 18 - 11 - 2022, 2, '5000')" +
                    "insert into Transaksi(ID_Transaksi, ID_Karyawan, ID_Pembeli, ID_Obat, tanggal, Jumlah, Total_harga) Values" +
                    "('T0-04', 'K0-04', '00-04', 'O0-04', 12 - 07 - 2022, 2, '6000')" +
                    "insert into Transaksi(ID_Transaksi, ID_Karyawan, ID_Pembeli, ID_Obat, tanggal, Jumlah, Total_harga) Values" +
                    "('T0-05', 'K0-05', '00-05', 'O0-05', 12 - 03 -" +
                    " 2022, 1, '4000') ", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Sukses Menambah Data");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Gagal menambah data" + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
