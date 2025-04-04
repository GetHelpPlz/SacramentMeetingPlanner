using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime MeetingDateTime { get; set; }

        // Initialize the lists to avoid null issues.
        public List<HymnSelection> Hymns { get; set; } = new();
        public List<SpeakerSelection> Speakers { get; set; } = new();
    }

    [Owned]
    public class HymnSelection
    {
        public string Purpose { get; set; }
        public string SelectedHymn { get; set; }
    }

    [Owned]
    public class SpeakerSelection
    {
        public string Topic { get; set; }
        public string SelectedSpeaker { get; set; }
    }
}
