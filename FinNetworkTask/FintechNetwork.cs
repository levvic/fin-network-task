using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinNetworkTask
{
    internal class FintechNetwork
    {
        private Dictionary<int, List<int>> userInsights = new Dictionary<int, List<int>>();
        private Dictionary<int, HashSet<int>> userConnections = new Dictionary<int, HashSet<int>>();

        public void ShareInsight(int userId, int insightId)
        {
            if (!userInsights.ContainsKey(userId))
            {
                userInsights[userId] = new List<int>();
            }
            userInsights[userId].Insert(0, insightId);  // Prepending to simulate latest first
        }

        public List<int> GetLatestInsights(int userId)
        {
            var allInsights = new List<int>();

            if (userInsights.ContainsKey(userId))
            {
                allInsights.AddRange(userInsights[userId]);
            }

            if (userConnections.ContainsKey(userId))
            {
                foreach (var friendId in userConnections[userId])
                {
                    if (userInsights.ContainsKey(friendId))
                    {
                        allInsights.AddRange(userInsights[friendId]);
                    }
                }
            }

            return allInsights.OrderByDescending(id => id).Take(10).ToList();
        }

        public void ConnectWithProfessional(int userId, int professionalId)
        {
            if (!userConnections.ContainsKey(userId))
            {
                userConnections[userId] = new HashSet<int>();
            }

            if (!userConnections.ContainsKey(professionalId))
            {
                userConnections[professionalId] = new HashSet<int>();
            }

            userConnections[userId].Add(professionalId);
            userConnections[professionalId].Add(userId);
        }

        public void DisconnectWithProfessional(int userId, int professionalId)
        {
            if (userConnections.ContainsKey(userId))
            {
                userConnections[userId].Remove(professionalId);
            }

            if (userConnections.ContainsKey(professionalId))
            {
                userConnections[professionalId].Remove(userId);
            }
        }
    }
}
