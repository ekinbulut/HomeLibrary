using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.UnitTest
{
    public class ConnectionTest
    {

        public DataTable ReadCSVFile(string filepath)
        {
            DataTable table = new DataTable();

            using (StreamReader reader = new StreamReader(filepath, System.Text.Encoding.UTF8))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var rows = line?.Split(';');


                    for (int i = 0; i < rows.Length; i++)
                    {
                        var row = table.NewRow();

                        row.SetField(i, rows[i]);
                    }

                }

            }

            return null;
        }
    }
}
