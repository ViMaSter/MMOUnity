using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AuthenticationServer.Services
{
    public interface ISessionManager
    {
        public bool TryCreateSessionIDForUser(string username, out int sessionID);
    }

    public class SessionManager : ISessionManager
    {
        private readonly Dictionary<string, int> sessionIDByUsername = new Dictionary<string, int>();
        private const int sessionPoolExtensionSize = 1000;
        private ConcurrentBag<int> availableSessionIDs = new ConcurrentBag<int>();

        private void ExtendSessionBag()
        {
            int startAt = availableSessionIDs.Count;
            for (int i = startAt; i < startAt + sessionPoolExtensionSize; ++i)
            {
                if (i == int.MinValue)
                {
                    continue;
                }
                availableSessionIDs.Add(i);
            }
        }
        private int GetNextSessionID()
        {
            int result = int.MinValue;
            if (!availableSessionIDs.TryTake(out result))
            {
                ExtendSessionBag();
            }

            if (!availableSessionIDs.TryTake(out result))
            {
                throw new ArgumentOutOfRangeException("Session bag is limited to 32 bit");
            }
            return result;
        }

        private bool TryFreeSessionForUser(string username)
        {
            if (!sessionIDByUsername.ContainsKey(username))
            {
                return false;
            }

            availableSessionIDs.Add(sessionIDByUsername[username]);
            sessionIDByUsername.Remove(username);
            return true;
        }

        public bool TryCreateSessionIDForUser(string username, out int sessionID)
        {
            if (sessionIDByUsername.ContainsKey(username))
            {
                Console.WriteLine($"User '{username}' was logged in before (session ID: {sessionIDByUsername[username]}), dropping session");
                TryFreeSessionForUser(username);
            }

            sessionID = int.MinValue;
            try
            {
                sessionID = GetNextSessionID();
                sessionIDByUsername[username] = sessionID;
                return true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return false;
            }
        }
    }
}
