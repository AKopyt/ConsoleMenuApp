using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MenuConsoleApp.Component;
using MenuConsoleApp.Interfaces;

namespace MenuConsoleApp.Models
{
    [DataContract]
    public class Book : CommonItemModel 
    {
        [DataMember]
        public string Author { get; set; } = String.Empty;
        [DataMember]
        public DateTime? PublicationDate { get; set; }
       
        public override string DisplayDetails()
        {
           var detailsOfElement = ($"{ElementId} - {Title} - {Author} - {PublicationDate?.ToString("dd/MM/yyyy")} - {Genre}");
           return detailsOfElement;
        }

        public override bool ContainsText(string userInput) 
        {
            if (Author.ToLower().Contains(userInput.ToLower()) || Title.ToLower().Contains(userInput.ToLower())
                                                                 || Genre.ToLower().Contains(userInput.ToLower())
                                                                 || ElementId.ToString().Contains(userInput)
                                                                 || PublicationDate.ToString()!.Contains(userInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
