using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
namespace DolgozatMegoldas
{
  public  class X
    {

        static public SQLiteConnection kapcsolat;
        static public SQLiteCommand parancs;
        static public SQLiteDataReader eredmeny;
        static public SQLiteCommand parancs_s;
        static public SQLiteDataReader eredmeny_s;

        static public SQLiteDataAdapter adapter;

        public static void Kapcsolodas(string database)
        {
            kapcsolat = new SQLiteConnection("data source = " + database);
            kapcsolat.Open();
            adapter = new SQLiteDataAdapter();
            parancs = new SQLiteCommand();
            parancs.Connection = kapcsolat;
            parancs_s = new SQLiteCommand();
            parancs_s.Connection = kapcsolat;

        }
        public static void kapcsClose() { kapcsolat.Close(); }
        public static DataTable DataFill(string sql) {
            SQLiteCommand command = new SQLiteCommand();
            
            command.CommandText = sql;
            adapter = new SQLiteDataAdapter(sql,kapcsolat);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

    }
}
