using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using System.Runtime.InteropServices;

namespace Forms
{
    public partial class Form1 : Form
    {
        CN_Productos objCNProductos = new CN_Productos();
        private string idProducto = null;
        private bool editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            this.cbSector.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProductos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if(this.editar == false)
            {
                try
                {
                    if (ChequeoCamposCompletos())
                    {

                        objCNProductos.InsertarProductos(txtNombre.Text, (this.cbSector.SelectedIndex + 1).ToString(), txtPrecio.Text, txtStock.Text);
                        MessageBox.Show("Se insertó correctamente");
                        MostrarProductos();
                        LimpiarCampos();
                    }
                    else { MessageBox.Show("Complete todos los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                if(ChequeoCamposCompletos())
                {
                    try
                    {
                        objCNProductos.EditarProducto(txtNombre.Text, (this.cbSector.SelectedIndex + 1).ToString(), txtPrecio.Text, txtStock.Text, this.idProducto);
                        MessageBox.Show("Se Edito correctamente");
                        MostrarProductos();
                        LimpiarCampos();
                        this.editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else { MessageBox.Show("Complete todos los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            

        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editar = false;
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void LimpiarCampos()
        {
            this.txtNombre.Clear();
            this.txtPrecio.Clear();
            this.txtStock.Clear();
            this.cbSector.SelectedIndex = 0;
            this.txtNombre.Focus();
        }

        public bool ChequeoCamposCompletos()
        {
            if (this.txtNombre.Text != "" && this.txtPrecio.Text != "" && this.txtStock.Text != "")
            {
                return true;
            }
            else { return false; }
        }

        public int CapturoIdSector(string sector)
        {
            if (sector == "Perfumeria")
            {
                return 1;
            }
            else if (sector == "Limpieza")
            {
                return 2;
            }
            else if (sector == "Lacteos")
            {
                return 3;
            }
            else if (sector == "Fiambres")
            {
                return 4;
            }
            else if (sector == "Verduleria")
            {
                return 5;
            }
            else if (sector == "Carniceria")
            {
                return 6;
            }
            else return 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnEdito_Click(object sender, EventArgs e)
        {
            this.editar = true;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int comboBox = CapturoIdSector(dataGridView1.CurrentRow.Cells["Sector"].Value.ToString());

                this.txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                this.cbSector.SelectedIndex = comboBox - 1;
                this.txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                this.txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Error, debe seleccionar un registro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnElimino_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("¿Seguro de eliminar?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                        objCNProductos.EliminarProducto(idProducto);
                        MessageBox.Show("Registro eliminado exitosamente", "ELIMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarProductos();
                        LimpiarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error, debe seleccionar un registro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
