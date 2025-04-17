using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ClasificadorInteligente
{
    public partial class FormOrganiza : Form
    {
        String RutaCarpeta = String.Empty;
        public FormOrganiza()
        {
            InitializeComponent();
        }

        private void BtElegirCarpeta_Click(object sender, EventArgs e)
        {
            try
            {
                var folderDialog = new FolderBrowserDialog();

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Directory.Exists(folderDialog.SelectedPath))
                    {
                        RutaCarpeta = folderDialog.SelectedPath;
                        TxtRuta.Text = RutaCarpeta;
                    }
                    else
                    {
                        MessageBox.Show("La carpeta seleccionada no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Algo ha fallado: " + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TxtRuta.Text))
                {
                    String[] Archivos = Directory.GetFiles(RutaCarpeta);

                    int ContadoArchivos = Archivos.Count();
                    int ContadorArchivosProcesados = 0;
                    int ProgresoActual = 0;

                    String ImagenesPath = Path.Combine(RutaCarpeta, "Imagenes");
                    String DocumentosPath = Path.Combine(RutaCarpeta, "Documentos");
                    String VideosPath = Path.Combine(RutaCarpeta, "Videos");
                    String ArchivosPath = Path.Combine(RutaCarpeta, "Archivos");
                    String MusicaPath = Path.Combine(RutaCarpeta, "Musica");
                    String AplicacionesPath = Path.Combine(RutaCarpeta, "Aplicaciones");
                    String VirtualPath = Path.Combine(RutaCarpeta, "Virtual");
                    String CodigoPath = Path.Combine(RutaCarpeta, "Codigo");
                    String CertificadosPath = Path.Combine(RutaCarpeta, "Certicados");
                    String SinExtensionPath = Path.Combine(RutaCarpeta, "SinExtension");
                    String CarpetasPath = Path.Combine(RutaCarpeta, "Carpetas");


                    PbProceso.Minimum = 0;
                    PbProceso.Maximum = ContadoArchivos;
                    PbProceso.Value = 0;

                    if (Archivos.Count() > 0)
                    {
                        foreach (var Archivo in Archivos)
                        {
                            String Extension = Path.GetExtension(Archivo).ToLower();
                            String Destino = string.Empty;

                            if (string.IsNullOrEmpty(Extension))
                            {
                                Destino = SinExtensionPath;
                            }
                            else
                            {

                                Destino = Extension switch
                                {
                                    // 📷 Imágenes (incluye diseño)
                                    ".jpg" or ".jpeg" or ".png" or ".gif" or ".bmp" or ".tiff" or ".webp" or
                                    ".psd" or ".ai" or ".svg" or ".eps" => ImagenesPath,

                                    // 📄 Documentos
                                    ".pdf" or ".doc" or ".docx" or ".xls" or ".xlsx" or ".ppt" or ".pptx" or
                                    ".txt" or ".rtf" or ".odt" or ".csv" or ".mdb" => DocumentosPath,

                                    // 🎞️ Vídeos
                                    ".mp4" or ".mkv" or ".avi" or ".mov" or ".wmv" or ".flv" or ".webm" => VideosPath,

                                    // 🎵 Música y audio
                                    ".mp3" or ".wav" or ".flac" or ".aac" or ".ogg" or ".wma" or ".m4a" => MusicaPath,

                                    // 🗜️ Archivos comprimidos y sistema
                                    ".zip" or ".rar" or ".7z" or ".tar" or ".gz" or ".bz2" or
                                    ".dll" or ".sys" or ".ini" or ".log" or ".tgz" or ".kml" or ".torrent" => ArchivosPath,

                                    // 💾 Aplicaciones e instaladores
                                    ".exe" or ".msi" or ".apk" or ".bat" or ".cmd" or ".vsix" => AplicacionesPath,

                                    // Discos virtuales / imágenes de sistema
                                    ".iso" or ".vdi" or ".vmdk" or ".vhd" or ".vhdx" or ".img" or ".ova" or ".ovf" => VirtualPath,

                                    // Código
                                    ".html" or ".htm" or ".css" or ".scss" or ".js" or ".ts" or
                                    ".php" or ".asp" or ".aspx" or ".cs" or ".vb" or ".cpp" or ".h" or ".java" or
                                    ".json" or ".xml" or ".yml" or ".yaml" or ".sql" or ".ps1" => CodigoPath,

                                    // Certificados
                                    ".p12" or ".pfx" => CertificadosPath,

                                    // ❓ Otros (no se moverán)
                                    _ => null
                                };
                            }

                            if (Destino != null)
                            {
                                string año = File.GetLastWriteTime(Archivo).Year.ToString();
                                string CarpetaConAño = Path.Combine(Destino, año);

                                if (!Directory.Exists(CarpetaConAño))
                                    Directory.CreateDirectory(CarpetaConAño);

                                string NombreArchivo = Path.GetFileName(Archivo);
                                string NuevaRuta = Path.Combine(CarpetaConAño, NombreArchivo);

                                int Contador = 0;

                                if (File.Exists(NuevaRuta))
                                {
                                    string extension = Path.GetExtension(NombreArchivo);
                                    string nombreSinExtension = Path.GetFileNameWithoutExtension(NombreArchivo);

                                    do
                                    {
                                        Contador++;
                                        NuevaRuta = Path.Combine(CarpetaConAño, $"{nombreSinExtension}{Contador}{extension}");
                                    }
                                    while (File.Exists(NuevaRuta));
                                }

                                File.Move(Archivo, NuevaRuta);

                                ContadorArchivosProcesados++;
                            }

                            ProgresoActual++;
                            PbProceso.Value = ProgresoActual;
                            Application.DoEvents();


                        }

                        MessageBox.Show("Archivos totales: " + ContadoArchivos + Environment.NewLine + "Archivos procesados: " + ContadorArchivosProcesados, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No hay archivos para procesar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna carpeta o la carpeta no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Algo ha fallado: " + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
