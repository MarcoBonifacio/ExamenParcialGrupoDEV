using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ParcialGrupoDEV.Utils
{
    public static class CsvExporter
    {
        public static void ExportDataGridViewToCsv(DataGridView dgv, string path)
        {
            var sb = new StringBuilder();
            // headers
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                sb.Append(dgv.Columns[i].HeaderText);
                if (i < dgv.Columns.Count - 1) sb.Append(',');
            }
            sb.AppendLine();

            // rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    var val = row.Cells[i].Value;
                    var cell = val?.ToString().Replace("\"", "\"\"") ?? string.Empty;
                    if (cell.Contains(",") || cell.Contains("\"") || cell.Contains("\n"))
                        sb.Append('"').Append(cell).Append('"');
                    else
                        sb.Append(cell);
                    if (i < dgv.Columns.Count - 1) sb.Append(',');
                }
                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
    }
}
