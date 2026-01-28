using System;
using System.Collections.Generic;
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
    public class Movie : CommonItemModel
    {
        [DataMember]
        public DateTime? PremiereDate { get; set; }
        [DataMember]
        public string Director { get; set; } = string.Empty;

        public override string DisplayDetails()
        {
           var detailsOfElement = ($"{ElementId} - {Title} - {Director} - {PremiereDate?.ToString("dd/MM/yyyy")} - {Genre}");
           return detailsOfElement;
        }

        public override bool ContainsText(string userInput)
        {
            if (Director.ToLower().Contains(userInput.ToLower()) || Title.ToLower().Contains(userInput.ToLower())
                                                                 || Genre.ToLower().Contains(userInput.ToLower())
                                                                 || ElementId.ToString().Contains(userInput)
                                                                 || PremiereDate.ToString()!.Contains(userInput))
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
