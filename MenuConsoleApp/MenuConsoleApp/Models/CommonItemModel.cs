using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.Models
{
    [DataContract]
    [KnownType(typeof(Book))]
    [KnownType(typeof(Movie))]
    public abstract class CommonItemModel : IDisplayableComponent, ISearchable
    {
        [DataMember] 
        public string Title { get; set; } = string.Empty;
        [DataMember] 
        public string Genre { get; set; } = string.Empty;
        [DataMember]
        public int ElementId { get; set; } 

        public abstract string DisplayDetails();

        public abstract bool ContainsText(string userInput);
    }
}
