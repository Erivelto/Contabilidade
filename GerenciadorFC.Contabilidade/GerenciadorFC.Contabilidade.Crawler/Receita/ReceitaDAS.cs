using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ResolveCaptcha.Api;
using ResolveCaptcha.Helper;
using System.IO;
using System.Net.Mail;
using System.Net;
using GerenciadorFC.Contabilidade.Dominio.DAS;

namespace GerenciadorFC.Contabilidade.Crawler.Receita
{
    public class ReceitaDAS
    {
		public void EmissorImpostos(DadosDeDAS dados,string email)
		{

			var chromeOptions = new ChromeOptions
			{
				BinaryLocation = @"C:\	Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver",
			};
			chromeOptions.AddArguments("headless");
			IWebDriver driver = new ChromeDriver(chromeOptions);
			driver.Navigate().GoToUrl(dados.Url);

			var cnpj = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCNPJ"));
			cnpj.SendKeys(dados.CNPJ);

			var cpf = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCPFResponsavel"));
			cpf.SendKeys(dados.CPF);

			var codigo = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCodigoAcesso"));
			codigo.SendKeys(dados.CodigoContribuite);

			var captchaObject = driver.FindElement(By.Id("captcha-img"));
			var captchaSRC = captchaObject.GetAttribute("src");
			var directory = AppDomain.CurrentDomain.BaseDirectory;

			string[] imgsrcList = captchaSRC.Split(',');
			var filePath = string.Format("{0}\\captcha.png", directory);

			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}

			using (var stream = new FileStream(filePath, FileMode.CreateNew))
			using (var binatyStream = new BinaryWriter(stream))
			{
				byte[] base64Array = Convert.FromBase64String(imgsrcList[1]);

				binatyStream.Write(base64Array);
			}

			var captchaText = ReadImage(filePath, dados.CodigoAntiCaptcha);

			var captchaInputText = driver.FindElement(By.Id("txtTexto_captcha_serpro_gov_br"));

			captchaInputText.SendKeys(captchaText);

			driver.FindElement(By.Id("ctl00_ContentPlaceHolder_btContinuar")).Click();

			driver.FindElement(By.XPath("//a[contains(.,'Declaração Mensal')]")).Click();
			driver.FindElement(By.XPath("//a[contains(.,'Declarar/Retificar')]")).Click();
			var dataApuracao = driver.FindElement(By.XPath("//*[@id='pa']"));
			string periodo = dados.mesApuracao + dados.anoApuracao;
			dataApuracao.SendKeys(periodo);
			driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div/form/button")).Click();

			var gerada = IsElementPresent(By.XPath("//*[@id='jsMsgBoxConfirm']/a[2]"), driver);
			if (gerada == true)
			{
				driver.FindElement(By.XPath("//*[@id='jsMsgBoxConfirm']/a[2]")).Click();
			}
			var valor = driver.FindElement(By.Name("rpaCompInt"));
			valor.SendKeys(dados.ValorTributado);

			driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/form/button")).Click();

			foreach (var item in dados.Anexo)
			{
				driver.FindElement(By.XPath("//a[contains(.,'" + item.Anexo + "')]")).Click();
			}

			driver.FindElement(By.Id("btn-salvar")).Click();

			var mensagem = driver.FindElement(By.XPath("//div[contains(.,'MSG_E0062 - Nenhuma atividade selecionada. É necessário selecionar pelo menos uma atividade.')]"));
			if (mensagem != null)
			{
				driver.FindElement(By.XPath("//a[contains(.,'Declarar/Retificar')]")).Click();
				dataApuracao = driver.FindElement(By.XPath("//*[@id='pa']"));
				periodo = dados.mesApuracao + dados.anoApuracao;
				dataApuracao.SendKeys(periodo);
				driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/form/button")).Click();

				valor = driver.FindElement(By.Name("rpaCompInt"));
				valor.SendKeys(dados.ValorTributado);

				driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/form/button")).Click();

				driver.FindElement(By.Id("btn-salvar")).Click();
			}

			var valorReceita = driver.FindElement(By.XPath("//*[@id='0001-14']/table/tbody/tr[3]/td[1]/input"));
			valorReceita.SendKeys(dados.ValorTributado);
			driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/form/button")).Click();
			System.Threading.Thread.Sleep(3000);
			var icms = driver.FindElement(By.Name("icms"));
			icms.SendKeys("");
			driver.FindElement(By.XPath("//button[contains(.,'Calcular')]")).Click();

			driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/div/div/form/button[2]")).Click();
			driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div/div/div/a[2]")).Click();
			driver.FindElement(By.XPath("//*[@id='botoes']/button[2]")).Click();

			string url = driver.Url.ToString();
			string[] divisor = url.Split('=');
			string arquivoDAS = "PGDASD-DAS-" + divisor[1].ToString() + ".pdf";

			System.Threading.Thread.Sleep(3000);
			driver.Quit();

			MailMessage mail = new MailMessage();

			mail.From = new MailAddress("contato@contfy.com.br");
			mail.To.Add(email);

