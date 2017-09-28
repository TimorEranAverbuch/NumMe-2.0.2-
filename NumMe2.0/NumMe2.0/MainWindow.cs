using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    string goon = "none";
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

	public static bool IsPrime(int number)
	{
		if (number == 1) return false;
		if (number == 2) return true;
		if (number % 2 == 0) return false;

		int boundary = (int)Math.Floor(Math.Sqrt(number));

		for (int i = 3; i <= boundary; i += 2)
		{
			if (number % i == 0) { return false; }
		}

		return true;
	}

    public void multi(int num)
	{
		int sum = num;
		int mul;
        this.Output.Text = this.Output.Text + Environment.NewLine + "And here is the multiplicators: ";
		for (int i = 2; i < num; i++)
		{
			mul = i;
			if ((num % i) == 0)
			{
				this.Output.Text = this.Output.Text + Convert.ToString(i) + " : ";
				while (sum > i)
				{
					this.Output.Text = this.Output.Text + Convert.ToString(i) + " + ";
					sum = sum - i;
				}
				this.Output.Text = this.Output.Text + Convert.ToString(i) + " = " + Convert.ToString(num);

				this.Output.Text = this.Output.Text + Environment.NewLine + this.Output.Text + Environment.NewLine + "";
				this.Output.Text = this.Output.Text + Convert.ToString(i);
				mul = mul * i;
				while (num >= mul)
				{
					this.Output.Text = this.Output.Text + " x " + Convert.ToString(i);
					mul = mul * i;
				}
				this.Output.Text = this.Output.Text + " + " + Convert.ToString(num - (mul / i)) + " = " + num;
				this.Output.Text = this.Output.Text + Environment.NewLine + " ";
			}
			sum = num;
		}
	}

    public string getInput()
    {
        string inp = "128";
        this.commands.Text = this.commands.Text + Environment.NewLine + "Please enter a vaid number : ";
        inp = Input.Text;  
        return inp;
    }

    public int check(string str_num)
	{
        int int_num = 0;
		int ch = 0;
		char[] char_num = str_num.ToCharArray();
		char[] valid_chars = "1234567890".ToCharArray();
		foreach (char chr in char_num)
		{
	    	ch = 0;
			foreach (char good in valid_chars)
			{
				if (chr != good)
				{
					ch++;
				}
			}
			if (ch == 9)
			{
	    		int_num = Convert.ToInt32(str_num);
            }
		}
		return int_num;
	}

    protected void OnPrimeClicked(object sender, EventArgs e)
    {
        this.commands.Text = "Welcome to PriMe® ";
        goon = "prime";
    }

    protected void OnMultiplicatoriumClicked(object sender, EventArgs e)
    {
    	this.commands.Text = "Welcome to Multiplicatorium® ";
    	goon = "mult";
    }



    protected void OnOkClicked(object sender, EventArgs e)
    {
            if(goon == "mult"){
				bool go = true;
				while (go)
				{
					int num = 0; bool move = true;
					while (move)
					{
						num = check(getInput());
						if (check(getInput()) != 0)
						{
							move = false;
						}
						else
						{
							this.commands.Text = "Invalid Input";
							System.Threading.Thread.Sleep(3000);
						}
					}
					int sum = num;
					this.commands.Text = this.commands.Text + Environment.NewLine + "Now enter second number ";
					int i = 0; move = true;
					while (move)
					{
						i = check(getInput());
						if (check(getInput()) != 0)
						{
							move = false;
						}
						else
						{
							this.commands.Text = "Invalid Input";
							System.Threading.Thread.Sleep(3000);
						}
					}
					if (i == 0 || i == 1 || num == 0 || num == 1)
					{
						this.commands.Text = this.commands.Text + Environment.NewLine + "Sorry, but 0 and 1 are not exepted ";
					}
					else
					{
						go = false;
						int mul = i;
						this.Output.Text = this.Output.Text + Environment.NewLine + "";
						this.Output.Text = this.Output.Text + Environment.NewLine + Convert.ToString(i);
						mul = mul * i;
						while (num >= mul)
						{
							this.Output.Text = this.Output.Text + Environment.NewLine + " x " + Convert.ToString(i);
							mul = mul * i;
						}
						this.Output.Text = this.Output.Text + Environment.NewLine + " + " + Convert.ToString(num - (mul / i)) + " = " + num;
						this.Output.Text = this.Output.Text + Environment.NewLine + " ";
					}
				}
            }
            else if(goon == "prime"){
				int int_num = 0; bool goin = true;
				while (goin)
				{
					int_num = check(getInput());
					if (check(getInput()) != 0)
					{
						goin = false;
					}
					else
					{
						this.commands.Text = "Invalid Input";
						System.Threading.Thread.Sleep(3000);
					}
				}

				if (IsPrime(int_num))
				{
					this.Output.Text = this.Output.Text + "Your number is prime";
				}
				else
				{
					this.Output.Text = this.Output.Text + "Your number is not prime";
				}

				multi(int_num);
			}else{
                this.commands.Text = this.commands.Text + "Please choose one of the options";
            }
        }
}
