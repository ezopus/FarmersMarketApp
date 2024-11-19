namespace FarmersMarketApp.Web.Models
{
	public class EmailSettings
	{
		public string SmtpServer { get; set; }
		public int Port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string FromEmail { get; set; }
	}
}
