using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.Linq;

namespace Mre.tecnologia.util.lib.ExportFormat
{
    public static class Excel
    {
        public static byte[] Exportar<T>(IEnumerable<T> data, string[] columName, string nameWorksheet)
        {
            byte[] file;
            int columna = 0;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {
                var workSheet = excelPackage.Workbook.Worksheets.Add(nameWorksheet);
                workSheet.Cells.LoadFromCollection(data, true);

                var columnaInicial = (workSheet.Dimension.Start).Column;
                var columnaFinal = (workSheet.Dimension.End).Column;

                var tabla = workSheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: columnaInicial, toRow: data.Count() + 1, toColumn: columnaFinal), nameWorksheet);
                tabla.ShowHeader = true;
                tabla.TableStyle = TableStyles.Light13;

                foreach (var header in columName)
                {
                    columna += 1;
                    workSheet.Cells[1, columna].Value = header;
                }

                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
                workSheet.View.ZoomScale = 85;
                file = excelPackage.GetAsByteArray();

                if (file == null || file.Length == 0)
                {
                    return null;
                }

                return file;
            }
        }

        public static byte[] ExportarDictionary(List<Dictionary<string, string>> data, string[] columName, string nameWorksheet)
        {
            byte[] file;
            int fila = 2;
            int columna;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {
                var workSheet = excelPackage.Workbook.Worksheets.Add(nameWorksheet);

                foreach (var registro in data)
                {
                    columna = 0;
                    foreach (var item in registro)
                    {
                        columna += 1;
                        workSheet.Cells[fila, columna].Value = item.Value;
                    }
                    fila += 1;
                }

                var columnaInicial = (workSheet.Dimension.Start).Column;
                var columnaFinal = (workSheet.Dimension.End).Column;

                var tabla = workSheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: columnaInicial, toRow: data.Count() + 1, toColumn: columnaFinal), nameWorksheet);
                tabla.ShowHeader = true;
                tabla.TableStyle = TableStyles.Light13;

                columna = 0;
                foreach (var header in columName)
                {
                    columna += 1;
                    workSheet.Cells[1, columna].Value = header;
                }

                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
                workSheet.View.ZoomScale = 85;
                file = excelPackage.GetAsByteArray();

                if (file == null || file.Length == 0)
                {
                    return null;
                }

                return file;
            }
        }
    }
}
