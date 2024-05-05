using BaseCalendar;
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form2 : Form
{
    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
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

        txtUsername = new TextBox();
        txtUsername.Location = new Point(200, 95);
        txtUsername.Size = new Size(200, 30);
        txtUsername.Font = new Font(txtUsername.Font.FontFamily, 12);

        lblPassword = new Label();
        lblPassword.Text = "Password:";
        lblPassword.Location = new Point(200, 135);
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font(lblPassword.Font.FontFamily, 12);

        txtPassword = new TextBox();
        txtPassword.Location = new Point(200, 170);
        txtPassword.Size = new Size(200, 30);
        txtPassword.PasswordChar = '*';
        txtPassword.Font = new Font(txtPassword.Font.FontFamily, 12);

        btnLogin = new Button();
        btnLogin.Text = "Login";
        btnLogin.Location = new Point(250, 220);
        btnLogin.Size = new Size(100, 40);
        btnLogin.Font = new Font(btnLogin.Font.FontFamily, 12);
        btnLogin.Click += BtnLogin_Click;

        this.Controls.Add(lblUsername);
        this.Controls.Add(txtUsername);
        this.Controls.Add(lblPassword);
        this.Controls.Add(txtPassword);
        this.Controls.Add(btnLogin);
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        this.Hide();
        Form1 form1 = new Form1();
        form1.Closed += (s, args) => this.Close(); 
        form1.Show();
    }

}
