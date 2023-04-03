namespace PasswordGeneratorApplication
{
    public partial class PasswordGenerator : Form
    {
        public PasswordGenerator()
        {
            InitializeComponent();
        }

        public Service GeneratingService
        {
            get;
            private set;
        }

        private void GeneratePassword(object sender, EventArgs e) 
        {
            bool[] requirements = new bool[] { true };
        }
    }
}