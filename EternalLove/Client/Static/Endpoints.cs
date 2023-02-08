using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EternalLove.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string UserDetailsEndpoint = $"{Prefix}/userdetails";
        public static readonly string GendersEndpoint = $"{Prefix}/genders";
        public static readonly string MatchsEndpoint = $"{Prefix}/matchs";
        public static readonly string LocationsEndpoint = $"{Prefix}/locations";
        public static readonly string ReviewsEndpoint = $"{Prefix}/reviews";
        public static readonly string ReportsEndpoint = $"{Prefix}/reports";
        public static readonly string ChatsEndpoint = $"{Prefix}/Chatss";
    }
}
