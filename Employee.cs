using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NorthWind.Linq
{
    public class Employee
    {
        public string DisplayName { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CommonId { get; set; }
        public string Team { get; set; }
        public string SubTeam { get; set; }

        [JsonConverter(typeof(DateFormatConverter))]
        public DateTime? HireDate { get; set; }
        public string Fax { get; set; }
        public string State { get; set; }
        public object Zip { get; set; }
        public string OfficeCity { get; set; }
        public string TeamLeader { get; set; }
        public string Office { get; set; }
        public string PictureUrl { get; set; }
        public int Extension { get; set; }
    }
}
