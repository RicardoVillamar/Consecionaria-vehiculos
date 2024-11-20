using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Control
{
    public class CtrlCliente
    {
        Conexion coxclient = new Conexion();
        DatosCliente datclient = new DatosCliente();
        private static List<Cliente> listaClient = new List<Cliente>();

        public static List<Cliente> ListaClient { get => listaClient; set => listaClient = value; }

        
        //*Generar PDF*

        public void GenerarPDF()
        {
            FileStream stream = null;
            Document document = null;
            string[] etiqueta = { "idCliente", "Nombrecliente", "Apellidocliente", "Cedulacliente", "Correocliente", "telefonocliente" };
            listaClient = ConsultClient();

            try
            {
                // Crear un documento PDF
                stream = new FileStream("resultados.pdf", FileMode.Create);

                document = new Document(PageSize.A4, 5, 5, 7, 7);

                PdfWriter pdf = PdfWriter.GetInstance(document, stream);

                document.Open();

                iTextSharp.text.Font Miletra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                iTextSharp.text.Font letra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                // Agregar contenido al documento PDF
                Paragraph titulo = new Paragraph("Consulta de Datos de Cliente")
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

                foreach (Cliente serv in listaClient)
                {
                    colEti[0] = new PdfPCell(new Phrase(serv.IdCliente, letra));
                    colEti[0].BorderWidth = 0;
                    colEti[1] = new PdfPCell(new Phrase(serv.Nombre, letra));
                    colEti[1].BorderWidth = 0;
                    colEti[2] = new PdfPCell(new Phrase(serv.Apellido, letra));
                    colEti[2].BorderWidth = 0;
                    colEti[3] = new PdfPCell(new Phrase(serv.Cedula, letra));
                    colEti[3].BorderWidth = 0;
                    colEti[4] = new PdfPCell(new Phrase(serv.Email.ToString(), letra));
                    colEti[4].BorderWidth = 0;
                    colEti[5] = new PdfPCell(new Phrase(serv.Telefono.ToString(), letra));
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
                // Asegurarse de cerrar el FileStream incluso si ocurre una excepción
                stream?.Close();
            }

        }
        public void AbrirPDF()
        {
            if (File.Exists("resultados.pdf"))
            {
                System.Diagnostics.Process.Start("resultados.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe. Primero genera el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string RegistrarCliente(string idCliente, string Nombrecliente, string Apellidocliente, string Cedulacliente, string Telefonocliente, string Correocliente)
        {
            string msj = "";
            Cliente client = null;
            if (Nombrecliente != null)
            {
                client = new Cliente(idCliente, Nombrecliente, Apellidocliente, Cedulacliente, Telefonocliente, Correocliente);
                listaClient.Add(client);
                InsertClient(client);
                msj = client.ToString();
            }
            return msj;
        }
        public string ActulizarCliente(string id, string telefonoCliente, string correoCliente)
        {
            string msj = "Cliente actualizado correctamente";

            Cliente client = listaClient.FirstOrDefault(s => s.IdCliente == id);

            if (client != null)
            {
                client.Telefono = telefonoCliente;
                client.Email = correoCliente;
                ActualizarClient(client.IdCliente, telefonoCliente, correoCliente);
            }
            else
            {
                msj = "No se pudo encontrar cliente";
            }
            return msj;
        }
        public void InsertClient(Cliente inserclient)
        {
            string msj = string.Empty;
            string msjCnx = coxclient.Conectar();

            if (msjCnx[0] == '1')
            {
                msj = datclient.RegistrarCliente(inserclient, coxclient.Cn);
                if (msjCnx[0] == '0')
                {
                    MessageBox.Show("Ocurrió un error: " + msjCnx);
                }
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            coxclient.Cerrar();
        }
        public string ActualizarClient(string id, string telf, string email)
        {
            string msj ="";
            string msjCnx = coxclient.Conectar();
            if (msjCnx[0] == '1')
            {
                msj = datclient.ActualizarCliente(id, telf, email, coxclient.Cn);
            }else if (msjCnx[0]=='0')
            {
                MessageBox.Show("Error");
            }
            coxclient.Cerrar();
            return msj;
        }

        //Consulta y LLenarGrid
        private List<Cliente> ConsultClient()
        {
            List<Cliente> listclie = new List<Cliente>();
            string msj = string.Empty;
            string msjCnx = coxclient.Conectar();

            if (msjCnx[0] == '1')
            {
                listclie = datclient.ConsultarCliente(coxclient.Cn);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            coxclient.Cerrar();
            return listclie;
        }
        public string DardebajaCliente(string cedula, string nombre, string apellido, string telefono, string correo)
        {
            string msj = "Se ha eliminado correctamente";
            Cliente client = listaClient.FirstOrDefault(c => c.Cedula == cedula && c.Nombre == nombre && c.Apellido == apellido &&
            c.Telefono == telefono && c.Email == correo);
            if (client != null)
            {
                listaClient.Remove(client);
            }
            else
            {
                msj = "Cliente no encontrado";
            }
            return msj;
        }

        public string BajarCliente(string id)
        {
            string m = "No se ha encontrado cliente";
            string msj;
            string cnx = coxclient.Conectar();
            if(cnx[0]=='1')
            {
                msj=datclient.EliminarCliente(id, coxclient.Cn);
                m = "Cliente fue dado de baja correctamente";
            }else if(cnx[0] == '0')
                {
                MessageBox.Show("Error");
                }
            coxclient.Cerrar();
            return m;
        }
        public int BuscarNombre(String Nombre)
        {
            int i = -1;
            string msj = "Nombre no encontrado";
            Cliente x = listaClient.Find(a => a.Nombre.Contains(Nombre));
            if (x != null)
            {
                i = listaClient.IndexOf(x);
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
            Cliente x = listaClient.Find(a => a.Cedula.Equals(cedula));
            if (x != null)
            {
                i = listaClient.IndexOf(x);
                Console.WriteLine("\n" + x.ToString() + "\n");
            }
            else
            {
                Console.WriteLine(msj);
            }
            return i;
        }

        public string generarId()
        {
            string id = "";
            Random r = new Random();
            id = r.Next(1, 1000).ToString();
            return id;
        }

        public void LlenarGrid(DataGridView dgvClienteReporte)
        {
            int i = 0;
            dgvClienteReporte.Rows.Clear();//Limpia las filas del datagridview
            listaClient = ConsultClient();
            if (listaClient.Count>0)
            {

                foreach (Cliente x in listaClient)
                {
                i = dgvClienteReporte.Rows.Add();
                dgvClienteReporte.Rows[i].Cells["colIdCliente"].Value = x.IdCliente;
                dgvClienteReporte.Rows[i].Cells["colNombre"].Value = x.Nombre;
                dgvClienteReporte.Rows[i].Cells["colApellido"].Value = x.Apellido;
                dgvClienteReporte.Rows[i].Cells["colCedula"].Value = x.Cedula;
                dgvClienteReporte.Rows[i].Cells["colTelefono"].Value = x.Telefono;
                dgvClienteReporte.Rows[i].Cells["colCorreo"].Value = x.Email;
                }
            }
        }
        public void ActualizarFilaEnGrid(DataGridViewRow fila, string nombre)
        {
            Cliente client = listaClient.FirstOrDefault(s => s.Nombre == nombre);
            if (client != null)
            {
                fila.Cells["colTelefono"].Value = client.Telefono;
                fila.Cells["colCorreo"].Value = client.Email;
            }
        }

        public void LlenarReportePorNombre(DataGridView dgvClienteReporte, string nombre)
        {
            int i = 0;
            dgvClienteReporte.Rows.Clear();
            listaClient = FiltrarCPorNombre(nombre);
            if (listaClient.Count > 0)
            {
                foreach (Cliente x in listaClient)
                {
                    i = dgvClienteReporte.Rows.Add();
                    dgvClienteReporte.Rows[i].Cells["colIdCliente"].Value = x.IdCliente;
                    dgvClienteReporte.Rows[i].Cells["colNombre"].Value = x.Nombre;
                    dgvClienteReporte.Rows[i].Cells["colApellido"].Value = x.Apellido;
                    dgvClienteReporte.Rows[i].Cells["colCedula"].Value = x.Cedula;
                    dgvClienteReporte.Rows[i].Cells["colTelefono"].Value = x.Telefono;
                    dgvClienteReporte.Rows[i].Cells["colCorreo"].Value = x.Email;
                }
            }
        }

        private List<Cliente> FiltrarCPorNombre(string nombre)
        {
            List<Cliente> lstC = new List<Cliente>();
            string msj = string.Empty;
            string msjCnx = coxclient.Conectar();

            if (msjCnx[0] == '1')
            {
                lstC = datclient.FiltarCliente(coxclient.Cn, nombre);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            coxclient.Cerrar();
            return lstC;
        }

        public void LlenarReportePorCedula(DataGridView dgvClienteReporte, string cedula)
        {
            int i = 0;
            dgvClienteReporte.Rows.Clear();
            listaClient = FiltrarCPorCedula(cedula);
            if (listaClient.Count > 0)
            {
                foreach (Cliente x in listaClient)
                {
                    i = dgvClienteReporte.Rows.Add();
                    dgvClienteReporte.Rows[i].Cells["colIdCliente"].Value = x.IdCliente;
                    dgvClienteReporte.Rows[i].Cells["colNombre"].Value = x.Nombre;
                    dgvClienteReporte.Rows[i].Cells["colApellido"].Value = x.Apellido;
                    dgvClienteReporte.Rows[i].Cells["colCedula"].Value = x.Cedula;
                    dgvClienteReporte.Rows[i].Cells["colTelefono"].Value = x.Telefono;
                    dgvClienteReporte.Rows[i].Cells["colCorreo"].Value = x.Email;
                }
            }
        }

        private List<Cliente> FiltrarCPorCedula(string cedula)
        {
            List<Cliente> lstC = new List<Cliente>();
            string msj = string.Empty;
            string msjCnx = coxclient.Conectar();

            if (msjCnx[0] == '1')
            {
                lstC = datclient.FiltarClienteC(coxclient.Cn, cedula);
            }
            else if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msj);
            }
            coxclient.Cerrar();
            return lstC;
        }

        public void GenerarPDFNombre(string nombre)
        {
            FileStream stream = null;
            Document document = null;
            string[] etiqueta = { "idCliente", "Nombrecliente", "Apellidocliente", "Cedulacliente", "Correocliente", "telefonocliente" };
            listaClient = FiltrarCPorNombre(nombre);

            try
            {
                // Crear un documento PDF
                stream = new FileStream("resultadosNombre.pdf", FileMode.Create);

                document = new Document(PageSize.A4, 5, 5, 7, 7);

                PdfWriter pdf = PdfWriter.GetInstance(document, stream);

                document.Open();

                iTextSharp.text.Font Miletra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                iTextSharp.text.Font letra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                // Agregar contenido al documento PDF
                Paragraph titulo = new Paragraph("Consulta de Datos de Cliente")
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

                foreach (Cliente serv in listaClient)
                {
                    colEti[0] = new PdfPCell(new Phrase(serv.IdCliente, letra));
                    colEti[0].BorderWidth = 0;
                    colEti[1] = new PdfPCell(new Phrase(serv.Nombre, letra));
                    colEti[1].BorderWidth = 0;
                    colEti[2] = new PdfPCell(new Phrase(serv.Apellido, letra));
                    colEti[2].BorderWidth = 0;
                    colEti[3] = new PdfPCell(new Phrase(serv.Cedula, letra));
                    colEti[3].BorderWidth = 0;
                    colEti[4] = new PdfPCell(new Phrase(serv.Email.ToString(), letra));
                    colEti[4].BorderWidth = 0;
                    colEti[5] = new PdfPCell(new Phrase(serv.Telefono.ToString(), letra));
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
                // Asegurarse de cerrar el FileStream incluso si ocurre una excepción
                stream?.Close();
            }
        }

        public void AbrirPDFNombre()
        {
            if (File.Exists("resultadosNombre.pdf"))
            {
                System.Diagnostics.Process.Start("resultadosNombre.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe. Primero genera el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GenerarPDFCedula(string cedula)
        {
            FileStream stream = null;
            Document document = null;
            string[] etiqueta = { "idCliente", "Nombrecliente", "Apellidocliente", "Cedulacliente", "Correocliente", "telefonocliente" };
            listaClient = FiltrarCPorCedula(cedula);

            try
            {
                // Crear un documento PDF
                stream = new FileStream("resultadosCedula.pdf", FileMode.Create);

                document = new Document(PageSize.A4, 5, 5, 7, 7);

                PdfWriter pdf = PdfWriter.GetInstance(document, stream);

                document.Open();

                iTextSharp.text.Font Miletra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                iTextSharp.text.Font letra = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                    12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                // Agregar contenido al documento PDF
                Paragraph titulo = new Paragraph("Consulta de Datos de Cliente")
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

                foreach (Cliente serv in listaClient)
                {
                    colEti[0] = new PdfPCell(new Phrase(serv.IdCliente, letra));
                    colEti[0].BorderWidth = 0;
                    colEti[1] = new PdfPCell(new Phrase(serv.Nombre, letra));
                    colEti[1].BorderWidth = 0;
                    colEti[2] = new PdfPCell(new Phrase(serv.Apellido, letra));
                    colEti[2].BorderWidth = 0;
                    colEti[3] = new PdfPCell(new Phrase(serv.Cedula, letra));
                    colEti[3].BorderWidth = 0;
                    colEti[4] = new PdfPCell(new Phrase(serv.Email.ToString(), letra));
                    colEti[4].BorderWidth = 0;
                    colEti[5] = new PdfPCell(new Phrase(serv.Telefono.ToString(), letra));
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
                // Asegurarse de cerrar el FileStream incluso si ocurre una excepción
                stream?.Close();
            }
        }

        public void AbrirPDFCedula()
        {
            if (File.Exists("resultadosCedula.pdf"))
            {
                System.Diagnostics.Process.Start("resultadosCedula.pdf");
            }
            else
            {
                MessageBox.Show("El archivo PDF no existe. Primero genera el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int verificarCliente(string cedula)
        {
            string msjCnx = coxclient.Conectar();

            if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msjCnx);
                return 0;
            }


            int res = datclient.verificar(cedula, coxclient.Cn);

            coxclient.Cerrar();

            return res;
        }

        public int obtenerIdCliente(string cedula)
        {
            string msjCnx = coxclient.Conectar();

            if (msjCnx[0] == '0')
            {
                MessageBox.Show("Ocurrió un error: " + msjCnx);
                return 0;
            }


            Cliente cliente = datclient.ObtenerClientePorCedula(cedula, coxclient.Cn);
            int id = Convert.ToInt32(cliente.IdCliente);
            coxclient.Cerrar();
            return id;
        }
    }
}
