using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dont_Panic_MVC_API.Models
{

    public class ViewJob
    {
        [Required]
        [Display(Name = "What type of job do you have?")]
        public string jobtype { get; set; }
        [Required]
        [Display(Name = "What exactly is your job?")]
        public string title { get; set; }
        [Required]
        [Display(Name = "Tell us about it")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Where are you?")]
        public int region { get; set; }
        [Required]
        [Display(Name = "Where abouts?")]
        public int district { get; set; }
        [Required]
        [Display(Name = "Specifically?")]
        public int suburb { get; set; }
        [Required]
        [Display(Name = "When do you want your job done?")]
        public string duration { get; set; }
    }

    public class Region
    {
        [Key]
        public int regionid { get; set; }
        public string region { get; set; }
    }

    public class District
    {
        [Key]
        public int districtid { get; set; }
        public int regionid { get; set; }
        public string district { get; set; }
    }

    public class Suburb
    {
        [Key]
        public int suburbid { get; set; }
        public int districtid { get; set; }
        public string suburb { get; set; }
    }

    public class RegionDropDown
    {
        public RegionDropDown()
        {

            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem() { Value = "1", Text = "Northland" });
            listItems.Add(new SelectListItem() { Value = "2", Text = "Auckland" });
            listItems.Add(new SelectListItem() { Value = "3", Text = "Waikato" });
            listItems.Add(new SelectListItem() { Value = "4", Text = "Bay of Plenty" });
            listItems.Add(new SelectListItem() { Value = "5", Text = "Gisborne" });
            listItems.Add(new SelectListItem() { Value = "6", Text = "Hawke's Bay" });
            listItems.Add(new SelectListItem() { Value = "7", Text = "Taranaki" });
            listItems.Add(new SelectListItem() { Value = "8", Text = "Wanganui" });
            listItems.Add(new SelectListItem() { Value = "9", Text = "Manawatu" });
            listItems.Add(new SelectListItem() { Value = "10", Text = "Wairarapa" });
            listItems.Add(new SelectListItem() { Value = "11", Text = "Wellington" });
            listItems.Add(new SelectListItem() { Value = "12", Text = "Nelson Bay's" });
            listItems.Add(new SelectListItem() { Value = "13", Text = "Marlborough" });
            listItems.Add(new SelectListItem() { Value = "14", Text = "West Coast" });
            listItems.Add(new SelectListItem() { Value = "15", Text = "Canterbury" });
            listItems.Add(new SelectListItem() { Value = "16", Text = "Timaru" });
            listItems.Add(new SelectListItem() { Value = "17", Text = "Otago" });
            listItems.Add(new SelectListItem() { Value = "18", Text = "Southland" });

            RegionList = new SelectList(listItems, "Value", "Text");

        }
        [Display(Name = "Region")]
        public int ActionId { get; set; }
        public SelectList RegionList { get; set; }
    }
}