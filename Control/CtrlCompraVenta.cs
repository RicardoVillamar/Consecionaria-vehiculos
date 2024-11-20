using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Control
{
    public class CtrlCompraVenta
    {
        Conexion conexion = new Conexion();
        DatosCompraVenta CompraVentaDto = new DatosCompraVenta();
        DatosCliente clienteDto = new DatosCliente();

        public string Registrar(DataGridView tabla, string cedula, string tipo, string fecha)
        {
            CtrlCliente clienteControlador = new CtrlCliente();
            List<int> IdDetalles = new List<int>();

            if (tipo.Equals("")) return "0 Se Debe escojer un tipo para filtrar!";
            if (cedula.Length != 10) return "0. El campo cedula debe tener 10 digitos";

            conexion.Conectar();
            if (clienteControlador.verificarCliente(cedula) == 0)
                return "El cliente debe ser registrado en el sistema!";

            if (!ValidarCompraVenta.ValidarDatosDetalle(tabla))
                return "Datos de detalle invalidos!";
            
            int IdCliente = clienteControlador.obtenerIdCliente(cedula);

            CompraVenta compraVenta = new CompraVenta();
            compraVenta.Detalles = ConsultarDetalles(tabla);
            compraVenta.TipoCV = tipo;
            compraVenta.Total = this.CalcularTotal(tabla);
            compraVenta.Fecha = DateTime.Parse(this.DarFormatoFecha(fecha));
            
            int IdCompraVenta = CompraVentaDto.AgregarCompraVenta(compraVenta, IdCliente, conexion.Cn);

            // Agregar cada detalle en la base de datos
            CompraVentaDto.AgregarDetalles(compraVenta.Detalles, IdCompraVenta, conexion.Cn);

            conexion.Cerrar();
            return "CompraVenta registrada!";
        } 

        public string Reporte(DataGridView grid, string tipo, string cedula)
        {
            CtrlCliente ctrlCliente = new CtrlCliente();
            List<CompraVenta> lista;

            if (tipo.Equals("")) return "0. Se Debe escojer un tipo para filtrar!";
            if (cedula.Length != 10) return "0. El campo cedula debe tener 10 digitos";

            conexion.Conectar();
            if (clienteDto.verificar(cedula, conexion.Cn) == 0) 
                return "0 El cliente no está registrado en la base de datos";
            conexion.Cerrar();


            conexion.Conectar();
            lista = CompraVentaDto.ConsultarCompraVenta(tipo, cedula, conexion.Cn);
            conexion.Cerrar();
            
            if (lista.Count == 0) return $"0. El cliente con cedula {cedula} no tiene {tipo}";


            grid.Rows.Clear();
            lista.ForEach(x =>
            {
                object[] row = { x.Cliente.Apellido, x.Cliente.Cedula, x.TipoCV, x.Total, x.Fecha }; 
                grid.Rows.Add(row);
            });

            conexion.Cerrar();
            return "Filtrado por tipo y cedula, reporte exitoso!";
        }

        public int Eliminar(string cedula)
        {
            conexion.Conectar();

            DatosCompraVenta CompraVentaDto = new DatosCompraVenta();

            CompraVentaDto.Eliminar(cedula, conexion.Cn);
            return 1;
            conexion.Cerrar();
        }

        // Utils **
        private List<Detalle> ConsultarDetalles(DataGridView grid)
        {
            List<Detalle> detalles = new List<Detalle>();
            decimal subtotal = 0m;
            int i = 0;

            foreach (DataGridViewRow row in grid.Rows)
            {
                int Cantidad = ValidarCompraVenta.aEnteroPositivo(row.Cells["Cantidad"].Value.ToString());
                decimal precioUnitario = ValidarCompraVenta.aDecimal(row.Cells["PrecioUnitario"].Value.ToString());

                subtotal += (Cantidad * precioUnitario);

                detalles.Add(new Detalle(Cantidad, precioUnitario));
                if (++i == grid.RowCount - 1) break;// Ignora el ultimo registro en blanco de la grilla
            }
            return detalles;
        }
        
        private string DarFormatoFecha(string fecha)
        {
            string FechaFormateada = "";
            foreach (string item in fecha.Split('/').Reverse())
            {
                FechaFormateada += item + "-";
            }
            return FechaFormateada.Substring(0, FechaFormateada.Length - 1);
        } 
        
        public decimal CalcularTotal(DataGridView dgvDetalle)
        {
            decimal subtotal = 0m, total = 0;
            int i = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                int Cantidad = ValidarCompraVenta.aEnteroPositivo(row.Cells["Cantidad"].Value.ToString());
                decimal precioUnitario = ValidarCompraVenta.aDecimal(row.Cells["PrecioUnitario"].Value.ToString());
                subtotal += (Cantidad * precioUnitario);
                if (++i == dgvDetalle.RowCount - 1) break;// Ignora el ultimo registro en blanco de la tabla
            }
            return subtotal + Decimal.Truncate(subtotal * 0.15m);
        } 


        // Metodos para gestionar el pdf **
        public string GenerarPDF(DataGridView grid)
        {
            if(grid.Rows.Count == 0)
                return "Sin registros para generar Pdf";

            // Fonts
            iTextSharp.text.Font Titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.RED);
            iTextSharp.text.Font subTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font texto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            
            // Columnas de la tabla
            string[] columnas = { "Apellido", "Cedula", "Tipo", "Total", "Fecha" };

            // titulo del pdf
            Paragraph tituloPdf = new Paragraph("Reporte de Compra o ventas", Titulo);
            tituloPdf.Alignment = Element.ALIGN_CENTER;

            // la tabla se componen de 5 columnas
            PdfPTable tabla = new PdfPTable(columnas.Length);
            tabla.WidthPercentage = 100;



            FileStream fs = null;
            try
            {
                Document doc = new Document(PageSize.A4, 5, 5, 7, 7);
                fs = new FileStream("Reporte.pdf", FileMode.Create);
                PdfWriter pdfW = PdfWriter.GetInstance(doc, fs);
                
                doc.Open();
                doc.Add(tituloPdf);
                doc.Add(Chunk.NEWLINE);


                PdfPCell[] colTitulos = new PdfPCell[columnas.Length];
    
                int i = 0;
                foreach (string columna in columnas)
                {
                    colTitulos[i] = new PdfPCell(new Phrase(columna, subTitulo));
                    colTitulos[i].BackgroundColor = BaseColor.BLACK;
                    colTitulos[i].BorderWidth = 0;
                    colTitulos[i].BorderWidthBottom = 0.25f;
                    tabla.AddCell(colTitulos[i]);
                    i++;
                }

                foreach (DataGridViewRow row in grid.Rows)
                {
                    int j = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        
                        string value = cell.Value.ToString();
                        colTitulos[j] = new PdfPCell(new Phrase(value, texto));
                        tabla.AddCell(colTitulos[j]);
                        j++;
                    }
                }
             
                doc.Add(tabla);
                doc.Close();
                pdfW.Close();
                MessageBox.Show("Documento PDF generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            finally
            {
                fs?.Close();
                conexion.Cerrar();
            }
        }

        public void AbrirPDF()
        {
            if (!File.Exists("Reporte.pdf"))
            {
                MessageBox.Show("El PDF no existe, no se pudo generar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start("Reporte.pdf");
        }
    }

}