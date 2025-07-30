using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationsSystem.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Register your notification services as transient, meaning a new instance
        // is created each time it's requested from the DI container.
        services.AddTransient<EmailService>(); // Register the concrete types
        services.AddTransient<SMSService>();
        services.AddTransient<PushNotificationService>();
        //This is the core of utilizing DI here. Instead of new EmailService(),
        //you ask the host.Services(your IServiceProvider) to give you an instance of EmailService.
        //Because you registered it as Transient,
        //it will create a new one each time GetRequiredService is called
        //(though here you only call it once for each service).

        // You can also register Notifier itself if you want the DI container to manage it,
        // but for this specific example, manual instantiation is also fine as it's a root object.
        services.AddSingleton<Notifier>(); // Notifier can be a singleton since it holds the delegate.
        //By registering Notifier as a singleton, the DI container will
        //provide the same instance of Notifier throughout the application's lifetime,
        //which is appropriate since it manages the central OnNotificationSent delegate.
        //Then, you resolve it using host.Services.GetRequiredService<Notifier>()
    })
    .Build();

// 1. Resolve the Notifier instance from the DI container
//    If Notifier was not registered, you'd still do 'new Notifier()'.
var notifier = host.Services.GetRequiredService<Notifier>();

// 2. Resolve each specific notification service from the DI container
//    Since they are registered as Transient, each call to GetRequiredService will
//    give you a new instance.
var emailService = host.Services.GetRequiredService<EmailService>();
var smsService = host.Services.GetRequiredService<SMSService>();
var pushNotificationService = host.Services.GetRequiredService<PushNotificationService>();

// 3. Subscribe the methods of the resolved instances to the delegate
notifier.OnNotificationSent += emailService.Send;
notifier.OnNotificationSent += smsService.Send;
notifier.OnNotificationSent += pushNotificationService.Send;

notifier.Send("Hello Doha !");


bool isContinue = true;

while (isContinue)
{
    Console.WriteLine("Which method would you remove (1- SMS 2- Email 3- PushNotification) ?");
    Console.WriteLine("Write the number of the option : ");
    string option = Console.ReadLine();

    bool removed = false;

    switch (option)
    {
        case "1":
            // When removing, make sure you reference the same instance you added.
            notifier.OnNotificationSent -= smsService.Send;  
            removed = true;
            break;
        case "2":
            notifier.OnNotificationSent -= emailService.Send;
            removed = true;
            break;
        case "3":
            notifier.OnNotificationSent -= pushNotificationService.Send;
            removed = true;
            break;
        default:
            Console.WriteLine("Invalid Option !");
            break;
    }

    if (removed)
    {
        notifier.Send("Hello Doha !");
        break;
    }
}