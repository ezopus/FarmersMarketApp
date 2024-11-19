namespace FarmersMarketApp.Web.Models
{
	using Microsoft.AspNetCore.Identity.UI.Services;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.Logging;
	using System.Net;
	using System.Net.Mail;
	using System.Threading.Tasks;

	public class EmailSender : IEmailSender
	{
		private readonly ILogger<EmailSender> _logger;
		private readonly IConfiguration _configuration;

		public EmailSender(ILogger<EmailSender> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var smtpClient = new SmtpClient
			{
				Host = _configuration["EmailSettings:SmtpServer"],
				Port = int.Parse(_configuration["EmailSettings:Port"]),
				Credentials = new NetworkCredential(
					_configuration["EmailSettings:Username"],
					_configuration["EmailSettings:Password"]
				),
				EnableSsl = true
			};

			try
			{
				using var message = new MailMessage
				{
					From = new MailAddress(_configuration["EmailSettings:FromEmail"]),
					Subject = subject,
					Body = htmlMessage,
					IsBodyHtml = true
				};

				message.To.Add(email);
				await smtpClient.SendMailAsync(message);
				_logger.LogInformation("Email sent successfully to {Email}", email);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error sending email to {Email}", email);
				throw;
			}
		}
	}
}
