using System;
using System.Data;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Aipl_Maui_App
{
    public class GeneralFunc
    {
        public static string RevDate(string Mdate)
        {
            if (Mdate.Length >= 10)
            {
                DateTime dt = Convert.ToDateTime(Mdate);

                string Mdate1 = dt.Year.ToString() + "-" + dt.Month.ToString().PadLeft(2, '0') + "-" + dt.Day.ToString().PadLeft(2,'0');

                return Mdate1;
            }
            else
            {
                Mdate = "";
                return Mdate;
            }
        }

        public static bool IsDate(string Mdate)
        {
            if (Mdate.Length == 10)
            {
                try
                {
                    DateTime.ParseExact(Mdate, "d", null);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsDateTime(string Mdate)
        {
            try
            {
                DateTime.Parse(Mdate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidPeriod(string FromDate, string ToDate)
        {
            if (IsDate(FromDate) == true && IsDate(ToDate) == true)
            {
                if (DateTime.Parse(FromDate) > DateTime.Parse(ToDate))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static void SendAlertMail(string Email_To, string Email_Cc, string Msg_Subject, string Msg_KindAttn, string Msg_Content, DataTable Msg_Table, int[] ColWidth, string[] ColAlign)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<html><head><meta charset=\"utf-8\"/>");

            sb.Append("<style>");
            sb.Append("body {font-size: 10.5pt; font-family: 'Segoe UI'; color: rgb(0, 0, 0); line-height: 1.5;}");
            sb.Append("</style>");

            sb.Append("</head>");

            sb.Append("<body>");

            sb.Append("<span style=\"font-weight:bold; color:#0000D1; \">Kind Attn : </span><span style=\"font-weight:bold;\">" + Msg_KindAttn + "</span>");
            sb.Append("<br><br>");
            sb.Append("This Alert Message Regarding " + Msg_Subject);
            sb.Append("<br><br>");

            sb.Append("<div style=\"margin-left:50px;\">");
            sb.Append(Msg_Content);
            sb.Append("</div>");

            sb.Append("<br><br>");

            sb.Append("<div style=\"background-color: #2b303a; color: #000000; margin-left:25px;\">");
            if (Msg_Table != null)
            {
                int No_Of_Columns = Msg_Table.Columns.Count;

                sb.Append("<table  width =\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\">");
                sb.Append("<tr style=\"Height:50px; border:0px; padding: 0px;\">");
                for (int i = 0; i < No_Of_Columns; i++)
                {
                    if (i == 0)
                    {
                        sb.Append("<td style=\"background-color: #336666; border-color:#5c87b2; border-style:solid; padding: 0px; " +
                        "border-width:thin; text-align:center; font-weight:bold; border-right-color:#FFFFFF; color: #FFFFFF; width:" +
                        ColWidth[i].ToString() + "px;\">");
                    }
                    else
                    {
                        if (i == No_Of_Columns - 1)
                        {
                            sb.Append("<td style=\"background-color: #336666;  border-left-color:#FFFFFF; border-right-color:#5c87b2; " +
                            "border-top-color:#5c87b2;  border-bottom-color:#5c87b2; border-style:solid; padding: 0px; " +
                            "border-width:thin; text-align:center; font-weight:bold; color: #FFFFFF; width:" +
                            ColWidth[i].ToString() + "px;\">");
                        }
                        else
                        {
                            sb.Append("<td style=\"background-color: #336666;  border-right-color:#FFFFFF; border-left-color:#FFFFFF; " +
                            "border-top-color:#5c87b2;  border-bottom-color:#5c87b2; border-style:solid; padding: 0px; " +
                            "border-width:thin; text-align:center; font-weight:bold; color: #FFFFFF; width:" +
                            ColWidth[i].ToString() + "px;\">");

                        }
                    }

                    sb.Append(Msg_Table.Columns[i].ColumnName);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
                string Mstyle;
                foreach (DataRow Dr in Msg_Table.Rows)
                {
                    sb.Append("<tr style=\"background-color: #e4ebf0; padding: 0px; border:0px; \">");
                    for (int k = 0; k < No_Of_Columns; k++)
                    {
                        Mstyle = "style=\"text-align:" + ColAlign[k] + "; border-color:#5c87b2; border-style:solid; padding: 0px 0px 0px 5px; border-width:thin; \"";
                        sb.Append("<td " + Mstyle + ">");
                        sb.Append(Dr[k].ToString());
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("<tr style =\"background-color: #2b303a; color: #000000; width: 900px;\" role=\"presentation\" border=\"0\" width=\"900\" cellpadding=\"0\" align=\"center\">" +
                                   "<td colspan=\"" + No_Of_Columns + "\" style =\"font-size: 1px; line-height: 1px; border-top: 4px solid #1aa19c;padding: 10px 10px 10px 10px;\">" +
                                   "<span style=\"margin: 0; font-size: 12px;color: #ffffff;\">This email is autogenerated by ERP and do not send reply to this email.</span>" +
                                   "</td></tr>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append("<table>");
                sb.Append("<tr style =\"background-color: #2b303a; color: #000000; width: 900px;\" role=\"presentation\" border=\"0\" width=\"900\" cellpadding=\"0\" align=\"center\">" +
                                   "<td style =\"font-size: 1px; width: 900px; line-height: 1px; border-top: 4px solid #1aa19c;padding: 10px 10px 10px 10px;\">" +
                                   "<span style=\"margin: 0; font-size: 12px;color: #ffffff;\">This email is autogenerated by ERP and do not send reply to this email.</span>" +
                                   "</td></tr>");
                sb.Append("</table>");
            }
            sb.Append("</div>");
            sb.Append("</body>");
            sb.Append("</html>");

            string to = Email_To;
            string from = "erp.alert@acousticsind.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = sb.ToString();

            if (Email_Cc != "")
            {
                string[] CClist = Email_Cc.Split(',');
                string EmailCCList = "";
                for (int i = 0; i < CClist.Length; i++)
                {
                    if (CClist[i].ToString() != "" && EmailCCList.Contains(CClist[i].ToString()) == false && CClist[i].ToString() != to)
                    {
                        if (EmailCCList.Length == 0)
                        {
                            EmailCCList += CClist[i].ToString();
                        }
                        else
                        {
                            EmailCCList += "," + CClist[i].ToString();
                        }
                    }
                }

                if (EmailCCList == "" && Email_Cc != "")
                    EmailCCList = Email_Cc;

                if (EmailCCList != "")
                    message.CC.Add(EmailCCList);
            }

            message.Subject = Msg_Subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("mail.acousticsind.com", 25);
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("erp.alert@acousticsind.com", "Q6Qh84dsKd");
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                //client.Send(message);
            }
            catch (Exception)
            {

            }
        }

        public static void SendCalibAlertMail(string Email_To, string Email_Cc, string Msg_Subject, string Msg_KindAttn, string Msg_Content, DataTable Msg_Table, int[] ColWidth, string[] ColAlign)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<html><head><meta charset=\"utf-8\"/>");

            sb.Append("<style>");
            sb.Append("body {font-size: 10.5pt; font-family: 'Segoe UI'; color: rgb(0, 0, 0); line-height: 1.5;}");
            sb.Append("</style>");

            sb.Append("</head>");

            sb.Append("<body>");

            sb.Append("<span style=\"font-weight:bold; color:#0000D1; \">Kind Attn : </span><span style=\"font-weight:bold;\">" + Msg_KindAttn + "</span>");
            sb.Append("<br><br>");
            sb.Append("This Allert Message Regarding " + Msg_Subject);
            sb.Append("<br><br>");

            sb.Append("<div style=\"margin-left:50px;\">");
            sb.Append(Msg_Content);
            sb.Append("</div>");

            sb.Append("<br><br>");

            sb.Append("<div style=\"background-color: #2b303a; color: #000000; margin-left:25px;\">");
            if (Msg_Table != null)
            {
                int No_Of_Columns = Msg_Table.Columns.Count - 2;

                sb.Append("<table  width =\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\">");
                sb.Append("<tr style=\"Height:50px; border:0px; padding: 0px;\">");
                for (int i = 0; i < No_Of_Columns; i++)
                {
                    if (i == 0)
                    {
                        sb.Append("<td style=\"background-color: #336666; border-color:#5c87b2; border-style:solid; padding: 0px; " +
                        "border-width:thin; text-align:center; font-weight:bold; border-right-color:#FFFFFF; color: #FFFFFF; width:" +
                        ColWidth[i].ToString() + "px;\">");
                    }
                    else
                    {
                        if (i == No_Of_Columns - 1)
                        {
                            sb.Append("<td style=\"background-color: #336666;  border-left-color:#FFFFFF; border-right-color:#5c87b2; " +
                            "border-top-color:#5c87b2;  border-bottom-color:#5c87b2; border-style:solid; padding: 0px; " +
                            "border-width:thin; text-align:center; font-weight:bold; color: #FFFFFF; width:" +
                            ColWidth[i].ToString() + "px;\">");
                        }
                        else
                        {
                            sb.Append("<td style=\"background-color: #336666;  border-right-color:#FFFFFF; border-left-color:#FFFFFF; " +
                            "border-top-color:#5c87b2;  border-bottom-color:#5c87b2; border-style:solid; padding: 0px; " +
                            "border-width:thin; text-align:center; font-weight:bold; color: #FFFFFF; width:" +
                            ColWidth[i].ToString() + "px;\">");

                        }
                    }

                    sb.Append(Msg_Table.Columns[i].ColumnName);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
                string Mstyle;
                foreach (DataRow Dr in Msg_Table.Rows)
                {
                    sb.Append("<tr style=\"background-color: #e4ebf0; padding: 0px; border:0px; \">");
                    for (int k = 0; k < No_Of_Columns; k++)
                    {
                        Mstyle = "style=\"text-align:" + ColAlign[k] + "; background-color:" + Dr[No_Of_Columns].ToString() + "; color:" + Dr[No_Of_Columns + 1].ToString() + "; border-color:#5c87b2; border-style:solid; padding: 0px 0px 0px 5px; border-width:thin; \"";
                        sb.Append("<td " + Mstyle + ">");
                        sb.Append(Dr[k].ToString());
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("<tr style =\"background-color: #2b303a; color: #000000; width: 900px;\" role=\"presentation\" border=\"0\" width=\"900\" cellpadding=\"0\" align=\"center\">" +
                                   "<td colspan=\"" + No_Of_Columns + "\" style =\"font-size: 1px; line-height: 1px; border-top: 4px solid #1aa19c;padding: 10px 10px 10px 10px;\">" +
                                   "<span style=\"margin: 0; font-size: 12px;color: #ffffff;\">This email is autogenerated by ERP and do not send reply to this email.</span>" +
                                   "</td></tr>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append("<table>");
                sb.Append("<tr style =\"background-color: #2b303a; color: #000000; width: 900px;\" role=\"presentation\" border=\"0\" width=\"900\" cellpadding=\"0\" align=\"center\">" +
                                   "<td style =\"font-size: 1px; width: 900px; line-height: 1px; border-top: 4px solid #1aa19c;padding: 10px 10px 10px 10px;\">" +
                                   "<span style=\"margin: 0; font-size: 12px;color: #ffffff;\">This email is autogenerated by ERP and do not send reply to this email.</span>" +
                                   "</td></tr>");
                sb.Append("</table>");
            }
            sb.Append("</div>");
            sb.Append("</body>");
            sb.Append("</html>");

            string to = Email_To;
            string from = "erp.alert@acousticsind.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = sb.ToString();

            if (Email_Cc != "")
            {
                string[] CClist = Email_Cc.Split(',');
                string EmailCCList = "";
                for (int i = 0; i < CClist.Length; i++)
                {
                    if (CClist[i].ToString() != "" && EmailCCList.Contains(CClist[i].ToString()) == false && CClist[i].ToString() != to)
                    {
                        if (EmailCCList.Length == 0)
                        {
                            EmailCCList += CClist[i].ToString();
                        }
                        else
                        {
                            EmailCCList += "," + CClist[i].ToString();
                        }
                    }
                }

                if (EmailCCList != "")
                    message.CC.Add(EmailCCList);
            }

            message.Subject = Msg_Subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("mail.acousticsind.com", 25);
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("erp.alert@acousticsind.com", "Q6Qh84dsKd");
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(message);
            }
            catch (Exception)
            {

            }
        }

        public static void SendReminderAlert(string Rid, string Last_Reminder, string To_Mail, string Cc, string Reminder_Type)
        {
            if (Last_Reminder.Length >= 10)
                Last_Reminder = Last_Reminder.Substring(0, 10);

            StringBuilder sb = new StringBuilder();

            sb.Append("<html>");
            sb.Append("<body>");
            sb.Append("<header>" + @"Dear &nbsp;<strong>Sir/Madam</strong><br/>" + "</header>");
            if (Reminder_Type == "IT-Complaint" || Reminder_Type == "MT-Complaint")
                sb.Append("<p style='padding-left:10px;font-size:18px;margin-top:5px;'>you have a pending Complaint to take action<br> Complaint No:" + " " +
                          "<span style='color:blue;font-weight:bold;'>" + Rid + "</span><br><span>Last Reminder On:" + "" + Last_Reminder + "</span></p>");
            if (Reminder_Type == "IT-Request")
                sb.Append("<p style='padding-left:10px;font-size:18px;margin-top:5px;'>you have a pending Request to take action<br> Request Id:" + " " +
                    "<span style='color:blue;font-weight:bold;'>" + Rid + "</span><br><span>Last Reminder On:" + " " + Last_Reminder + "</span></p>");

            sb.Append("<table style='width:100%;margin-top:50px;'>");
            sb.Append("<tr>");
            sb.Append("<td align='center' style='font-size:18px;border-top:4px solid #1aa19c;padding:10px 10px 10px 10px;background-color: #2b303a;'>" +
                "<span style='margin:0;color:#ffffff;'>This email is autogenerated by ERP and do not send reply to this email.</span></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");

            string MailBody = sb.ToString();
            string from = "erp.alert@acousticsind.com";

            MailMessage message = new MailMessage(from, To_Mail);
            message.Subject = "This is a test mail From android application";
            message.Body = MailBody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            if (Cc != "")
            {
                message.CC.Add(Cc);
            }

            //create Alrternative HTML view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(MailBody, null, "text/html");
            //Add view to the Email Message
            message.AlternateViews.Add(htmlView);
            SmtpClient client = new SmtpClient("smtp.zoho.in", 587);
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("erp.alert@acousticsind.com", "mCVv BVkC XFcr");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(message);
            }
            catch (Exception Ex)
            {
                string Err_Message = Ex.Message.ToString();
            }
        }
    }
}