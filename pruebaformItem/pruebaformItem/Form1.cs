namespace pruebaformItem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 10; i++) 
            {
                itemPrueba item = new itemPrueba();
                //if (flpItems.Controls.Count > 0)
                //{
                //    flpItems.Controls.Clear();
                //}
                //else
                
                flpItems.Controls.Add(item);
                
                
            }
        }
    }
}
