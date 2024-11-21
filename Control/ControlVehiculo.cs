using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Modelo;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec.wmf;
using System.Text.RegularExpressions;

namespace Control
{
    public class ControlVehiculo
    {
        private static List <Vehiculo> listVehiculo = new List<Vehiculo>();

        public static List<Vehiculo> ListVehiculo { get => listVehiculo; set => listVehiculo = value; }

        Conexion conBD = new Conexion();
        DatosVehiculo dVehiculo = new DatosVehiculo();

        /*
         * Metodos de Ingreso
        */

        //Insertar Vehiculo en la Base de Datos
        public void InsertVh(Vehiculo vh)
        {
            string msj = string.Empty;
            string msjCnx = conBD.Conectar();

            if (msjCnx[0] == '1')
            {
                msj = dVehiculo.IngresarVehiculo(vh, conBD.Cn);
                if (msjCnx[0] == '0')
                {
                    MessageBox.Show("Ocurrió un error: " + msjCnx);
                }
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conBD.Cerrar();
        }

        //Ingresar Vehiculo
        public string Ingresar(string id, string marca, string tipoVehiculo, string tipoCombustible, string color, string estado, string kilometraje, string precio)
        {
            string msj = "Se esperaban datos correctos";
            ValidarVehiculo valH = new ValidarVehiculo();

            float skm = valH.ValidarKilometraje(kilometraje);
            float spr = valH.ValidarPrecio(precio);

            Vehiculo vh = null;
            if (marca != "" && color != "" && tipoVehiculo != "" && estado != "" && tipoCombustible != "")
            {
                vh = new Vehiculo(id, marca, tipoVehiculo, tipoCombustible, color, estado, skm, spr);
                listVehiculo.Add(vh);
                InsertVh(vh);
                msj = vh.ToString();
            }
            return msj;
        }

        //Ingresar Automovil
        public string IngresarAuto(string id, string marca, string tipoVehiculo, string tipoCombustible, string color, string estado, string kilometraje, string precio, string ida, string nPuertas, string tipoTransmision, string tipoAuto)
        {
            string msj = "Se esperaban datos correctos";
            ValidarVehiculo valH = new ValidarVehiculo();

            float skm = valH.ValidarKilometraje(kilometraje);
            float spr = valH.ValidarPrecio(precio);

            Automovil automovil = null;

            if (marca != "" && color != "" && tipoVehiculo != "" && estado != "" && tipoCombustible != "" && nPuertas != "" && tipoTransmision != "" && tipoAuto != "")
            {
                automovil = new Automovil(id, marca, tipoVehiculo, tipoCombustible, color, estado, skm, spr, ida, nPuertas, tipoTransmision, tipoAuto);
                listVehiculo.Add(automovil);
                InsertVh(automovil);
                msj = automovil.ToString();
            }
            return msj;
        }

        //Ingresar Camion
        public string IngresarCamion(string id, string marca, string tipoVehiculo, string tipoCombustible, string color, string estado, string kilometraje, string precio, string idc, string capacidadCarga, string tipoCarga)
        {
            string msj = "Se esperaban datos correctos";
            ValidarVehiculo valH = new ValidarVehiculo();

            float skm = valH.ValidarKilometraje(kilometraje);
            float spr = valH.ValidarPrecio(precio);
            float scpc = valH.ValidarCapacidadCarga(capacidadCarga);

            Camion camion = null;

            if (marca != "" && color != "" && tipoVehiculo != "" && estado != "" && tipoCombustible != "" && capacidadCarga != null && tipoCarga != null)
            {
                camion = new Camion(id, marca, tipoVehiculo, tipoCombustible, color, estado, skm, spr, idc, scpc, tipoCarga);
                listVehiculo.Add(camion);
                InsertVh(camion);
                msj = camion.ToString();
            }
            return msj;
        }

        //Ingresar Motocicleta
        public string IngresarMoto(string id, string marca, string tipoVehiculo, string tipoCombustible, string color, string estado, string kilometraje, string precio, string idm, string tipoMoto, string ruedas, string tipoFreno)
        {
            string msj = "Se esperaban datos correctos";
            ValidarVehiculo valH = new ValidarVehiculo();

            float skm = valH.ValidarKilometraje(kilometraje);
            float spr = valH.ValidarPrecio(precio);
            int sruedas = valH.ValidarRuedas(ruedas);

            Motocicleta motocicleta = null;

            if (marca != "" && color != "" && tipoVehiculo != "" && estado != "" && tipoCombustible != "" && tipoMoto != "" && tipoFreno != "")
            {
                motocicleta = new Motocicleta(id, marca, tipoVehiculo, tipoCombustible, color, estado, skm, spr, idm, tipoMoto, sruedas, tipoFreno);
                listVehiculo.Add(motocicleta);
                InsertVh(motocicleta);
                msj = motocicleta.ToString();
            }
            return msj;

        }

        /*
         * Limpiar Campos 
        */

        //Limpiar Automovil
        public void LimpiarAuto(TextBox txtMarca, TextBox txtColor, ComboBox cmbTipoVehiculo, ComboBox cmbEstado, TextBox txtCombustible, TextBox txtKilometraje, TextBox txtPrecio, TextBox txtNPuertas, ComboBox cmbTipoTransmision, ComboBox cmbTipoAuto)
        {
            txtMarca.Text = "";
            txtColor.Text = "";
            cmbTipoVehiculo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            txtCombustible.Text = "";
            txtKilometraje.Text = "";
            txtPrecio.Text = "";
            txtNPuertas.Text = "";
            cmbTipoTransmision.SelectedIndex = -1;
            cmbTipoAuto.SelectedIndex = -1;
        }

        //Limpiar Camion
        public void LimpiarCamion(TextBox txtMarca, TextBox txtColor, ComboBox cmbTipoVehiculo, ComboBox cmbEstado, TextBox txtCombustible, TextBox txtKilometraje, TextBox txtPrecio, TextBox txtCapacidadCarga, ComboBox cmbTipoCarga)
        {
            txtMarca.Text = "";
            txtColor.Text = "";
            cmbTipoVehiculo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            txtCombustible.Text = "";
            txtKilometraje.Text = "";
            txtPrecio.Text = "";
            txtCapacidadCarga.Text = "";
            cmbTipoCarga.SelectedIndex = -1;
        }

        //Limpiar Motocicleta
        public void LimpiarMoto(TextBox txtMarca, TextBox txtColor, ComboBox cmbTipoVehiculo, ComboBox cmbEstado, TextBox txtCombustible, TextBox txtKilometraje, TextBox txtPrecio, ComboBox cmbTipoMoto, TextBox txtNRuedas, ComboBox cmbTipoFreno)
        {
            txtMarca.Text = "";
            txtColor.Text = "";
            cmbTipoVehiculo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            txtCombustible.Text = "";
            txtKilometraje.Text = "";
            txtPrecio.Text = "";
            cmbTipoMoto.SelectedIndex = -1;
            txtNRuedas.Text = "";
            cmbTipoFreno.SelectedIndex = -1;
        }

        /*
         * Metodos de Ingreso de Datos en el DataGridView
        */

        //Metodo de llenado de Reporte
        public void LlenarReporte(DataGridView dgvReporteVehiculo)
        {
            int i = 0;
            dgvReporteVehiculo.Rows.Clear();
            listVehiculo = SeleccionarVh();
            if(listVehiculo.Count > 0)
            {
                foreach (Vehiculo x in listVehiculo)
                {
                    i = dgvReporteVehiculo.Rows.Add();
                    dgvReporteVehiculo.Rows[i].Cells["colIdVehiculo"].Value = x.IdVehiculo;
                    dgvReporteVehiculo.Rows[i].Cells["colMarca"].Value = x.Marca;
                    dgvReporteVehiculo.Rows[i].Cells["colTipoVehiculo"].Value = x.TipoVehiculo;
                    dgvReporteVehiculo.Rows[i].Cells["colTipoCombustible"].Value = x.TipoCombustible;
                    dgvReporteVehiculo.Rows[i].Cells["colColor"].Value = x.Color;
                    dgvReporteVehiculo.Rows[i].Cells["colEstado"].Value = x.Estado;
                    dgvReporteVehiculo.Rows[i].Cells["colPrecio"].Value = x.Precio;
                }
            }
        }

        //Metodo de Llenar Datos en el DataGridView desde la Base de Datos

        private List<Vehiculo> SeleccionarVh()
        {
            List<Vehiculo> listVhl = new List<Vehiculo>();
            string msj = string.Empty;
            string msjCnx = conBD.Conectar();

            if (msjCnx[0] == '1')
            {
                listVhl = dVehiculo.ConsultarVh(conBD.Cn);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conBD.Cerrar();
            return listVhl; 
        }
        

        //Metodo de Retiro de la Base de Datos
        public string EliminarVh(string id)
        {
            string m = "Vehículo no encontrado";
            string msj = string.Empty;
            string msjCnx = conBD.Conectar();

            if (msjCnx[0] == '1')
            {
                msj = dVehiculo.RetirarVehiculo(id, conBD.Cn);
                m = "Vehículo retirado correctamente";
                
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conBD.Cerrar();
            return m;
        }



        /*
         * Metodos de Actualizacion
        */

        //Actualizar Vehiculo
        public string ActualizarVehiculo(string idInicial, string color, string tpCombus)
        {
            string msj = "Vehiculo actualizado correctamente";

            Vehiculo vh = listVehiculo.FirstOrDefault(s => s.IdVehiculo == idInicial);

            if (vh != null)
            {
                vh.Color = color;
                vh.TipoCombustible = tpCombus;
                ActualizarVh(vh.IdVehiculo, color, tpCombus);
            }
            else
            {
                msj = "No se pudo encontrar";
            }
            return msj;
        }

        public void ActualizarFilaEnGrid(DataGridViewRow fila, string id)
        {
            Vehiculo vh = listVehiculo.FirstOrDefault(s => s.IdVehiculo == id);
            if (vh != null)
            {
                fila.Cells["colColor"].Value = vh.Color;
                fila.Cells["colTipoCombustible"].Value = vh.TipoCombustible;
            }
        }

        public string ActualizarVh(string id, string nColor, string nTipo)
        {
            string msj = string.Empty;
            string msjCnx = conBD.Conectar();

            if (msjCnx[0] == '1')
            {
                msj = dVehiculo.ActualizarVehiculo(id, nColor, nTipo, conBD.Cn);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conBD.Cerrar();

            return msj;
        }

        /*
         * Filtro por marca 
        */
        public void LlenarPorMarca(DataGridView dgvReporteVehiculo, string marca)
        {
            int i = 0;
            dgvReporteVehiculo.Rows.Clear();
            listVehiculo = FiltrarVhPorMarca(marca);
            if (listVehiculo.Count > 0)
            {
                foreach (Vehiculo x in listVehiculo)
                {
                    i = dgvReporteVehiculo.Rows.Add();
                    dgvReporteVehiculo.Rows[i].Cells["colIdVehiculo"].Value = x.IdVehiculo;
                    dgvReporteVehiculo.Rows[i].Cells["colMarca"].Value = x.Marca;
                    dgvReporteVehiculo.Rows[i].Cells["colTipoVehiculo"].Value = x.TipoVehiculo;
                    dgvReporteVehiculo.Rows[i].Cells["colTipoCombustible"].Value = x.TipoCombustible;
                    dgvReporteVehiculo.Rows[i].Cells["colColor"].Value = x.Color;
                    dgvReporteVehiculo.Rows[i].Cells["colEstado"].Value = x.Estado;
                    dgvReporteVehiculo.Rows[i].Cells["colPrecio"].Value = x.Precio;
                }
            }
        }

        private List<Vehiculo> FiltrarVhPorMarca(string marca)
        {
            List<Vehiculo> listVhl = new List<Vehiculo>();
            string msj = string.Empty;
            string msjCnx = conBD.Conectar();

            if (msjCnx[0] == '1')
            {
                listVhl = dVehiculo.FiltarVhMarca(conBD.Cn, marca);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conBD.Cerrar();
            return listVhl;
        }

        /*
         * Filtro por estado 
        */

        public void LlenarPorEstado(DataGridView dgvReporteVehiculo, string estado)
        {
            int i = 0;
            dgvReporteVehiculo.Rows.Clear();
            listVehiculo = FiltrarVhPorEstado(estado);
            if (listVehiculo.Count > 0)
            {
                foreach (Vehiculo x in listVehiculo)
                {
                    i = dgvReporteVehiculo.Rows.Add();
                    dgvReporteVehiculo.Rows[i].Cells["colIdVehiculo"].Value = x.IdVehiculo;
                    dgvReporteVehiculo.Rows[i].Cells["colMarca"].Value = x.Marca;
                    dgvReporteVehiculo.Rows[i].Cells["colTipoVehiculo"].Value = x.TipoVehiculo;
                    dgvReporteVehiculo.Rows[i].Cells["colTipoCombustible"].Value = x.TipoCombustible;
                    dgvReporteVehiculo.Rows[i].Cells["colColor"].Value = x.Color;
                    dgvReporteVehiculo.Rows[i].Cells["colEstado"].Value = x.Estado;
                    dgvReporteVehiculo.Rows[i].Cells["colPrecio"].Value = x.Precio;
                }
            }
        }

        private List<Vehiculo> FiltrarVhPorEstado(string estado)
        {
            List<Vehiculo> listVhl = new List<Vehiculo>();
            string msj = string.Empty;
            string msjCnx = conBD.Conectar();

            if (msjCnx[0] == '1')
            {
                listVhl = dVehiculo.FiltrarVhEstado(conBD.Cn, estado);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conBD.Cerrar();
            return listVhl;
        }



        /*
         * Metodo Para Generar PDF
         */
        public void GenerarPDF()
        {
            FileStream fs = null;
            Document doc = null;
            string[] titulosTablas = { "Marca", "Tipo Vehiculo", "Tipo Combustible", "Color", "Estado", "Precio" };
            listVehiculo = SeleccionarVh();

            try
            {
                fs = new FileStream("Reporte.pdf", FileMode.Create);
                doc = new Document(PageSize.A4, 36, 36, 30, 30);

                PdfWriter pdfW = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                iTextSharp.text.Font Titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.RED);
                iTextSharp.text.Font subTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                iTextSharp.text.Font texto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Paragraph tituloPdf = new Paragraph("Reporte de Vehiculos", Titulo)
                {
                    Alignment = Element.ALIGN_CENTER
                };

                doc.Add(tituloPdf);

                doc.Add(Chunk.NEWLINE);

                PdfPTable tabla = new PdfPTable(6);
                tabla.WidthPercentage = 100;

                PdfPCell[] colTitulos = new PdfPCell[titulosTablas.Length];
                for (int i = 0; i < titulosTablas.Length; i++)
                {
                    colTitulos[i] = new PdfPCell(new Phrase(titulosTablas[i], subTitulo));
                    colTitulos[i].BackgroundColor = BaseColor.BLACK;
                    colTitulos[i].BorderWidth = 0;
                    colTitulos[i].BorderWidthBottom = 0.25f;
                    colTitulos[i].HorizontalAlignment = Element.ALIGN_CENTER;
                    colTitulos[i].VerticalAlignment = Element.ALIGN_MIDDLE;
                    tabla.AddCell(colTitulos[i]);
                }

                foreach (Vehiculo vh in listVehiculo)
                {
                    colTitulos[0] = new PdfPCell(new Phrase(vh.Marca, texto));
                    colTitulos[0].BorderWidth = 0;
                    colTitulos[1] = new PdfPCell(new Phrase(vh.TipoVehiculo, texto));
                    colTitulos[1].BorderWidth = 0;
                    colTitulos[2] = new PdfPCell(new Phrase(vh.TipoCombustible, texto));
                    colTitulos[2].BorderWidth = 0;
                    colTitulos[3] = new PdfPCell(new Phrase(vh.Color, texto));
                    colTitulos[3].BorderWidth = 0;
                    colTitulos[4] = new PdfPCell(new Phrase(vh.Estado, texto));
                    colTitulos[4].BorderWidth = 0;
                    colTitulos[5] = new PdfPCell(new Phrase(vh.Precio.ToString(), texto));
                    colTitulos[5].BorderWidth = 0;

                    tabla.AddCell(colTitulos[0]);
                    tabla.AddCell(colTitulos[1]);
                    tabla.AddCell(colTitulos[2]);
                    tabla.AddCell(colTitulos[3]);
                    tabla.AddCell(colTitulos[4]);
                    tabla.AddCell(colTitulos[5]);
                }
                doc.Add(tabla);
                doc.Close();
                pdfW.Close();
                MessageBox.Show("Documento PDF generado con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs?.Close();
            }
        }

        public void AbrirPDF()
        {
            if (File.Exists("Reporte.pdf"))
            {
                System.Diagnostics.Process.Start("Reporte.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe.El PDF no se pudo generar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GenerarPDFMarca(string marca)
        {
            FileStream fs = null;
            Document doc = null;
            string[] titulosTablas = { "Marca", "Tipo Vehiculo", "Tipo Combustible", "Color", "Estado", "Precio" };
            listVehiculo = FiltrarVhPorMarca(marca);

            try
            {
                fs = new FileStream("ReporteMarca.pdf", FileMode.Create);
                doc = new Document(PageSize.A4, 36, 36, 30, 30);

                PdfWriter pdfW = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                iTextSharp.text.Font Titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.RED);
                iTextSharp.text.Font subTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                iTextSharp.text.Font texto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Paragraph tituloPdf = new Paragraph("Reporte de Vehiculos", Titulo)
                {
                    Alignment = Element.ALIGN_CENTER
                };

                doc.Add(tituloPdf);

                doc.Add(Chunk.NEWLINE);

                PdfPTable tabla = new PdfPTable(6);
                tabla.WidthPercentage = 100;

                PdfPCell[] colTitulos = new PdfPCell[titulosTablas.Length];
                for (int i = 0; i < titulosTablas.Length; i++)
                {
                    colTitulos[i] = new PdfPCell(new Phrase(titulosTablas[i], subTitulo));
                    colTitulos[i].BackgroundColor = BaseColor.BLACK;
                    colTitulos[i].BorderWidth = 0;
                    colTitulos[i].BorderWidthBottom = 0.25f;
                    colTitulos[i].HorizontalAlignment = Element.ALIGN_CENTER;
                    colTitulos[i].VerticalAlignment = Element.ALIGN_MIDDLE;
                    tabla.AddCell(colTitulos[i]);
                }

                foreach (Vehiculo vh in listVehiculo)
                {
                    colTitulos[0] = new PdfPCell(new Phrase(vh.Marca, texto));
                    colTitulos[0].BorderWidth = 0;
                    colTitulos[1] = new PdfPCell(new Phrase(vh.TipoVehiculo, texto));
                    colTitulos[1].BorderWidth = 0;
                    colTitulos[2] = new PdfPCell(new Phrase(vh.TipoCombustible, texto));
                    colTitulos[2].BorderWidth = 0;
                    colTitulos[3] = new PdfPCell(new Phrase(vh.Color, texto));
                    colTitulos[3].BorderWidth = 0;
                    colTitulos[4] = new PdfPCell(new Phrase(vh.Estado, texto));
                    colTitulos[4].BorderWidth = 0;
                    colTitulos[5] = new PdfPCell(new Phrase(vh.Precio.ToString(), texto));
                    colTitulos[5].BorderWidth = 0;

                    tabla.AddCell(colTitulos[0]);
                    tabla.AddCell(colTitulos[1]);
                    tabla.AddCell(colTitulos[2]);
                    tabla.AddCell(colTitulos[3]);
                    tabla.AddCell(colTitulos[4]);
                    tabla.AddCell(colTitulos[5]);
                }
                doc.Add(tabla);
                doc.Close();
                pdfW.Close();
                MessageBox.Show("Documento PDF generado con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs?.Close();
            }
        }

        public void AbrirPDFMarca()
        {
            if (File.Exists("ReporteMarca.pdf"))
            {
                System.Diagnostics.Process.Start("ReporteMarca.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe.El PDF no se pudo generar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GenerarPDFEstado(string estado)
        {
            FileStream fs = null;
            Document doc = null;
            string[] titulosTablas = { "Marca", "Tipo Vehiculo", "Tipo Combustible", "Color", "Estado", "Precio" };
            listVehiculo = FiltrarVhPorEstado(estado);

            try
            {
                fs = new FileStream("ReporteEstado.pdf", FileMode.Create);
                doc = new Document(PageSize.A4, 36, 36, 30, 30);

                PdfWriter pdfW = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                iTextSharp.text.Font Titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.RED);
                iTextSharp.text.Font subTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                iTextSharp.text.Font texto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Paragraph tituloPdf = new Paragraph("Reporte de Vehiculos", Titulo)
                {
                    Alignment = Element.ALIGN_CENTER
                };

                doc.Add(tituloPdf);

                doc.Add(Chunk.NEWLINE);

                PdfPTable tabla = new PdfPTable(6);
                tabla.WidthPercentage = 100;

                PdfPCell[] colTitulos = new PdfPCell[titulosTablas.Length];
                for (int i = 0; i < titulosTablas.Length; i++)
                {
                    colTitulos[i] = new PdfPCell(new Phrase(titulosTablas[i], subTitulo));
                    colTitulos[i].BackgroundColor = BaseColor.BLACK;
                    colTitulos[i].BorderWidth = 0;
                    colTitulos[i].BorderWidthBottom = 0.25f;
                    colTitulos[i].HorizontalAlignment = Element.ALIGN_CENTER;
                    colTitulos[i].VerticalAlignment = Element.ALIGN_MIDDLE;
                    tabla.AddCell(colTitulos[i]);
                }

                foreach (Vehiculo vh in listVehiculo)
                {
                    colTitulos[0] = new PdfPCell(new Phrase(vh.Marca, texto));
                    colTitulos[0].BorderWidth = 0;
                    colTitulos[1] = new PdfPCell(new Phrase(vh.TipoVehiculo, texto));
                    colTitulos[1].BorderWidth = 0;
                    colTitulos[2] = new PdfPCell(new Phrase(vh.TipoCombustible, texto));
                    colTitulos[2].BorderWidth = 0;
                    colTitulos[3] = new PdfPCell(new Phrase(vh.Color, texto));
                    colTitulos[3].BorderWidth = 0;
                    colTitulos[4] = new PdfPCell(new Phrase(vh.Estado, texto));
                    colTitulos[4].BorderWidth = 0;
                    colTitulos[5] = new PdfPCell(new Phrase(vh.Precio.ToString(), texto));
                    colTitulos[5].BorderWidth = 0;

                    tabla.AddCell(colTitulos[0]);
                    tabla.AddCell(colTitulos[1]);
                    tabla.AddCell(colTitulos[2]);
                    tabla.AddCell(colTitulos[3]);
                    tabla.AddCell(colTitulos[4]);
                    tabla.AddCell(colTitulos[5]);
                }
                doc.Add(tabla);
                doc.Close();
                pdfW.Close();
                MessageBox.Show("Documento PDF generado con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fs?.Close();
            }
        }

        public void AbrirPDFEstado()
        {
            if (File.Exists("ReporteEstado.pdf"))
            {
                System.Diagnostics.Process.Start("ReporteEstado.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe.El PDF no se pudo generar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}