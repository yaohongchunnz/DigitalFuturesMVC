using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dont_Panic_MVC_API.Models
{
    public class RegionDropDown
    {
        public RegionDropDown(){

            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem(){ Value = "1",  Text = "Northland "    });
            listItems.Add(new SelectListItem(){ Value = "2",  Text = "Auckland"      });
            listItems.Add(new SelectListItem(){ Value = "3",  Text = "Waikato"       });
            listItems.Add(new SelectListItem(){ Value = "4",  Text = "Bay of Plenty" });
            listItems.Add(new SelectListItem(){ Value = "5",  Text = "Gisborne"      });
            listItems.Add(new SelectListItem(){ Value = "6",  Text = "Hawke's Bay"   });
            listItems.Add(new SelectListItem(){ Value = "7",  Text = "Taranaki"      });
            listItems.Add(new SelectListItem(){ Value = "8",  Text = "Wanganui"      });
            listItems.Add(new SelectListItem(){ Value = "9",  Text = "Manawatu"      });
            listItems.Add(new SelectListItem(){ Value = "10", Text = "Wairarapa"     });
            listItems.Add(new SelectListItem(){ Value = "11", Text = "Wellington"    });
            listItems.Add(new SelectListItem(){ Value = "12", Text = "Nelson Bay's"  });
            listItems.Add(new SelectListItem(){ Value = "13", Text = "Marlborough"   });
            listItems.Add(new SelectListItem(){ Value = "14", Text = "West Coast"    });
            listItems.Add(new SelectListItem(){ Value = "15", Text = "Canterbury"    });
            listItems.Add(new SelectListItem(){ Value = "16", Text = "Timaru"        });
            listItems.Add(new SelectListItem(){ Value = "17", Text = "Otago"         });
            listItems.Add(new SelectListItem(){ Value = "18", Text = "Southland"     });

            RegionList = new SelectList(listItems, "Value", "Text");
        }
        [Display(Name="Region")]
        public int ActionId { get; set; }
        public SelectList RegionList { get; set; }  
    }

    public class WellingtonDistrictDropDown
    {
        public WellingtonDistrictDropDown()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem() { Value = "1", Text = "Carterton " });
            listItems.Add(new SelectListItem() { Value = "2", Text = "Kapiti Coast" });
            listItems.Add(new SelectListItem() { Value = "3", Text = "Lower Hutt" });
            listItems.Add(new SelectListItem() { Value = "4", Text = "Masterton" });
            listItems.Add(new SelectListItem() { Value = "5", Text = "Porirua" });
            listItems.Add(new SelectListItem() { Value = "6", Text = "South Wairarapa" });
            listItems.Add(new SelectListItem() { Value = "7", Text = "Upper Hutt" });
            listItems.Add(new SelectListItem() { Value = "8", Text = "Wellington" });

            DistrictList = new SelectList(listItems, "Value", "Text");
        }

        [Display(Name = "Region")]
        public int ActionId { get; set; }
        public SelectList DistrictList { get; set; } 
    }

    public class WellingtonSuburbDropDown
    {
        public WellingtonSuburbDropDown()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem() { Value = "1", Text = "Aro Valley" });
            listItems.Add(new SelectListItem() { Value = "2", Text = "Berhampore" });
            listItems.Add(new SelectListItem() { Value = "3", Text = "Breaker Bay" });
            listItems.Add(new SelectListItem() { Value = "4", Text = "Broadmeadows" });
            listItems.Add(new SelectListItem() { Value = "5", Text = "Brooklyn" });
            listItems.Add(new SelectListItem() { Value = "6", Text = "Churton Park" });
            listItems.Add(new SelectListItem() { Value = "7", Text = "Crofton Downs" });
            listItems.Add(new SelectListItem() { Value = "8", Text = "Evans Bay" });
            listItems.Add(new SelectListItem() { Value = "9", Text = "Glenside" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Grenada North" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Grenada Village" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Hataitai" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Highbury" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Horokiwi" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Houghton Bay" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Island Bay" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Johnsonville" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Kaiwharawhara" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Karaka Bays" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Karori" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Kelburn" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Khandallah" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Kilbirnie" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Kingston" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Kowhai Park" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Lambton" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Lyall Bay" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Makara-Ohariu" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Maupuia" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Melrose" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Miramar" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Moa Point" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Mornington" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Mt Cook" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Mt Victoria" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Newlands" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Newtown" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Ngaio" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Ngauranga" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Northland" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Ohariu" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Oriental Bay" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Owhiro Bay" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Paparangi" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Pipitea" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Rongotai" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Roseneath" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Seatoun" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Southgate" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Strathmore Park" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Takapu Valley" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Tawa" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Te Aro" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Thorndon" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Vogeltown" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Wadestown" });
            listItems.Add(new SelectListItem() { Value = "1", Text = "Aro Valley" });
















        }

        [Display(Name = "Suburb")]
        public int ActionId { get; set; }
        public SelectList DistrictList { get; set; } 
    }


}