			//define o conteúdo
			mail.Subject = "Envio de solicitações ou tributos";
			mail.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><head>	<style type='text/css'>		body, #bodyTable, #bodyCell, #bodyCell {			height: 100% !important;			margin: 0;			padding: 0;			width: 100% !important;			font-family: Helvetica, Arial, 'Lucida Grande', sans-serif;		}		body, table, td, p, a, li, blockquote {			-ms-text-size-adjust: 100%;			-webkit-text-size-adjust: 100%;			font-weight: normal !important;		}		body, #bodyTable {			background-color: #E1E1E1;		}	</style>	<script type='text/javascript' src='http://gc.kis.v2.scr.kaspersky-labs.com/D23BDC46-5991-6E46-B0E9-985879E9A50E/main.js' charset='UTF-8'></script></head><body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'><center style='background-color:#E1E1E1;'><table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style='table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;'><tr><td align='center' valign='top' id='bodyCell'><table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='500' id='emailBody'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' style='color:#FFFFFF;' bgcolor='#F8F8F8'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'><table border='0' cellpadding='30' cellspacing='0' width='100%'><tr><td align='left' valign='top' class='textContent' style='color: dodgerblue; '><h1>Contfy</h1>  </td></tr></table></td></tr></table></td></tr></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFFFFF'><tr>	<td align='center' valign='top'>		<table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'><table border='0' cellpadding='30' cellspacing='0' width='100%'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td valign='top' class='textContent'><h3 style='color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;'>Olá esta em anexo o documento que foi solicitado ou tributo a ser pago. Qualquer duvida entre em contato conosco.</h3><br /> </td></tr></table></td>			</tr></table></td></tr></table></td></tr></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%'>										<tr style='padding-top:0;'>									<td align='center' valign='top'>																								<table border='0' cellpadding='30' cellspacing='0' width='500' class='flexibleContainer'>													<tr>														<td style='padding-top:0;' align='center' valign='top' width='500' class='flexibleContainerCell'>															<table border='0' cellpadding='0' cellspacing='0' width='50%' class='emailButton' style='background-color: #3498DB;'>																<tr>																																</tr>														</table>																							</td>													</tr>												</table>																						</td>										</tr>									</table>																	</td>							</tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFFFFF'><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'><tr><td align='center' valign='top' width='500' class='flexibleContainerCell'>						<table border='0' cellpadding='30' cellspacing='0' width='100%'>															<tr>																<td align='center' valign='top'>																	<table border='0' cellpadding='0' cellspacing='0' width='100%'>																		<tr>																			<td valign='top' class='textContent'>																				<div style='text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;'>CONTFY tem a oferecer aos nossos clientes a tecnologia às suas mãos para facilitar e agilizar todo esse processo burocrático na qual, estamos preparado, tanto na contabilidade tradicional quanto na online.</div>																			</td>																		</tr>																	</table>																</td>															</tr>														</table>													</td>												</tr>											</table>										</td>									</tr>								</table>							</td>					</tr>					</table>					<table bgcolor='#E1E1E1' border='0' cellpadding='0' cellspacing='0' width='500' id='emailFooter'>						<tr>							<td align='center' valign='top'>								<table border='0' cellpadding='0' cellspacing='0' width='100%'>									<tr>										<td align='center' valign='top'>											<!-- FLEXIBLE CONTAINER // -->											<table border='0' cellpadding='0' cellspacing='0' width='500' class='flexibleContainer'>												<tr>													<td align='center' valign='top' width='500' class='flexibleContainerCell'>														<table border='0' cellpadding='30' cellspacing='0' width='100%'>															<tr>																<td valign='top' bgcolor='#E1E1E1'>																	<div style='font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;'>																		<div>Contfy &#169;  a sua contabilidade online.</div>																	</div>																</td>															</tr>														</table>													</td>												</tr>											</table>										</td>									</tr>								</table>							</td>						</tr>					</table>				</td>			</tr>		</table>	</center></body></html>";
			Attachment attachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + @"Upload\Contabilidade\Receita\DAS\" + arquivoDAS);
			mail.Attachments.Add(attachment);


			//envia a mensagem
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.EnableSsl = true;
			smtp.Port = 587;
			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtp.UseDefaultCredentials = false;
			smtp.Credentials = new NetworkCredential("contato@contfy.com.br", "erivelto33");
			smtp.Send(mail);

		}
		private bool IsElementPresent(By by, IWebDriver driver)
		{
			try
			{
				driver.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}
		public string ReadImage(string filepath, string apiKey)
		{
			string captchaText = string.Empty;

			var api = new ImageToText
			{
				ClientKey = apiKey,
				FilePath = filepath
			};

			if (!api.CreateTask())
			{
				Console.WriteLine("API v2 send failed. " + api.ErrorMessage ?? "", DebugHelper.Type.Error);
			}
			else if (!api.WaitForResult())
			{
				DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
			}
			else
			{
				captchaText = api.GetTaskSolution();

				DebugHelper.Out("Result: " + captchaText, DebugHelper.Type.Success);
			}

			return captchaText;
		}
	}
}
