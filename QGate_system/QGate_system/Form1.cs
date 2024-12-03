using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace QGate_system
{
    public partial class Form1 : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public Form1()
        {
            InitializeComponent();

            // Initialize PrintDocument
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            // Initialize PrintPreviewDialog
            printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };

            // Adding buttons for print and preview (if not already in designer)
            Button previewButton = new Button
            {
                Text = "Preview",
                Location = new Point(10, 10)
            };
            previewButton.Click += PreviewButton_Click;
            Controls.Add(previewButton);

            Button printButton = new Button
            {
                Text = "Print",
                Location = new Point(100, 10)
            };
            printButton.Click += PrintButton_Click;
            Controls.Add(printButton);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Printing document...");
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine("Print error: " + ex.Message);
            }
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Showing print preview...");
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine("Preview error: " + ex.Message);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Console.WriteLine("PrintPage event called.");
                // This is where you define what to print
                string text = "Hello, World!";
                Font font = new Font("Arial", 16);
                e.Graphics.DrawString(text, font, Brushes.Black, new PointF(100, 100));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in PrintPage: " + ex.Message);
                Console.WriteLine("PrintPage error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
