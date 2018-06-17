using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCafe.Bot.WC2018.Models;

namespace TechCafe.Bot.WC2018.Extension
{
    public static class ModelExtension
    {
        public static Match Fetch(this Match match,List<Team> teams, List<Stadium> stadiums)
        {
            if (match.Type == "group")
            {
                match.HomeTeamName = teams.FirstOrDefault(t => t.Id == int.Parse(match.HomeTeam)).Name;
                match.AwayTeamName = teams.FirstOrDefault(t => t.Id == int.Parse(match.AwayTeam)).Name;
            }
            else if (match.Type == "qualified")
            {
                // find team by 1st, 2nd per group
            } else if (match.Type.ToLower() == "Quarter-finals" 
                        || match.Type.ToLower() == "Semi - finals"
                        || match.Type.ToLower() == "Third place play-off"
                        || match.Type.ToLower() == "Final")
            {
                // find team by match
            }

            match.StadiumName = stadiums.FirstOrDefault(s => s.Id == match.Stadium).Name;

            return match;
        }

        public static string ToText(this Match match)
        {
            // https://docs.microsoft.com/en-us/previous-versions/windows/embedded/gg154758(v=winembedded.80)
            var zoneId = "SE Asia Standard Time";
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
            var dateTime = TimeZoneInfo.ConvertTime(match.Date, timeZone);
            var result = $"{dateTime.ToString("dddd, dd-MM-yyyy HH:mm")}, {match.StadiumName}, {match.HomeTeamName} - {match.AwayTeamName}";
            return result;
        }

        public static string ToScore(this Match match)
        {
            var result = $"{match.HomeTeamName} {match.HomeResult} - {match.AwayResult} {match.AwayTeamName}";
            return result;
        }
    }
}