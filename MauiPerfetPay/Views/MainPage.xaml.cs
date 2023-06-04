namespace MauiPerfetPay;

public partial class MainPage : ContentPage
{

	//Performing the calculations 
	decimal bill;
	int tip;
	int noPersons = 1;
	public MainPage()
	{
		InitializeComponent();
	}

    private void txtBill_Completed(object sender, EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
		CaculateTotal();
    }

    private void CaculateTotal()
    {
        // Total Tip
        var totalTip = (bill * tip) / 100;

        // Tip by person
        var tipByPerson = (totalTip / noPersons);
        lblTip.Text = $"{tipByPerson:C}";

        // SubTotal
        var subTotal = (bill / noPersons);
        lblSubtotal.Text = $"{subTotal:C}";

        // Total
        var totalByPerson = (bill + totalTip) / noPersons;
        lblTotal.Text = $"{totalByPerson:C}";
    }
    /// <summary>
    /// Get percentage of the type
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: { tip }";
        CaculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        noPersons++;
        lblNoPerons.Text = noPersons.ToString();

        CaculateTotal();
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (noPersons < 1) noPersons--;
        lblNoPerons.Text = noPersons.ToString();

        CaculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if(sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;

        }
    }
}

