using BaseCalendar;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace BaseCalendar
{
    public class Form2 : Form
    {
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblStatus;
        LoginDatabase db = new LoginDatabase("./Db.db");
public class Form2 : Form
{
    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private Button btnSignUp;  
    private Label lblStatus;

        public Form2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login Form";

            lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(200, 60);
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font(lblUsername.Font.FontFamily, 12);
        lblUsername = new Label
        {
            Text = "Username:",
            Location = new Point(200, 60),
            AutoSize = true,
            Font = new Font(Font.FontFamily, 12)
        };

            txtUsername = new TextBox();
            txtUsername.Location = new Point(200, 95);
            txtUsername.Size = new Size(200, 30);
            txtUsername.Font = new Font(txtUsername.Font.FontFamily, 12);
        txtUsername = new TextBox
        {
            Location = new Point(200, 95),
            Size = new Size(200, 30),
            Font = new Font(Font.FontFamily, 12)
        };

            lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(200, 135);
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font(lblPassword.Font.FontFamily, 12);
        lblPassword = new Label
        {
            Text = "Password:",
            Location = new Point(200, 135),
            AutoSize = true,
            Font = new Font(Font.FontFamily, 12)
        };

            txtPassword = new TextBox();
            txtPassword.Location = new Point(200, 170);
            txtPassword.Size = new Size(200, 30);
            txtPassword.PasswordChar = '*';
            txtPassword.Font = new Font(txtPassword.Font.FontFamily, 12);
        txtPassword = new TextBox
        {
            Location = new Point(200, 170),
            Size = new Size(200, 30),
            PasswordChar = '*',
            Font = new Font(Font.FontFamily, 12)
        };

            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(250, 220);
            btnLogin.Size = new Size(100, 40);
            btnLogin.Font = new Font(btnLogin.Font.FontFamily, 12);
            btnLogin.Click += BtnLogin_Click;
        btnLogin = new Button
        {
            Text = "Login",
            Location = new Point(250, 220),
            Size = new Size(100, 40),
            Font = new Font(Font.FontFamily, 12)
        };
        btnLogin.Click += BtnLogin_Click;

        btnSignUp = new Button
        {
            Text = "Sign Up",
            Location = new Point(250, 270),  
            Size = new Size(100, 40),
            Font = new Font(Font.FontFamily, 12)
        };
        btnSignUp.Click += BtnSignUp_Click;  

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
        }
        this.Controls.Add(lblUsername);
        this.Controls.Add(txtUsername);
        this.Controls.Add(lblPassword);
        this.Controls.Add(txtPassword);
        this.Controls.Add(btnLogin);
        this.Controls.Add(btnSignUp);  
    }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool isUser = db.VerifyUser(txtUsername.Text, txtPassword.Text);
            if (isUser)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    private void BtnLogin_Click(object sender, EventArgs e)
    {
        this.Hide();
        Form1 form1 = new Form1();
        form1.Closed += (s, args) => this.Close();
        form1.Show();
    }

    private void BtnSignUp_Click(object sender, EventArgs e)
    {
        this.Hide();
        Form3 form3 = new Form3();
        form3.Closed += (s, args) => this.Close();
        form3.Show();
    }
}
