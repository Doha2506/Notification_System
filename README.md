🔧 Task: Notification System Using Delegates

📝 Scenario:

You are building a basic notification system where different types of notifications can be sent (like Email, SMS, and Push notifications). The user can subscribe one or more notification methods dynamically.

🧩 Requirements:

Create a delegate named NotificationHandler that takes a string message.

Create a class Notifier with:

A method Send(string message) that invokes all registered notification handlers.

Create 3 methods for:

Sending email

Sending SMS

Sending push notifications
Each should match the delegate signature and print a message like:
"Sending Email: <message>"

In Main():

Create an instance of Notifier.

Register 2 or 3 notification methods using the delegate.

Call Send() to send a notification.

✅ Example Output:

Sending Email: Hello User!
Sending SMS: Hello User!
Sending Push Notification: Hello User!

🧠 Bonus Challenge (optional):

Allow removing a notification method at runtime.