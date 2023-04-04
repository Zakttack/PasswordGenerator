namespace PasswordGeneratorApplication
{
    public partial class PasswordGenerator : Form
    {
        private Service generatingService;
        public PasswordGenerator()
        {
            InitializeComponent();
        }

        private void GeneratePassword(object sender, EventArgs e) 
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            bool error = false;
            string text = "";
            string caption = "";
            try
            {
                int min, max;
                if (!int.TryParse(minInputBox.Text, out min))
                {
                    error = !error;
                    text += $"{minInputBox.Text} is not a number";
                    caption += "Input is not a number";
                }
                else if (!int.TryParse(maxInputBox.Text, out max))
                {
                    error = !error;
                    text += $"{maxInputBox.Text} is not a number";
                    caption += "Input is not a number";
                }
                else
                {
                    bool[] requirements = new bool[] { containsCapitalInputBox.Checked,
                        containsDigitsInputBox.Checked, containsLowercaseLettersInputBox.Checked,
                        containsSpecialCharactersInputBox.Checked};
                    generatingService = new Service(requirements, min, max);
                    text += $"Your password is: {generatingService.Password}";
                    caption += "Password Info";
                }
            }
            catch(Exception ex)
            {
                error = !error;
                text += ex.Message;
                caption += ex.GetType().Name;
            }
            finally
            {
                DialogResult result = MessageBox.Show(text, caption, buttons, error ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                if (result == DialogResult.No ) 
                {
                    Close();
                }
            }
        }

        private void LoadGenerator(object sender, EventArgs e)
        {

        }
    }
}