using FinNetworkTask;

FintechNetwork network = new FintechNetwork();
network.ShareInsight(1, 5);
var insights = network.GetLatestInsights(1);
Console.WriteLine(string.Join(", ", insights));

network.ConnectWithProfessional(1, 2);
network.ShareInsight(2, 6);
insights = network.GetLatestInsights(1);
Console.WriteLine(string.Join(", ", insights));

network.DisconnectWithProfessional(1, 2);
insights = network.GetLatestInsights(1);
Console.WriteLine(string.Join(", ", insights));