public class Loan
{
    public int Id { get; set; }
    public Client Client { get; set; }
    public double Ammount { get; set; }
    public int Installment { get; set; }
    public string DateStart { get; set; }
    public string DateEnd { get; set; }

    public Loan(Client client, double ammount, int installment, string dateStart, string dateEnd)
    {
        Id = new Random().Next(100);
        Client = client;
        Ammount = ammount;
        Installment = installment;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }
}