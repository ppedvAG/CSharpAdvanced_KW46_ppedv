using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseFirstSample
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (MovieDbContext ctx = new MovieDbContext()) //Baue Verbdinung zu Datenbank auf
            {
                bindingSource1.DataSource = ctx.Movies.ToList(); //Select * From Movies -> ERgbnis wurde in eine Liste gelegt
                
                
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = bindingSource1;
            }
        }
    }
}
