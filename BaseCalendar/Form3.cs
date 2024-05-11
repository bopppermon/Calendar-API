using BaseCalendar;
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form3 : Form
{
    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnSignUp;
    private Button btnReturnToSignIn;
    LoginSignupDatabase db = new LoginSignupDatabase("./LDb.db");

    public Form3()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Size = new Size(600, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Sign Up Form";

        lblUsername = new Label
        {
            Text = "Username:",
            Location = new Point(200, 60),
            AutoSize = true,
            Font = new Font(Font.FontFamily, 12)
        };

        txtUsername = new TextBox
        {
            Location = new Point(200, 95),
            Size = new Size(200, 30),
            Font = new Font(Font.FontFamily, 12)
        };

        lblPassword = new Label
        {
            Text = "Password:",
            Location = new Point(200, 135),
            AutoSize = true,
            Font = new Font(Font.FontFamily, 12)
        };

        txtPassword = new TextBox
        {
            Location = new Point(200, 170),
            Size = new Size(200, 30),
            PasswordChar = '*',
            Font = new Font(Font.FontFamily, 12)
        };

        btnSignUp = new Button
        {
            Text = "Sign Up",
            Location = new Point(250, 220),
            Size = new Size(100, 40),
            Font = new Font(Font.FontFamily, 12)
        };
        btnSignUp.Click += BtnSignUp_Click;

        btnReturnToSignIn = new Button
        {
            Text = "Return to Sign In",
            Location = new Point(225, 270),
            Size = new Size(150, 40),
            Font = new Font(Font.FontFamily, 12)
        };
        btnReturnToSignIn.Click += BtnReturnToSignIn_Click;

        this.Controls.Add(lblUsername);
        this.Controls.Add(txtUsername);
        this.Controls.Add(lblPassword);
        this.Controls.Add(txtPassword);
        this.Controls.Add(btnSignUp);
        this.Controls.Add(btnReturnToSignIn);
    }

    private void BtnSignUp_Click(object sender, EventArgs e)
    {
        db.AddUser(txtUsername.Text, txtPassword.Text);
        MessageBox.Show("Sign Up Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Hide();
        Form2 form2 = new Form2();
        form2.Closed += (s, args) => this.Close();
        form2.Show();
    }

    private void BtnReturnToSignIn_Click(object sender, EventArgs e)
    {
        this.Hide();
        Form2 form2 = new Form2();
        form2.Closed += (s, args) => this.Close();
        form2.Show();
    }
}
