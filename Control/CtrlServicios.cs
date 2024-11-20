using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Modelo;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Control
{
    public class CtrlServicios
    {
        // Modulo de Servicio elaborado por: Quiñonez Castrellon Anthony Joel

        Conexion conServ = new Conexion();
        DatosServicios servConex = new DatosServicios();
        private static List<Servicio> listaServ = new List<Servicio>();
        public static List<Servicio> ListaServ { get => listaServ; set => listaServ = value; }

        //*Registrar*
        public void InsertServ(Servicio serv)
        {
            string msj = string.Empty;
            string msjCnx = conServ.Conectar();

            if (msjCnx[0] == '1')
            {
                msj = servConex.IngresarServ(serv, conServ.Cn);
                if (msjCnx[0] == '0')
                {
                    MessageBox.Show("Ocurrió un error: " + msjCnx);
                }
            }
            if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conServ.Cerrar();
        }
        public string RegistrarServicio(string idServicio, string tipoVehiculo, string cedula, string servicios, DateTime fecha, float costo)
        {
            string msj = "";
            Servicio serv = null;
            if (tipoVehiculo != null)
            {
                serv = new Servicio(idServicio, tipoVehiculo, cedula, servicios, fecha, costo);
                listaServ.Add(serv);
                InsertServ(serv);
                msj = serv.ToString();
            }
            return msj;
        }

        //*Eliminar*
        public string EliminarServicio(string idServ)
        {
            string msj = string.Empty;
            string x = "";
            string msjCnx = conServ.Conectar();
            if (msjCnx[0] == '1')
            { 
                msj = servConex.EliminarServ(idServ,conServ.Cn);
                x="Se a eliminado correctamente ";
                if (msjCnx[0] == '0')
                {
                    MessageBox.Show("Ocurrió un error: " + msjCnx);
                }
            }
            conServ.Cerrar();
            return x;
        }

        //*Actualizar*
        public string ActualizarServ(string idServ, string nTipoVehiculo, string nServicio, DateTime nFecha, float nCosto)
        {
            string msj = string.Empty;
            string msjCnx = conServ.Conectar();

            if (msjCnx[0] == '1')
            {
                msj = servConex.ActualizarServ(idServ, nTipoVehiculo, nServicio, nFecha, nCosto, conServ.Cn);
            }
            else 
            if (msjCnx[0] == '0')
            { 
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conServ.Cerrar();
            return msj;
        }
        
        public string ModificarServicio(string idServ, string nTipoVehiculo, string nServicio, DateTime nFecha, float nCosto)
        {
            string msj = "Servicio modificado exitosamente";

            Servicio serv = listaServ.FirstOrDefault(s => s.IdServicio == idServ);

            if (serv != null)
            {
                serv.TipoVehiculo = nTipoVehiculo;
                serv.Servicios = nServicio;
                serv.Fecha = nFecha;
                serv.Costo = nCosto;
                ActualizarServ(serv.IdServicio,nTipoVehiculo,nServicio,nFecha,nCosto);
            }
            else
            {
                msj = "No se pudo encontrar el servicio";
            }
            return msj;
        }

        
        // *Busquedad por Servicio y Cedula*
        public int BuscarServi(String servicios)
        {
            int i = -1;
            string msj = "Servicio no encontrado";
            Servicio x = listaServ.Find(a => a.Servicios.Contains(servicios));
            if (x != null)
            {
                i = listaServ.IndexOf(x);
                Console.WriteLine("\n" + x.ToString());
            }
            else
            {
                Console.WriteLine(msj);
            }
            return i;

        }
        public int BuscarCedula(string cedula)
        {
            int i = -1;
            string msj = "Cedula del cliente no encontrada";
            Servicio x = listaServ.Find(a => a.Cedula.Equals(cedula));
            if (x != null)
            {
                i = listaServ.IndexOf(x);
                Console.WriteLine("\n" + x.ToString() + "\n");
            }
            else
            {
                Console.WriteLine(msj);
            }
            return i;
        }

        //Genera ID
        public string generarId()
        {
            string id = "";
            Random r = new Random();
            id = r.Next(1, 1000).ToString();
            return id;
        }
        
        //Consulta y LLenarGrid
        private List<Servicio> ConsultServicio()
        {
            List<Servicio> listserv = new List<Servicio>();
            string msj = string.Empty;
            string msjCnx = conServ.Conectar();

            if (msjCnx[0] == '1')
            {
                listserv = servConex.ConsultServicio(conServ.Cn);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conServ.Cerrar();
            return listserv;
        }

        public void ActualizarFilaEnGrid(DataGridViewRow fila, string idServ)
        {
            Servicio serv = listaServ.FirstOrDefault(s => s.IdServicio == idServ);
            if (serv != null)
            {
                fila.Cells["colTipodeVehiculo"].Value = serv.TipoVehiculo;
                fila.Cells["colServicio"].Value = serv.Servicios;
                fila.Cells["colFecha"].Value = serv.Fecha;
                fila.Cells["colCosto"].Value = serv.Costo;
            }
        }
        public void LlenarGrid(DataGridView dgvServicios)
        {
            int i = 0;
            dgvServicios.Rows.Clear();
            listaServ = ConsultServicio();
            if(listaServ.Count > 0)
            {
                foreach (Servicio x in listaServ)
                {
                    i = dgvServicios.Rows.Add();
                    dgvServicios.Rows[i].Cells["colidServicio"].Value = x.IdServicio;
                    dgvServicios.Rows[i].Cells["colCedula"].Value = x.Cedula;
                    dgvServicios.Rows[i].Cells["colTipodeVehiculo"].Value = x.TipoVehiculo;
                    dgvServicios.Rows[i].Cells["colServicio"].Value = x.Servicios;
                    dgvServicios.Rows[i].Cells["colFecha"].Value = x.Fecha;
                    dgvServicios.Rows[i].Cells["colCosto"].Value = x.Costo;
                }
            }
            
        }

        //Llenar Grid Filtrado Cedula
        private List<Servicio> ConsultCedula(string cedula)
        {
            List<Servicio> listserv = new List<Servicio>();
            string msj = string.Empty;
            string msjCnx = conServ.Conectar();

            if (msjCnx[0] == '1')
            {
                listserv = servConex.ConsultCedula(conServ.Cn, cedula);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conServ.Cerrar();
            return listserv;
        }
        public void LlenarCedula(DataGridView dgvServicios, string cedula)
        {
            int i = 0;
            dgvServicios.Rows.Clear();
            listaServ = ConsultCedula(cedula);
            if (listaServ.Count > 0)
            {
                foreach (Servicio x in listaServ)
                {
                    i = dgvServicios.Rows.Add();
                    dgvServicios.Rows[i].Cells["colidServicio"].Value = x.IdServicio;
                    dgvServicios.Rows[i].Cells["colCedula"].Value = x.Cedula;
                    dgvServicios.Rows[i].Cells["colTipodeVehiculo"].Value = x.TipoVehiculo;
                    dgvServicios.Rows[i].Cells["colServicio"].Value = x.Servicios;
                    dgvServicios.Rows[i].Cells["colFecha"].Value = x.Fecha;
                    dgvServicios.Rows[i].Cells["colCosto"].Value = x.Costo;
                }
            }

        }

        //Llenar Grid Filtrado Servicio
        private List<Servicio> ConsultFilServ(string servicios)
        {
            List<Servicio> listserv = new List<Servicio>();
            string msj = string.Empty;
            string msjCnx = conServ.Conectar();

            if (msjCnx[0] == '1')
            {
                listserv = servConex.ConsultFilServ(conServ.Cn, servicios);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            conServ.Cerrar();
            return listserv;
        }
        public void LlenarFilServ(DataGridView dgvServicios,string servicios)
        {
            int i = 0;
            dgvServicios.Rows.Clear();
            listaServ = ConsultFilServ(servicios);
            if (listaServ.Count > 0)
            {
                foreach (Servicio x in listaServ)
                {
                    i = dgvServicios.Rows.Add();
                    dgvServicios.Rows[i].Cells["colidServicio"].Value = x.IdServicio;
                    dgvServicios.Rows[i].Cells["colCedula"].Value = x.Cedula;
                    dgvServicios.Rows[i].Cells["colTipodeVehiculo"].Value = x.TipoVehiculo;
                    dgvServicios.Rows[i].Cells["colServicio"].Value = x.Servicios;
                    dgvServicios.Rows[i].Cells["colFecha"].Value = x.Fecha;
                    dgvServicios.Rows[i].Cells["colCosto"].Value = x.Costo;
                }
            }

        }
        

        //*Abrir PDF*
        public void AbrirPDF()
        {
            if (File.Exists("Reporte de Servicios de Consecionaria.pdf"))
            {
                System.Diagnostics.Process.Start("Reporte de Servicios de Consecionaria.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe. Primero genera el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //*Generar PDF*
        public void GenerarPDF()
        {
            FileStream stream = null;
            Document document = null;
            string[] etiqueta = { "idServicio", "Cedula", "TipodeVehiculo", "Servicios", "Fecha", "Costo"};
            listaServ = ConsultServicio();

            try
            {
                stream = new FileStream("Reporte de Servicios de Consecionaria.pdf", FileMode.Create);

                document = new Document(PageSize.A4, 5, 5, 7, 7);

                PdfWriter pdf = PdfWriter.GetInstance(document, stream);

                document.Open();

                iTextSharp.text.Font Miletra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                iTextSharp.text.Font letra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Paragraph titulo = new Paragraph("Consulta de Datos de Servicios de Consecionaria")
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(titulo);
                document.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(6);
                table.WidthPercentage = 100;

                PdfPCell[] colEti = new PdfPCell[etiqueta.Length];
                for (int i = 0; i < etiqueta.Length; i++)
                {
                    colEti[i] = new PdfPCell(new Phrase(etiqueta[i], Miletra));
                    colEti[i].BorderWidth = 0;
                    colEti[i].BorderWidthBottom = 0.25f;
                    table.AddCell(colEti[i]);
                }

                foreach (Servicio serv in listaServ)
                {
                    colEti[0] = new PdfPCell(new Phrase(serv.IdServicio, letra));
                    colEti[0].BorderWidth = 0;
                    colEti[1] = new PdfPCell(new Phrase(serv.Cedula, letra));
                    colEti[1].BorderWidth = 0;
                    colEti[2] = new PdfPCell(new Phrase(serv.TipoVehiculo, letra));
                    colEti[2].BorderWidth = 0;
                    colEti[3] = new PdfPCell(new Phrase(serv.Servicios, letra));
                    colEti[3].BorderWidth = 0;
                    colEti[4] = new PdfPCell(new Phrase(serv.Fecha.ToString(), letra));
                    colEti[4].BorderWidth = 0;
                    colEti[5] = new PdfPCell(new Phrase(serv.Costo.ToString(), letra));
                    colEti[5].BorderWidth = 0;            

                    table.AddCell(colEti[0]);
                    table.AddCell(colEti[1]);
                    table.AddCell(colEti[2]);
                    table.AddCell(colEti[3]);
                    table.AddCell(colEti[4]);
                    table.AddCell(colEti[5]);
                }
                document.Add(table);
                document.Close();
                pdf.Close();
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
                stream?.Close();
            }

        }

        //*Abrir y Generar pdf Reporte de Cedula
        public void AbrirPDFCed()
        {
            if (File.Exists("Reporte de Filtro Cedula.pdf"))
            {
                System.Diagnostics.Process.Start("Reporte de Filtro Cedula.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe. Primero genera el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GenerarPDFCed(string cedula)
        {
            
            FileStream stream = null;
            Document document = null;
            string[] etiqueta = { "idServicio", "Cedula", "TipodeVehiculo", "Servicios", "Fecha", "Costo" };
            listaServ = ConsultCedula(cedula);

            try
            {
                stream = new FileStream("Reporte de Filtro Cedula.pdf", FileMode.Create);

                document = new Document(PageSize.A4, 5, 5, 7, 7);

                PdfWriter pdf = PdfWriter.GetInstance(document, stream);

                document.Open();

                iTextSharp.text.Font Miletra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                iTextSharp.text.Font letra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Paragraph titulo = new Paragraph("Consulta de Datos de Servicios de Consecionaria")
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(titulo);
                document.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(6);
                table.WidthPercentage = 100;

                PdfPCell[] colEti = new PdfPCell[etiqueta.Length];
                for (int i = 0; i < etiqueta.Length; i++)
                {
                    colEti[i] = new PdfPCell(new Phrase(etiqueta[i], Miletra));
                    colEti[i].BorderWidth = 0;
                    colEti[i].BorderWidthBottom = 0.25f;
                    table.AddCell(colEti[i]);
                }

                foreach (Servicio serv in listaServ)
                {
                    colEti[0] = new PdfPCell(new Phrase(serv.IdServicio, letra));
                    colEti[0].BorderWidth = 0;
                    colEti[1] = new PdfPCell(new Phrase(serv.Cedula, letra));
                    colEti[1].BorderWidth = 0;
                    colEti[2] = new PdfPCell(new Phrase(serv.TipoVehiculo, letra));
                    colEti[2].BorderWidth = 0;
                    colEti[3] = new PdfPCell(new Phrase(serv.Servicios, letra));
                    colEti[3].BorderWidth = 0;
                    colEti[4] = new PdfPCell(new Phrase(serv.Fecha.ToString(), letra));
                    colEti[4].BorderWidth = 0;
                    colEti[5] = new PdfPCell(new Phrase(serv.Costo.ToString(), letra));
                    colEti[5].BorderWidth = 0;

                    table.AddCell(colEti[0]);
                    table.AddCell(colEti[1]);
                    table.AddCell(colEti[2]);
                    table.AddCell(colEti[3]);
                    table.AddCell(colEti[4]);
                    table.AddCell(colEti[5]);
                }
                document.Add(table);
                document.Close();
                pdf.Close();
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
                stream?.Close();
            }

        }

        //Abrir y Generar PDF Filt de Servicio
        public void AbrirPDFServ()
        {
            if (File.Exists("Reporte de Filtro Servicios.pdf"))
            {
                System.Diagnostics.Process.Start("Reporte de Filtro Servicios.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe. Primero genera el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GenerarPDFServ(string servicios)
        {

            FileStream stream = null;
            Document document = null;
            string[] etiqueta = { "idServicio", "Cedula", "TipodeVehiculo", "Servicios", "Fecha", "Costo" };
            listaServ = ConsultFilServ(servicios);

            try
            {
                stream = new FileStream("Reporte de Filtro Servicios.pdf", FileMode.Create);

                document = new Document(PageSize.A4, 5, 5, 7, 7);

                PdfWriter pdf = PdfWriter.GetInstance(document, stream);

                document.Open();

                iTextSharp.text.Font Miletra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                iTextSharp.text.Font letra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Paragraph titulo = new Paragraph("Consulta de Datos de Servicios de Consecionaria")
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(titulo);
                document.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(6);
                table.WidthPercentage = 100;

                PdfPCell[] colEti = new PdfPCell[etiqueta.Length];
                for (int i = 0; i < etiqueta.Length; i++)
                {
                    colEti[i] = new PdfPCell(new Phrase(etiqueta[i], Miletra));
                    colEti[i].BorderWidth = 0;
                    colEti[i].BorderWidthBottom = 0.25f;
                    table.AddCell(colEti[i]);
                }

                foreach (Servicio serv in listaServ)
                {
                    colEti[0] = new PdfPCell(new Phrase(serv.IdServicio, letra));
                    colEti[0].BorderWidth = 0;
                    colEti[1] = new PdfPCell(new Phrase(serv.Cedula, letra));
                    colEti[1].BorderWidth = 0;
                    colEti[2] = new PdfPCell(new Phrase(serv.TipoVehiculo, letra));
                    colEti[2].BorderWidth = 0;
                    colEti[3] = new PdfPCell(new Phrase(serv.Servicios, letra));
                    colEti[3].BorderWidth = 0;
                    colEti[4] = new PdfPCell(new Phrase(serv.Fecha.ToString(), letra));
                    colEti[4].BorderWidth = 0;
                    colEti[5] = new PdfPCell(new Phrase(serv.Costo.ToString(), letra));
                    colEti[5].BorderWidth = 0;

                    table.AddCell(colEti[0]);
                    table.AddCell(colEti[1]);
                    table.AddCell(colEti[2]);
                    table.AddCell(colEti[3]);
                    table.AddCell(colEti[4]);
                    table.AddCell(colEti[5]);
                }
                document.Add(table);
                document.Close();
                pdf.Close();
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
                stream?.Close();
            }

        }
    }
}