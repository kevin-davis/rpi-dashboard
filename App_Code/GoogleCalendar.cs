using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Google.Apis.Calendar.v3.Data;

/// <summary>
/// Summary description for GoogleCalendar
/// </summary>
public static class GoogleCalendar
{
    private static string KeyFile
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/App_Data/MirrorUI.p12");
        }
    }
    private static string ServiceAccount
    {
        get
        {
            return "SERVICE_ACCOUNT";
        }
    }
    public static Events GetEvents()
    {
        Events events;

            string[] scopes = new string[] {
            CalendarService.Scope.Calendar, // Manage your calendars
 	        CalendarService.Scope.CalendarReadonly // View your Calendars
            };

            var certificate = new X509Certificate2(KeyFile, "notasecret", X509KeyStorageFlags.Exportable);

            ServiceAccountCredential credential = new ServiceAccountCredential(
                 new ServiceAccountCredential.Initializer(ServiceAccount)
                 {
                     Scopes = scopes
                 }.FromCertificate(certificate));

            // Create the service.
            CalendarService service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MirrorUI",
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("fake@gmail.com");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        // List events
        events = request.Execute();
        return events;
    }
}